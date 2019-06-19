using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing.Drawing2D;

namespace CharacterRecognizer
{
    public partial class MainForm : Form
    {
        private DataSet DataSet;
        private DataSet TrainingSet;
        private DataSet TestSet;
        private NeuralNetwork PresetNeuralNetwork;
        private NeuralNetwork CustomNeuralNetwork;

        private CharacterImage selectedCharacterImage;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            //Load data.
            DataSet = DataLoader.LoadAllData();
            TrainingSet = DataSet.GetTrainingSet();
            TestSet = DataSet.GetTestSet();
            //Display data statistics.
            updateDataStatisctics();
            //Setup font selection combo box.
            comboBoxFonts.DataSource = new List<string>(DataSet.ImagesByFontFamily.Keys);
            //Load preset network
            loadPresetNeuralNetwork();
        }

        private void updateDataStatisctics()
        {
            string stats = "";
            if (radioButtonAllData.Checked)
            {
                stats = "All Data.\r\n";
                stats += "Total count: " + DataSet.Images.Count + ", Characters: " + DataSet.ImagesByCharacter.Count + ", Fonts: " + DataSet.ImagesByFontFamily.Count + "\r\n";
                foreach (KeyValuePair<char, List<CharacterImage>> pair in DataSet.ImagesByCharacter)
                    stats += pair.Key + ": " + pair.Value.Count + "\t";
                stats += "\r\n";
            }
            else if (radioButtonTrainingSet.Checked)
            {
                stats = "Training Set.\r\n";
                stats += "Total count: " + TrainingSet.Images.Count + ", Characters: " + TrainingSet.ImagesByCharacter.Count + ", Fonts: " + TrainingSet.ImagesByFontFamily.Count + "\r\n";
                foreach (KeyValuePair<char, List<CharacterImage>> pair in TrainingSet.ImagesByCharacter)
                    stats += pair.Key + ": " + pair.Value.Count + "\t";
                stats += "\r\n";
            }
            else if (radioButtonTestSet.Checked)
            {
                stats = "Test Set.\r\n";
                stats += "Total count: " + TestSet.Images.Count + ", Characters: " + TestSet.ImagesByCharacter.Count + ", Fonts: " + TestSet.ImagesByFontFamily.Count + "\r\n";
                foreach (KeyValuePair<char, List<CharacterImage>> pair in TestSet.ImagesByCharacter)
                    stats += pair.Key + ": " + pair.Value.Count + "\t";
                stats += "\r\n";
            }
            textBoxDataSetStatistics.Text = stats;
        }

        private void loadPresetNeuralNetwork()
        {
            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(NeuralNetworkState));
            if (File.Exists(@"presetNN.xml"))
            {
                var file = new StreamReader(@"presetNN.xml");
                NeuralNetworkState presetState = (NeuralNetworkState)reader.Deserialize(file);
                file.Close();
                PresetNeuralNetwork = new NeuralNetworkUCI(presetState);
                textBoxPresetNeuralNetwork.Text =
                    "Preset Neural Network:\r\n" +
                    PresetNeuralNetwork.GetInfo() + "\r\n" +
                    testNeuralNetwork(PresetNeuralNetwork);
                selectCharacterImage(selectedCharacterImage);
            }
            else
                textBoxPresetNeuralNetwork.Text = "Could not load preset neural network. \r\nMake sure presetNN.xml exists in application folder.";
        }

        private void saveNeuralNetwork(NeuralNetwork nn, int i)
        {
            //save 
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(NeuralNetworkState));
            var wfile = new StreamWriter(@"G:\Studia\BIAI\savedNN"+i+".xml");
            writer.Serialize(wfile, nn.GetNeuralNetworkState());
            wfile.Close();
        }

        private void trainNeuralNetwork(NeuralNetwork nn)
        {
            nn.Train(TrainingSet.Images);
        }

        private string testNeuralNetwork(NeuralNetwork nn)
        {
            if (nn == null)
                return null;
            int allImages = TestSet.Images.Count;
            int successfullyRecognized = 0;
            foreach (CharacterImage image in TestSet.Images)
            {
                if (nn.Recognize(image) == image.Label)
                    successfullyRecognized++;
            }
                
            double accuracy = (double)successfullyRecognized / (double)allImages;
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.PercentDecimalDigits = 4;
            string testStats =  "Accuracy: " + accuracy.ToString("P", nfi) + "\r\n" +
                "Decision Error: " + (1 - accuracy).ToString("P", nfi) + "\r\n" +
                "Normalized Decision Error: " + ((1 - accuracy) / 36).ToString("P", nfi) + "\r\n";      return testStats + "\r\n";
        }

        private void buttonLoadImageFromFile_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Please select a .bmp image to open.";
            openFileDialog.Filter = "BMP|*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                CharacterImage img = DataLoader.LoadFromBMP(fileName);
                selectCharacterImage(img);
            }
        }

        private void comboBoxFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            setupCharacterSelectionMaximum();
            numericUpDownCharacters.Value = 0;
            selectCharacterImageFromDataset();
        }

        private void setupCharacterSelectionMaximum()
        {
            if (radioButtonAllData.Checked)
                numericUpDownCharacters.Maximum = DataSet.ImagesByFontFamily[comboBoxFonts.SelectedItem.ToString()].Count - 1;
            else if (radioButtonTestSet.Checked)
                numericUpDownCharacters.Maximum = TestSet.ImagesByFontFamily[comboBoxFonts.SelectedItem.ToString()].Count - 1;
            else if (radioButtonTrainingSet.Checked)
                numericUpDownCharacters.Maximum = TrainingSet.ImagesByFontFamily[comboBoxFonts.SelectedItem.ToString()].Count - 1;
        }

        private void numericUpDownCharacters_ValueChanged(object sender, EventArgs e)
        {
            selectCharacterImageFromDataset();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxFonts.SelectedIndex = 0;
            setupCharacterSelectionMaximum();
            numericUpDownCharacters.Value = 0;
            selectCharacterImageFromDataset();
            updateDataStatisctics();
        }

        private void selectCharacterImageFromDataset()
        {
            string fontFamily = comboBoxFonts.SelectedItem.ToString();
            int characterNumber = decimal.ToInt32(numericUpDownCharacters.Value);

            if (radioButtonAllData.Checked)
            {
                if (DataSet != null && DataSet.ImagesByFontFamily.ContainsKey(fontFamily) && DataSet.ImagesByFontFamily[fontFamily].Count > characterNumber)
                    selectCharacterImage(DataSet.ImagesByFontFamily[fontFamily][characterNumber]);
            }
            else if (radioButtonTestSet.Checked)
            {
                if (TestSet != null && TestSet.ImagesByFontFamily.ContainsKey(fontFamily) && TestSet.ImagesByFontFamily[fontFamily].Count > characterNumber)
                    selectCharacterImage(TestSet.ImagesByFontFamily[fontFamily][characterNumber]);
            }
            else if (radioButtonTrainingSet.Checked)
            {
                if (TrainingSet != null && TrainingSet.ImagesByFontFamily.ContainsKey(fontFamily) && TrainingSet.ImagesByFontFamily[fontFamily].Count > characterNumber)
                    selectCharacterImage(TrainingSet.ImagesByFontFamily[fontFamily][characterNumber]);
            }
        }

        private void selectCharacterImage(CharacterImage image)
        {
            selectedCharacterImage = image;
            //Recognize Image
            recognize(image);
            
            if (image != null)
            {
                //Display info
                textBoxSelectedCharacterInfo.Text =
                    "FontFamily: " + image.FontFamily + "\r\n" +
                    "FontVariant: " + image.FontVariant + "\r\n" +
                    "Label: " + image.Label + "\r\n" +
                    "Italic: " + image.Italic + "\r\n" +
                    "Strength: " + image.Strength + "\r\n";
                //Display Image
                Bitmap bitmap = new Bitmap(image.Width, image.Height);
                for (int y = 0; y < image.Height; y++)
                    for (int x = 0; x < image.Width; x++)
                    {
                        int grayscaleValue = image.Pixels[y * image.Width + x];
                        bitmap.SetPixel(x, y, Color.FromArgb(255, grayscaleValue, grayscaleValue, grayscaleValue));
                    }
                pictureBox.Image = resizeBitmap(bitmap, image.Width * 8, image.Height * 8);
            }
            else
            {
                textBoxSelectedCharacterInfo.Text = "Cannot read character image.";
                pictureBox.Image = null;
            }
        }

        private Bitmap resizeBitmap(Image original, int width, int height)
        {
            Bitmap resizedBmp = new Bitmap(width, height);
            using (Graphics gr = Graphics.FromImage(resizedBmp))
            {
                gr.InterpolationMode = InterpolationMode.NearestNeighbor;
                gr.DrawImage(original, new Rectangle(0, 0, width, height));
            }
            return resizedBmp;
        }

        private void recognize(CharacterImage image)
        {
            if (image == null)
            {
                textBoxPresetRecognition.Text = "Cannot read character image.";
                textBoxCustomRecognition.Text = "Cannot read character image.";
                return;
            }

            //Recognize in PresetNeuralNetwork
            if (PresetNeuralNetwork != null)
                textBoxPresetRecognition.Text = "Correct label: " + image.Label + "\r\n" + "Recognized label: " + PresetNeuralNetwork.Recognize(image);
            else
                textBoxPresetRecognition.Text = "Preset Neural Network not created.";

            //Recognize in CustomNeuralNetwork
            if (CustomNeuralNetwork != null)
                textBoxCustomRecognition.Text = "Correct label: " + image.Label + "\r\n" + "Recognized label: " + CustomNeuralNetwork.Recognize(image);
            else
                textBoxCustomRecognition.Text = "Custom Neural Network not created.";
        }

        private void buttonCreateCustomNetwork_Click(object sender, EventArgs e)
        {
            int inputLayerSize = decimal.ToInt32(numericUpDownInputLayerSize.Value);
            int hiddenLayerSize = decimal.ToInt32(numericUpDownHiddenLayerSize.Value);
            int outputLayerSize = decimal.ToInt32(numericUpDownOutputLayerSize.Value);
            double eta = decimal.ToDouble(numericUpDownLearningRateEta.Value);

            CustomNeuralNetwork = new NeuralNetworkUCI(eta, hiddenLayerSize);
            textBoxCustomNeuralNetwork.Text =
                    "Custom Neural Network:\r\n" +
                    CustomNeuralNetwork.GetInfo() + "\r\n" +
                    testNeuralNetwork(CustomNeuralNetwork);
            buttonTrainCustomNetwork.Enabled = true;
            selectCharacterImage(selectedCharacterImage);
        }

        private void buttonTrainCustomNetwork_Click(object sender, EventArgs e)
        {
            buttonTrainCustomNetwork.Enabled = false;
            trainNeuralNetwork(CustomNeuralNetwork);
            textBoxCustomNeuralNetwork.Text =
                    "Custom Neural Network:\r\n" +
                    CustomNeuralNetwork.GetInfo() + "\r\n" +
                    testNeuralNetwork(CustomNeuralNetwork);
            selectCharacterImage(selectedCharacterImage);
        }


    }
}

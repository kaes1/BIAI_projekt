using System;
using System.IO;
using System.Linq;
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
        private NeuralNetwork PresetNeuralNetwork;
        private NeuralNetwork CustomNeuralNetwork;

        private CharacterImage selectedCharacterImage;

        public MainForm()
        {
            InitializeComponent();

            //Load data.
            DataSet = DataLoader.LoadDataSet(@"G:\Studia\BIAI\UCI");
            //Display data statistics.
            string stats = "Total count: " + DataSet.Images.Count + ", Characters: " + DataSet.ImagesByCharacter.Count + ", Fonts: " + DataSet.ImagesByFontFamily.Count + "\r\n\r\n";
            foreach (KeyValuePair<char, List<CharacterImage>> pair in DataSet.ImagesByCharacter)
                stats += pair.Key + ": " + pair.Value.Count + "\t";
            textBoxDataSetStatistics.Text = stats;
            //Setup font selection combo box.
            comboBoxFonts.DataSource = new List<string>(DataSet.ImagesByFontFamily.Keys);
            //Load preset network
            loadPresetNeuralNetwork(); 
        }

        private void loadPresetNeuralNetwork()
        {
            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(NeuralNetworkState));
            if (File.Exists(@"G:\Studia\BIAI\presetNN.xml"))
            {
                var file = new StreamReader(@"G:\Studia\BIAI\presetNN.xml");
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

        //private void saveNeuralNetwork(NeuralNetwork nn)
        //{
        //    //save 
        //    System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(NeuralNetworkState));
        //    var wfile = new StreamWriter(@"G:\Studia\BIAI\savedNN.xml");
        //    writer.Serialize(wfile, nn.GetNeuralNetworkState());
        //    wfile.Close();
        //}

        private void trainNeuralNetwork(NeuralNetwork nn)
        {
            nn.Train(DataSet.Images);
        }

        private string testNeuralNetwork(NeuralNetwork nn)
        {
            if (nn == null)
                return null;

            int allImages = DataSet.Images.Count;
            int successfullyRecognized = 0;
            foreach (CharacterImage image in DataSet.Images)
                if (nn.Recognize(image) == image.Label)
                    successfullyRecognized++;
            double accuracy = (double)successfullyRecognized / (double)allImages;
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.PercentDecimalDigits = 4;
            return "Accuracy: " + accuracy.ToString("P", nfi) + "\r\n" +
                "Decision Error: " + (1 - accuracy).ToString("P", nfi) + "\r\n" +
                "Normalized Decision Error: " + ((1 - accuracy) / 36).ToString("P", nfi);
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
            numericUpDownCharacters.Maximum = DataSet.ImagesByFontFamily[comboBoxFonts.SelectedItem.ToString()].Count - 1;
            numericUpDownCharacters.Value = 0;
            selectCharacterImageFromDataset();
        }

        private void numericUpDownCharacters_ValueChanged(object sender, EventArgs e)
        {
            selectCharacterImageFromDataset();
        }

        private void selectCharacterImageFromDataset()
        {
            string fontFamily = comboBoxFonts.SelectedItem.ToString();
            int characterNumber = decimal.ToInt32(numericUpDownCharacters.Value);
            if (DataSet != null && DataSet.ImagesByFontFamily.ContainsKey(fontFamily) && DataSet.ImagesByFontFamily[fontFamily].Count > characterNumber)
                selectCharacterImage(DataSet.ImagesByFontFamily[fontFamily][characterNumber]);
        }

        private void selectCharacterImage(CharacterImage image)
        {
            selectedCharacterImage = image;
            //Recognize Image
            recognize(selectedCharacterImage);
            
            if (selectedCharacterImage != null)
            {
                //Display info
                textBoxSelectedCharacterInfo.Text =
                    "FontFamily: " + selectedCharacterImage.FontFamily + "\r\n" +
                    "FontVariant: " + selectedCharacterImage.FontVariant + "\r\n" +
                    "Label: " + selectedCharacterImage.Label + "\r\n" +
                    "Italic: " + selectedCharacterImage.Italic + "\r\n" +
                    "Strength: " + selectedCharacterImage.Strength + "\r\n";
                //Display Image
                Bitmap bitmap = new Bitmap(selectedCharacterImage.Width, selectedCharacterImage.Height);
                for (int y = 0; y < selectedCharacterImage.Height; y++)
                    for (int x = 0; x < selectedCharacterImage.Width; x++)
                    {
                        int grayscaleValue = selectedCharacterImage.Pixels[y * selectedCharacterImage.Width + x];
                        bitmap.SetPixel(x, y, Color.FromArgb(255, grayscaleValue, grayscaleValue, grayscaleValue));
                    }
                pictureBox.Image = resizeBitmap(bitmap, selectedCharacterImage.Width * 8, selectedCharacterImage.Height * 8);
            }
            else
            {
                textBoxSelectedCharacterInfo.Text = "Cannot read character image.";
                pictureBox.Image = null;
            }
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

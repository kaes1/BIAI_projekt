using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing.Drawing2D;

namespace NumberRecognizerDesktop
{
    public partial class MainForm : Form
    {
        List<NeuralNetwork> neuralNetworks;
        DataSet dataSet;

        CharacterImage imageActiveInData;
        //CharacterImage imageActiveInRecognize;

        public MainForm()
        {
            InitializeComponent();

            //Load data.
            dataSet = DataLoader.LoadDataSetLetters(@"G:\Studia\BIAI\UCI");
            //Display data statistics.
            string stats = "Total count: " + dataSet.Images.Count + ", Distinct characters: " + dataSet.ImagesByCharacter.Count + "\r\n\r\n";
            foreach(KeyValuePair<char, List<CharacterImage>> pair in dataSet.ImagesByCharacter)
                stats += pair.Key + ": " + pair.Value.Count + "\t";
            textBoxDataSetStatistics.Text = stats;
            //Setup font selection combo box.
            comboBoxFonts.DataSource = new List<string>(dataSet.ImagesByFontFamily.Keys);

            //Create networks.
            neuralNetworks = new List<NeuralNetwork>();
            //neuralNetworks.Add(new NeuralNetworkUCI(0.1, 20));
            //neuralNetworks.Add(new NeuralNetworkUCI(0.1, 40));
            //neuralNetworks.Add(new NeuralNetworkLetters(0.1, 20));
            //neuralNetworks.Add(new NeuralNetworkLetters(0.1, 40));
            neuralNetworks.Add(new NeuralNetworkLetters(0.1, 60));
            //neuralNetworks.Add(new NeuralNetworkLetters(0.1, 60));
            //neuralNetworks.Add(new NeuralNetworkLetters(0.1, 100));

            //Train networks.
            //trainNeuralNetworks();

            //SAVE BEST NETWORK?
            double[] weights = neuralNetworks[0].GetWeightsForSaving();
            //neuralNetworks[1].LoadWeightsFromSave(weights);
            Stream SaveFileStream = File.Create(@"G:\Studia\BIAI\saved_weights.bin");
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter serializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            serializer.Serialize(SaveFileStream, weights);
            SaveFileStream.Close();


            NeuralNetwork testNN = new NeuralNetworkLetters(0.1, 60);
            if (File.Exists(@"G:\Studia\BIAI\saved_weights.bin"))
            {
                Stream openFileStream = File.OpenRead(@"G:\Studia\BIAI\saved_weights.bin");
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter deserializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                double[] weightsFromFile = (double[])deserializer.Deserialize(openFileStream);
                testNN.LoadWeightsFromSave(weightsFromFile);
                openFileStream.Close();
            }

            neuralNetworks.Add(testNN);

            

            //Test networks
            testNeuralNetworks();

            
        }


        private void trainNeuralNetworks()
        {
            foreach (NeuralNetwork nn in neuralNetworks)
            {
                nn.Train(dataSet.Images);
            }
        }

        private void testNeuralNetworks()
        {
            string testsText = "";
            if (neuralNetworks.Count > 0)
            {
                for (int i = 0; i < neuralNetworks.Count; i++)
                {
                    NeuralNetwork nn = neuralNetworks[i];

                    int successfulCount = 0;
                    int allCount = dataSet.Images.Count;
                    foreach(CharacterImage image in dataSet.Images)
                    {
                        char recognizedLabel = nn.Recognize(image);
                        if (recognizedLabel == image.Label)
                            successfulCount++;
                    }
                    double accuracy = (double)successfulCount / (double)allCount;
                    NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
                    nfi.PercentDecimalDigits = 4;
                    testsText += "NN" + (i+1) + ", eta=" + nn.GetLearningRateEta() + ", hiddenLayerSize=" + nn.GetHiddenLayerSize() 
                        + ", Accuracy=" + accuracy.ToString("P",nfi) + "\r\n";
                }
            }
            else
                testsText = "No neural networks created.";
            textBoxTests.Text = testsText;
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

        private void comboBoxFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericUpDownCharacters.Maximum = dataSet.ImagesByFontFamily[comboBoxFonts.SelectedItem.ToString()].Count - 1;
            numericUpDownCharacters.Value = 0;
            numericUpDownCharacters.Value = numericUpDownCharacters.Maximum;
        }

        private void numericUpDownCharacters_ValueChanged(object sender, EventArgs e)
        {
            string fontFamily = comboBoxFonts.SelectedItem.ToString();
            int characterNumber = decimal.ToInt32(numericUpDownCharacters.Value);

            if (dataSet != null && dataSet.ImagesByFontFamily.ContainsKey(fontFamily) && dataSet.ImagesByFontFamily[fontFamily].Count > characterNumber)
            {
                imageActiveInData = dataSet.ImagesByFontFamily[fontFamily][characterNumber];
                displayCharacterInData(imageActiveInData);
                string info = "";
                info += "FontFamily: " + imageActiveInData.FontFamily + "\r\n";
                info += "FontVariant: " + imageActiveInData.FontVariant + "\r\n";
                info += "Label: " + imageActiveInData.Label + "\r\n";
                info += "Italic: " + imageActiveInData.Italic + "\r\n";
                info += "Strength: " + imageActiveInData.Strength + "\r\n";
                textBoxSelectedCharacterInfo.Text = info;
                if (checkBoxAutoRecognize.Checked)
                {
                    Recognize(imageActiveInData);
                }
                else
                {
                    buttonRecognizeFromData.Enabled = true;
                }
            }
            else
            {
                textBoxSelectedCharacterInfo.Text = "Cannot read character.\r\n";
                displayCharacterInData(null);
                buttonRecognizeFromData.Enabled = false;
            }
        }


        private void displayCharacterInData(CharacterImage image)
        {
            if (image != null)
            {
                //Create bitmap
                Bitmap bitmap = new Bitmap(image.Width, image.Height);
                for (int y = 0; y < image.Height; y++)
                    for (int x = 0; x < image.Width; x++)
                    {
                        int grayscaleValue = image.Pixels[y * image.Width + x];
                        bitmap.SetPixel(x, y, Color.FromArgb(255, grayscaleValue, grayscaleValue, grayscaleValue));
                    }
                //Display image on picture boxes.
                pictureBoxData.Image = resizeBitmap(bitmap, image.Width * 8, image.Height * 8);
            }
            else
                pictureBoxData.Image = null;
        }

        private void displayCharacterInRecognize(CharacterImage image)
        {
            if (image != null)
            {
                //Create bitmap
                Bitmap bitmap = new Bitmap(image.Width, image.Height);
                for (int y = 0; y < image.Height; y++)
                    for (int x = 0; x < image.Width; x++)
                    {
                        int grayscaleValue = image.Pixels[y * image.Width + x];
                        bitmap.SetPixel(x, y, Color.FromArgb(255, grayscaleValue, grayscaleValue, grayscaleValue));
                    }
                pictureBoxRecognize.Image = resizeBitmap(bitmap, image.Width * 8, image.Height * 8);
            }
            else
                pictureBoxRecognize.Image = null;
        }

        private void buttonRecognize_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                CharacterImage img = DataLoader.LoadFromBMP(fileName);
                Recognize(img);
            }
        }

        private void buttonRecognizeFromData_Click(object sender, EventArgs e)
        {
            if (imageActiveInData != null)
                Recognize(imageActiveInData);
        }

        private void Recognize(CharacterImage imageToRecognize)
        {
            string recognizedText = "Cannot use that image.";
            if (imageToRecognize != null)
            {
                displayCharacterInRecognize(imageToRecognize);
                recognizedText = "Expected result: " + imageToRecognize.Label + "\r\n";
                if (neuralNetworks != null && neuralNetworks.Count > 0)
                {
                    for (int i = 0; i < neuralNetworks.Count; i++)
                    {
                        char recognized = neuralNetworks[i].Recognize(imageToRecognize);
                        recognizedText += "NN" + (i + 1) + ": " + recognized + "\r\n";
                    }
                }
                else
                    recognizedText += "No neural networks created.";
            }
            textBoxRecognized.Text = recognizedText;
        }

        private void checkBoxAutoRecognize_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAutoRecognize.Checked)
            {
                buttonRecognizeFromData.Enabled = false;
            }
            else
            {
                buttonRecognizeFromData.Enabled = true;
            }
        }
    }
}

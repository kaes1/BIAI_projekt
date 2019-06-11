using System;
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
        List<List<CharacterImageUCI>> DataSetsByFonts;
        List<CharacterImageUCI> DataSet;
        List<NeuralNetworkUCI> neuralNetworks;
        List<NeuralNetworkDigits> neuralNetworksDigits;
        //Test image
        //CharacterImage testMyImage;

        public MainForm()
        {
            InitializeComponent();

            //Load data.
            DataSetsByFonts = DataLoader.LoadUciCsvByFonts(@"C:\Users\Aleksandra\Documents\GitHub\fonts");
            DataSet = new List<CharacterImageUCI>();
            foreach (List<CharacterImageUCI> set in DataSetsByFonts)
                foreach (CharacterImageUCI characterImage in set)
                    DataSet.Add(characterImage);

            //Get data statistics.
            var g = DataSet.GroupBy(characterImage => characterImage.Label);
            

            textBoxDataSetStatistics.Text = "DataSet Statistics.\r\n";
            foreach (var grp in g)
            {
                //Console.WriteLine("{0} {1}", grp.Key, grp.Count());
                textBoxDataSetStatistics.AppendText(grp.Key + " " + grp.Count() + "\r\n");
            }
            

            //Create networks.
            //neuralNetworks = new List<NeuralNetworkUCI>();
            //neuralNetworks.Add(new NeuralNetworkUCI(0.1, 20));
            neuralNetworksDigits = new List<NeuralNetworkDigits>();
            neuralNetworksDigits.Add(new NeuralNetworkDigits(0.1, 20));


            //Train networks.
            trainNeuralNetworks();

            //Test networks
            testNeuralNetworks();

            //Setup GUI
            List<string> fontNames = new List<string>();
            foreach(var dataset in DataSetsByFonts)
                fontNames.Add(dataset[0].GetFontFamily());
            comboBoxFonts.DataSource = fontNames;

            //Test image loading
            //testMyImage = DataLoader.LoadFromBMP(@"G:\TEST_PIC.bmp");
            //displayTestCharacter(testMyImage);

        }


        private void trainNeuralNetworks()
        {
            //foreach (NeuralNetworkUCI nn in neuralNetworks)
            //    foreach (var dataset in DataSetsByFonts)
            //    {
            //        nn.Train(dataset);
            //        nn.Train(dataset);
            //        //nn.Train(dataset);
            //        //nn.Train(dataset);
            //        //nn.Train(dataset);
            //        //nn.Train(dataset);
            //        //nn.Train(dataset);
            //    }

            foreach (NeuralNetworkDigits nn in neuralNetworksDigits)
            {
                nn.Train(DataSet);
                nn.Train(DataSet);
            }
        }

        private void testNeuralNetworks()
        {
            textBoxTests.Text = "";
            //foreach (NeuralNetworkUCI nn in neuralNetworks)
            //{
            //    int successfulCount = 0;
            //    int allCount = 0;
            //    foreach (var dataset in DataSetsByFonts)
            //        foreach (CharacterImageUCI image in dataset)
            //        {
            //            char recognizedLabel = nn.Recognize(image);
            //            char correctLabel = image.Label;
            //            allCount++;
            //            if (recognizedLabel == correctLabel)
            //                successfulCount++;
            //        }
            //    double accuracy = (double)successfulCount / (double)allCount;
            //    NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            //    nfi.PercentDecimalDigits = 4;
            //    textBoxTests.AppendText("Neural Network with hidden neurons = " + nn.GetHiddenLayerSize() + ", eta = " + nn.GetLearningRateEta() + ". Accuracy: " + accuracy.ToString("P", nfi) + "\r\n");
            //}

            foreach (NeuralNetworkDigits nn in neuralNetworksDigits)
            {
                int successfulCount = 0;
                int allCount = 0;
                foreach (var dataset in DataSetsByFonts)
                    foreach (CharacterImageUCI image in dataset)
                    {
                        char recognizedLabel = nn.Recognize(image);
                        char correctLabel = image.Label;
                        allCount++;
                        if (recognizedLabel == correctLabel)
                            successfulCount++;
                    }
                double accuracy = (double)successfulCount / (double)allCount;
                NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
                nfi.PercentDecimalDigits = 4;
                textBoxTests.AppendText("Neural Network with hidden neurons = " + nn.GetHiddenLayerSize() + ", eta = " + nn.GetLearningRateEta() + ". Accuracy: " + accuracy.ToString("P", nfi) + "\r\n");
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


        private void SelectedCharacterChanged(object sender, EventArgs e)
        {
            int fontNumber = comboBoxFonts.SelectedIndex;
            int characterNumber = decimal.ToInt32(numericUpDownCharacters.Value);

            if (DataSetsByFonts != null && DataSetsByFonts.Count > fontNumber && DataSetsByFonts[fontNumber].Count > characterNumber)
            {
                numericUpDownCharacters.Maximum = DataSetsByFonts[fontNumber].Count - 1;
                displayCharacter(DataSetsByFonts[fontNumber][characterNumber]);
                textBoxSelectedCharacterInfo.Text = "FontFamily = " + DataSetsByFonts[fontNumber][characterNumber].GetFontFamily() + "\r\n";
                textBoxSelectedCharacterInfo.AppendText("FontVariant = " + DataSetsByFonts[fontNumber][characterNumber].GetFontVariant() + "\r\n");
                textBoxSelectedCharacterInfo.AppendText("NumberOfCharacters = " + DataSetsByFonts[fontNumber].Count + "\r\n");
                textBoxSelectedCharacterInfo.AppendText("Label = " + DataSetsByFonts[fontNumber][characterNumber].Label + "\r\n");
                textBoxSelectedCharacterInfo.AppendText("Italic = " + DataSetsByFonts[fontNumber][characterNumber].italic + "\r\n");
                textBoxSelectedCharacterInfo.AppendText("Strength = " + DataSetsByFonts[fontNumber][characterNumber].strength + "\r\n");

                textBoxRecognized.Text = "Results for all neural networks:\r\n";
                //foreach(NeuralNetworkUCI nn in neuralNetworks)
                  //  textBoxRecognized.AppendText("Recognized: " + nn.Recognize(DataSetsByFonts[fontNumber][characterNumber]) + "\r\n");
                foreach (NeuralNetworkDigits nn in neuralNetworksDigits)
                    textBoxRecognized.AppendText("Recognized: " + nn.Recognize(DataSetsByFonts[fontNumber][characterNumber]) + "\r\n");

            }
            else
            {
                textBoxSelectedCharacterInfo.Text = "Cannot read character.\r\n";
                textBoxRecognized.Text = "Cannot read characted.\r\n";
                displayCharacter(null);
            }
        }

        private void displayCharacter(CharacterImage image)
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
                pictureBox1.Image = bitmap;
                pictureBox2.Image = resizeBitmap(bitmap, image.Width * 2, image.Height * 2);
                pictureBox3.Image = resizeBitmap(bitmap, image.Width * 4, image.Height * 4);
                pictureBox4.Image = resizeBitmap(bitmap, image.Width * 8, image.Height * 8);

            }
            else
                pictureBox1.Image = pictureBox2.Image = pictureBox3.Image = pictureBox4.Image = null;
            
        }

        private void displayTestCharacter(CharacterImage image)
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
                pictureBoxTest1.Image = bitmap;
                pictureBoxTest2.Image = resizeBitmap(bitmap, image.Width * 2, image.Height * 2);
                pictureBoxTest3.Image = resizeBitmap(bitmap, image.Width * 4, image.Height * 4);
                pictureBoxTest4.Image = resizeBitmap(bitmap, image.Width * 8, image.Height * 8);
            }
            else
                pictureBoxTest1.Image = pictureBoxTest2.Image = pictureBoxTest3.Image = pictureBoxTest4.Image = null;
        }
    }
}

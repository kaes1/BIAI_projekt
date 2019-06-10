using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing.Drawing2D;

namespace NumberRecognizerDesktop
{
    public partial class MainForm : Form
    {
        List<List<CharacterImageUCI>> DataSets;
        List<NeuralNetworkUCI> neuralNetworks;

        //int characterCount = 0;
   
        public MainForm()
        {
            InitializeComponent();

            //Load data.
            DataSets = DataLoader.LoadUciCsv(@"G:\Studia\BIAI\UCI");

            //foreach (var dataset in DataSets)
            //    foreach(CharacterImage img in dataset)
            //        characterCount++;

            //Create networks.
            //neuralNetworks = new List<NeuralNetworkUCI>();
           // neuralNetworks.Add(new NeuralNetworkUCI(3.0, 25));
            //neuralNetworks.Add(new NeuralNetworkUCI(3.0, 100));

            /*//Train networks.
            foreach (NeuralNetworkUCI nn in neuralNetworks)
                foreach (var dataset in DataSets)
                    nn.Train(dataset);*/

            /*
            //Test networks
            textBoxTests.Text = "";
            textBoxTests.AppendText("Character count: " + characterCount + "\n");
            foreach (NeuralNetworkUCI nn in neuralNetworks)
            {
                int successfulCount = 0;
                int allCount = 0;
                foreach (var dataset in DataSets)
                {
                    foreach (CharacterImageUCI image in dataset)
                    {
                        char recognizedLabel = nn.Recognize(image);
                        char correctLabel = image.Label;
                        allCount++;
                        if (recognizedLabel == correctLabel)
                            successfulCount++;
                    }
                }
                double accuracy = (double)successfulCount / allCount;
                NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
                nfi.PercentDecimalDigits = 4;
                textBoxTests.AppendText("Neural Network with hidden neurons = " + nn.GetHiddenLayerSize() + ", eta = " + nn.GetLearningRateEta() + "\n");
                textBoxTests.AppendText("Accuracy: " + accuracy.ToString("P", nfi) + "Recognized: \t" + successfulCount + "\n");
                textBoxTests.AppendText("====================================================" + "\n");
            }*/



            //Setup GUI
            List<string> fontNames = new List<string>();
            foreach(var dataset in DataSets)
                fontNames.Add(dataset[0].GetFontFamily());
            comboBoxFonts.DataSource = fontNames;
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

            if (DataSets != null && DataSets.Count > fontNumber && DataSets[fontNumber].Count > characterNumber)
            {
                numericUpDownCharacters.Maximum = DataSets[fontNumber].Count - 1;
                displayCharacter(DataSets[fontNumber][characterNumber]);
                textBoxSelectedCharacterInfo.Text = "FontFamily = " + DataSets[fontNumber][characterNumber].GetFontFamily() + '\n';
                textBoxSelectedCharacterInfo.AppendText("FontVariant = " + DataSets[fontNumber][characterNumber].GetFontVariant() + '\n');
                textBoxSelectedCharacterInfo.AppendText("NumberOfCharacters = " + DataSets[fontNumber].Count + '\n');
                textBoxSelectedCharacterInfo.AppendText("Label = " + DataSets[fontNumber][characterNumber].Label + '\n');
            }
            else
            {
                textBoxSelectedCharacterInfo.Text = "Cannot read character.\n";
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
            {
                pictureBox1.Image = null;
                pictureBox2.Image = null;
                pictureBox3.Image = null;
                pictureBox4.Image = null;
            }
            
        }
    }
}

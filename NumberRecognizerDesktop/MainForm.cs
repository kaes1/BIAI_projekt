using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing.Drawing2D;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace NumberRecognizerDesktop
{
    public partial class MainForm : Form
    {
        List<CharacterImageMNIST> MNIST_TestSet;
        List<CharacterImageMNIST> MNIST_TrainingSet;
        List<List<CharacterImageUCI>> UCI_Sets;
        List<NeuralNetworkMNIST> neuralNetworksMNIST;
        List<NeuralNetworkUCI> neuralNetworksUCI;

        int characterCount = 0;

        public MainForm()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            pictureBox2.SizeMode = PictureBoxSizeMode.Normal;
            pictureBox3.SizeMode = PictureBoxSizeMode.Normal;
            pictureBox4.SizeMode = PictureBoxSizeMode.Normal;

            //List of training digit images.
            //MNIST_TrainingSet = DataLoader.LoadFromCSV(@"G:\Studia\BIAI\MNIST in csv\mnist_train.csv");
            //List of test digit images.
            //MNIST_TestSet = DataLoader.LoadFromFileCSV_MNIST(@"G:\Studia\BIAI\MNIST in csv\mnist_test.csv");

            UCI_Sets = DataLoader.LoadFromFolderCSV_UCI(@"G:\Studia\BIAI\UCI");

            foreach (var dataset in UCI_Sets)
                foreach(CharacterImage img in dataset)
                    characterCount++;
            textBoxMain.Text = "CharacterCount = " + characterCount;


            //Create networks.
            //neuralNetworks = new List<NeuralNetworkMNIST>();
            //neuralNetworks.Add(new NeuralNetworkMNIST(2.0));
            //neuralNetworks.Add(new NeuralNetwork(3.0));
            //neuralNetworks.Add(new NeuralNetwork(4.0));
            //neuralNetworks.Add(new NeuralNetwork(5.0));
            neuralNetworksUCI = new List<NeuralNetworkUCI>();
            neuralNetworksUCI.Add(new NeuralNetworkUCI(3.0, 15));
            neuralNetworksUCI.Add(new NeuralNetworkUCI(3.0, 20));
            neuralNetworksUCI.Add(new NeuralNetworkUCI(3.0, 25));
            neuralNetworksUCI.Add(new NeuralNetworkUCI(3.0, 30));

            foreach (NeuralNetworkUCI nn in neuralNetworksUCI)
                foreach (var dataset in UCI_Sets)
                {
                    nn.Train(dataset);
                    nn.Train(dataset);
                    nn.Train(dataset);
                    nn.Train(dataset);
                }

            //Test networks
            textBoxTests.Text = "";
            textBoxTests.AppendText("Character count: " + characterCount + "\n");
            foreach (NeuralNetworkUCI nn in neuralNetworksUCI)
            {
                int successfulCount = 0;
                int allCount = 0;
                foreach (var dataset in UCI_Sets)
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
            }

            numericUpDownSelectFont.Maximum = UCI_Sets.Count - 1;
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

        private void displayCharacter(CharacterImage image)
        {
            //Create bitmap
            Bitmap bitmap = new Bitmap(image.Width, image.Height);
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    int grayscaleValue = image.Pixels[y * image.Width + x];
                    bitmap.SetPixel(x, y, Color.FromArgb(255, grayscaleValue, grayscaleValue, grayscaleValue));
                }
            }

            //Display image on picture boxes.
            pictureBox1.Image = bitmap;
            pictureBox2.Image = resizeBitmap(bitmap, image.Width * 2, image.Height * 2);
            pictureBox3.Image = resizeBitmap(bitmap, image.Width * 4, image.Height * 4);
            pictureBox4.Image = resizeBitmap(bitmap, image.Width * 8, image.Height * 8);
        }

        private void buttonDisplayMNIST_Click(object sender, EventArgs e)
        {
            int i = decimal.ToInt32(numericUpDownSelectMNIST.Value);
            displayCharacter(MNIST_TestSet[i]);
        }

        private void buttonDisplayUCI_Click(object sender, EventArgs e)
        {
            int fontNumber = decimal.ToInt32(numericUpDownSelectFont.Value);
            int characterNumber = decimal.ToInt32(numericUpDownSelectCharacter.Value);

            displayCharacter(UCI_Sets[fontNumber][characterNumber]);
            textBoxMain.Text = "FontFamily = " + UCI_Sets[fontNumber][characterNumber].GetFontFamily() +  '\n';
            textBoxMain.AppendText("FontVariant = " + UCI_Sets[fontNumber][characterNumber].GetFontVariant() + '\n');
            textBoxMain.AppendText("NumberOfCharacters = " + UCI_Sets[fontNumber].Count + '\n');
            textBoxMain.AppendText("Label = " + UCI_Sets[fontNumber][characterNumber].Label + '\n');
            if (neuralNetworksUCI.Count > 0)
                textBoxMain.AppendText("Recognized label = " + neuralNetworksUCI[0].Recognize(UCI_Sets[fontNumber][characterNumber]) + '\n');

                
        }

        private void numericUpDownSelectFont_ValueChanged(object sender, EventArgs e)
        {
            int fontNumber = decimal.ToInt32(numericUpDownSelectFont.Value);
            numericUpDownSelectCharacter.Maximum = UCI_Sets[fontNumber].Count - 1;
        }
    }
}

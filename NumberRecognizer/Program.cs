using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace NumberRecognizer
{
    class Program
    {
        static void Main(string[] args)
        {
            //List of training digit images.
            List<CharacterImage> trainingSet = DataLoader.LoadFromCSV(@"G:\Studia\BIAI\MNIST in csv\mnist_train.csv");
            
            //List of test digit images.
            List<CharacterImage> testSet = DataLoader.LoadFromCSV(@"G:\Studia\BIAI\MNIST in csv\mnist_test.csv");

            //Create networks.
            List<NeuralNetwork> neuralNetworks = new List<NeuralNetwork>();
            neuralNetworks.Add(new NeuralNetwork(2.0));
            neuralNetworks.Add(new NeuralNetwork(3.0));
            neuralNetworks.Add(new NeuralNetwork(4.0));
            neuralNetworks.Add(new NeuralNetwork(5.0));

            //Train networks
            foreach (NeuralNetwork nn in neuralNetworks)
            {
                nn.Train(trainingSet);
                nn.Train(trainingSet);
                nn.Train(trainingSet);

            }
                

            //Test networks
            foreach(NeuralNetwork nn in neuralNetworks)
            {
                int successfulCount = 0;
                int allCount = 0;
                foreach (CharacterImage image in testSet)
                {
                    char recognizedLabel = nn.Recognize(image).ToString()[0];
                    char correctLabel = image.GetLabel();
                    allCount++;
                    if (recognizedLabel == correctLabel)
                        successfulCount++;
                }
                double accuracy = (double)successfulCount / allCount;
                NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
                nfi.PercentDecimalDigits = 4;
                Console.WriteLine("Neural Network number with eta = " + nn.GetLearningRateEta());
                Console.WriteLine("All images: \t\t\t" + allCount);
                Console.WriteLine("Successfully recognized: \t" + successfulCount);
                Console.WriteLine("Accuracy: " + accuracy.ToString("P", nfi));
                Console.WriteLine("=========================================================");
            }

            Console.ReadLine();
        }
    }
}

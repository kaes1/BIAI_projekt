using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterRecognizer
{
    class NeuralNetworkUCI : NeuralNetwork
    {
        //Output neurons 0-9 represent '0'-'9', neurons 10-35 represent A-Z.
        public NeuralNetworkUCI(double learningRateEta, int hiddenLayerSize) : base(400, hiddenLayerSize, 36, learningRateEta) { }

        public NeuralNetworkUCI(NeuralNetworkState savedState) : base(savedState) { }

        override public char Recognize(CharacterImage image)
        {
            inputs = image.NormalizedPixels;

            double[] hiddenLayerOutputs = new double[hiddenLayer.Length];
            for (int i = 0; i < hiddenLayer.Length; i++)
                hiddenLayerOutputs[i] = hiddenLayer[i].CalculateOutput(inputs);

            double[] outputLayerOutputs = new double[outputLayer.Length];
            for (int i = 0; i < outputLayer.Length; i++)
                outputLayerOutputs[i] = outputLayer[i].CalculateOutput(hiddenLayerOutputs);

            //Find most probable output.
            double max = outputLayerOutputs.Max();
            int mostProbableIndex = Array.IndexOf(outputLayerOutputs, max);
            //Return guessed digit or letter.
            if (mostProbableIndex < 10)
                return (char)('0' + mostProbableIndex);
            else
                return (char)('A' + mostProbableIndex - 10);
        }

        override public void Train(List<CharacterImage> dataset)
        {
            foreach (CharacterImage image in dataset)
            {
                //Desired output is neuron corresponding to the digit label outputs 1.0, the rest outputs 0.0.
                double[] desiredOutputs = new double[OutputLayerSize];
                if (image.Label >= '0' && image.Label <= '9')
                    desiredOutputs[image.Label - '0'] = 1.0;
                else if (image.Label >= 'A' && image.Label <= 'Z')
                    desiredOutputs[image.Label - 'A' + 10] = 1.0;

                //Run image through the neural network.
                Recognize(image);

                //Backpropagation.
                //Calculate generalized deltas for output layer.
                double[] outputLayerGeneralizedDeltas = new double[outputLayer.Length];
                for (int i = 0; i < outputLayer.Length; i++)
                {
                    double delta = 1.0 * (desiredOutputs[i] - outputLayer[i].Output) * outputLayer[i].Output * (1.0 - outputLayer[i].Output);
                    outputLayerGeneralizedDeltas[i] = delta;
                }
                //Calculate generalized deltas for hidden layer.
                double[] hiddenLayerGeneralizedDeltas = new double[hiddenLayer.Length];
                for (int i = 0; i < hiddenLayer.Length; i++)
                {
                    double sum = 0.0;
                    for (int k = 0; k < outputLayer.Length; k++)
                        sum += outputLayerGeneralizedDeltas[k] * outputLayer[k].Weights[i];
                    double delta = 1.0 * hiddenLayer[i].Output * (1 - hiddenLayer[i].Output) * sum;
                    hiddenLayerGeneralizedDeltas[i] = delta;
                }

                //Modify weights of output layer.
                for (int i = 0; i < outputLayer.Length; i++)
                    outputLayer[i].ModifyWeights(Eta, outputLayerGeneralizedDeltas[i]);
                //Modify weights of hidden layer.
                for (int i = 0; i < hiddenLayer.Length; i++) ;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberRecognizerDesktop
{
    class NeuralNetworkDigits : NeuralNetwork
    {
        int inputLayerSize = 400;
        //Output neurons 0-9 represent '0'-'9'.
        int outputLayerSize = 10/*digits*/;

        double[] inputs;
        Neuron[] hiddenLayer;
        Neuron[] outputLayer;

        public NeuralNetworkDigits(double learningRateEta, int hiddenLayerSize)
        {
            eta = learningRateEta;
            this.hiddenLayerSize = hiddenLayerSize;
            inputs = new double[inputLayerSize];
            hiddenLayer = new Neuron[hiddenLayerSize];
            outputLayer = new Neuron[outputLayerSize];
            for (int i = 0; i < hiddenLayer.Length; i++)
                hiddenLayer[i] = new Neuron(inputLayerSize);
            for (int i = 0; i < outputLayer.Length; i++)
                outputLayer[i] = new Neuron(hiddenLayerSize);
        }


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
            //if (mostProbableIndex < 10)
                return (char)('0' + mostProbableIndex);
            //else
            //    return (char)('A' + mostProbableIndex - 10);
        }

        override public void Train(List<CharacterImage> dataset)
        {
            foreach (CharacterImage image in dataset)
            {
                //Desired output is neuron corresponding to the digit label outputs 1.0, the rest outputs 0.0.
                double[] desiredOutputs = new double[outputLayerSize];
                if (image.Label >= '0' && image.Label <= '9')
                    desiredOutputs[image.Label - '0'] = 1.0;

                //Run image through the neural network.
                Recognize(image);

                //Backpropagation.
                //Calculate generalized deltas for output layer.
                double[] outputLayerGeneralizedDeltas = new double[outputLayer.Length];
                for (int i = 0; i < outputLayer.Length; i++)
                {
                    double delta = 1.0 * (desiredOutputs[i] - outputLayer[i].GetOutput()) * outputLayer[i].GetOutput() * (1.0 - outputLayer[i].GetOutput());
                    outputLayerGeneralizedDeltas[i] = delta;
                }

                //Calculate generalized deltas for hidden layer.
                double[] hiddenLayerGeneralizedDeltas = new double[hiddenLayer.Length];
                for (int i = 0; i < hiddenLayer.Length; i++)
                {
                    double sum = 0.0;
                    for (int k = 0; k < outputLayer.Length; k++)
                        sum += outputLayerGeneralizedDeltas[k] * outputLayer[k].GetWeights()[i];
                    double delta = 1.0 * hiddenLayer[i].GetOutput() * (1 - hiddenLayer[i].GetOutput()) * sum;
                    hiddenLayerGeneralizedDeltas[i] = delta;
                }

                //Modify weights of output layer.
                for (int i = 0; i < outputLayer.Length; i++)
                {
                    outputLayer[i].ModifyWeights(eta, outputLayerGeneralizedDeltas[i]);
                }

                //Modify weights of hidden layer.
                for (int i = 0; i < hiddenLayer.Length; i++)
                {
                    hiddenLayer[i].ModifyWeights(eta, hiddenLayerGeneralizedDeltas[i]);
                }

            }
        }

        public override double[] GetWeightsForSaving()
        {
            throw new NotImplementedException();
        }

        public override void LoadWeightsFromSave(double[] allWeights)
        {
            throw new NotImplementedException();
        }
    }
}

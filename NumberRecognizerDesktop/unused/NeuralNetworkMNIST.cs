using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberRecognizerDesktop
{
    class NeuralNetworkMNIST
    {
        int inputLayerSize = 784;
        int hiddenLayerSize = 15;
        int outputLayerSize = 10;

        double[] inputs;
        Neuron[] hiddenLayer;
        Neuron[] outputLayer;

        double eta;

        public NeuralNetworkMNIST(double learningRateEta)
        {
            eta = learningRateEta;
            inputs = new double[inputLayerSize];
            hiddenLayer = new Neuron[hiddenLayerSize];
            outputLayer = new Neuron[outputLayerSize];
            for (int i = 0; i < hiddenLayer.Length; i++)
                hiddenLayer[i] = new Neuron(inputLayerSize);
            for (int i = 0; i < outputLayer.Length; i++)
                outputLayer[i] = new Neuron(hiddenLayerSize);
        }

        public double GetLearningRateEta()
        {
            return eta;
        }

        public int Recognize(CharacterImageMNIST image)
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
            return Array.IndexOf(outputLayerOutputs, max);
        }


        public void Train(List<CharacterImageMNIST> dataset)
        {
            foreach (CharacterImageMNIST image in dataset)
            {
                //Desired output is neuron corresponding to the digit label outputs 1.0, the rest outputs 0.0.
                double[] desiredOutputs = new double[outputLayerSize];
                desiredOutputs[(int)char.GetNumericValue(image.Label)] = 1.0;

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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberRecognizerDesktop
{
    class NeuralNetworkUCI
    {
        int inputLayerSize = 400;
        int hiddenLayerSize = 30;
        //Output neurons 0-9 represent '0'-'9', neurons 10-35 represent A-Z.
        int outputLayerSize = 10/*digits*/ + 26/*capital letters*/;

        double[] inputs;
        Neuron[] hiddenLayer;
        Neuron[] outputLayer;

        double eta;

        public NeuralNetworkUCI(double learningRateEta, int hiddenLayerSize)
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

        public double GetLearningRateEta()
        {
            return eta;
        }

        public int GetHiddenLayerSize()
        {
            return hiddenLayerSize;
        }

        public char Recognize(CharacterImageUCI image)
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

        public void Train(List<CharacterImageUCI> dataset)
        {
            foreach (CharacterImageUCI image in dataset)
            {
                //Desired output is neuron corresponding to the digit label outputs 1.0, the rest outputs 0.0.
                double[] desiredOutputs = new double[outputLayerSize];
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

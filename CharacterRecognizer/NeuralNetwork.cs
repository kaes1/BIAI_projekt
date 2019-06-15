using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterRecognizer
{
    public abstract class NeuralNetwork
    {
        public double Eta { get; }
        public int InputLayerSize { get; }
        public int HiddenLayerSize { get; }
        public int OutputLayerSize { get; }

        protected double[] inputs;
        protected Neuron[] hiddenLayer;
        protected Neuron[] outputLayer;

        protected NeuralNetwork(int inputLayerSize, int hiddenLayerSize, int outputLayerSize, double eta)
        {
            InputLayerSize = inputLayerSize;
            HiddenLayerSize = hiddenLayerSize;
            OutputLayerSize = outputLayerSize;
            inputs = new double[inputLayerSize];
            hiddenLayer = new Neuron[hiddenLayerSize];
            for (int i = 0; i < hiddenLayer.Length; i++)
                hiddenLayer[i] = new Neuron(inputLayerSize);
            outputLayer = new Neuron[outputLayerSize];
            for (int i = 0; i < outputLayer.Length; i++)
                outputLayer[i] = new Neuron(hiddenLayerSize);
            Eta = eta;
        }

        public NeuralNetwork(NeuralNetworkState savedState)
        {
            InputLayerSize = savedState.inputLayerSize;
            HiddenLayerSize = savedState.hiddenLayerSize;
            OutputLayerSize = savedState.outputLayerSize;
            inputs = new double[InputLayerSize];
            hiddenLayer = new Neuron[HiddenLayerSize];
            for (int i = 0; i < hiddenLayer.Length; i++)
                hiddenLayer[i] = new Neuron(savedState.hiddenLayerState[i]);
            outputLayer = new Neuron[OutputLayerSize];
            for (int i = 0; i < outputLayer.Length; i++)
                outputLayer[i] = new Neuron(savedState.outputLayerState[i]);
            Eta = savedState.eta;
        }

        public abstract void Train(List<CharacterImage> dataset);

        public abstract char Recognize(CharacterImage image);

        public NeuralNetworkState GetNeuralNetworkState()
        {
            return new NeuralNetworkState(InputLayerSize, hiddenLayer, outputLayer, Eta);
        }

        public string GetInfo()
        {
            return "Layer sizes: " + InputLayerSize + ":" + HiddenLayerSize + ":" + OutputLayerSize + "\r\n" +
                    "Learning rate Eta: " + Eta;
        }
    }
}

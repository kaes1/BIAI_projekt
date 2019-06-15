using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterRecognizer
{
    [Serializable]
    public class NeuralNetworkState
    {
        public int inputLayerSize;
        public int hiddenLayerSize;
        public int outputLayerSize;
        public double eta;
        public NeuronState[] hiddenLayerState;
        public NeuronState[] outputLayerState;

        public NeuralNetworkState() { }

        public NeuralNetworkState(int inputLayerSize, Neuron[] hiddenLayer, Neuron[] outputLayer, double eta)
        {
            this.inputLayerSize = inputLayerSize;
            this.hiddenLayerSize = hiddenLayer.Length;
            this.outputLayerSize = outputLayer.Length;
            this.eta = eta;
            hiddenLayerState = new NeuronState[hiddenLayerSize];
            outputLayerState = new NeuronState[outputLayerSize];
            for (int i = 0; i < hiddenLayerState.Length; i++)
                hiddenLayerState[i] = hiddenLayer[i].GetNeuronState();
            for (int i = 0; i < outputLayerState.Length; i++)
                outputLayerState[i] = outputLayer[i].GetNeuronState();
        }
    }
}

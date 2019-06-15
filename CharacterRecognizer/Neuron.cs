using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterRecognizer
{
    public class Neuron
    {
        static Random randomNumberGenerator = new Random();
        //Weight concerning activation threshold.
        public double W_0 { get; private set; }
        //Activation threshold.
        public double X_0 { get; private set; }
        //Weights from previous layer neurons.
        public double[] Weights { get; private set; }
        //Inputs from previous layer neurons.
        double[] inputs;
        //Output of neuron.
        public double Output { get; private set; }

        public Neuron(int previousLayerSize)
        {
            //Create weights array.
            Weights = new double[previousLayerSize];
            W_0 = (randomNumberGenerator.NextDouble() * 2.0) - 1.0;
            X_0 = 1.0;
            for (int i = 0; i < Weights.Length; i++)
                Weights[i] = (randomNumberGenerator.NextDouble() * 2.0) - 1.0;
        }

        public Neuron(NeuronState savedState)
        {
            X_0 = savedState.x_0;
            W_0 = savedState.w_0;
            Weights = (double[])savedState.weights.Clone();
        }

        private static double SigmoidFunction(double x)
        {
            return 1.0 / (1.0 + Math.Exp(-x * 1.0));
        }

        public double CalculateOutput(double[] previousLayerOutputs)
        {
            inputs = previousLayerOutputs;
            double n = W_0 * X_0;
            for (int i = 0; i < Weights.Length; i++)
                n += Weights[i] * previousLayerOutputs[i];
            Output = SigmoidFunction(n);
            return Output;
        }

        public void ModifyWeights(double eta, double generalizedDelta)
        {
            for (int j = 0; j < Weights.Length; j++)
            {
                double delta_w = eta * generalizedDelta * inputs[j];
                Weights[j] += delta_w;
            }
            //Modify bias weight
            W_0 += eta * generalizedDelta * X_0;
        }

        public NeuronState GetNeuronState()
        {
            return new NeuronState(X_0, W_0, Weights);
        }
    }
}
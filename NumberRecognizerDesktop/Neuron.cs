using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberRecognizerDesktop
{
    public class Neuron
    {
        static Random randomNumberGenerator = new Random();
        //Weight concerning activation threshold.
        double w_0;
        //Activation threshold.
        double x_0;
        //Weights from previous layer neurons.
        double[] weights;
        //Inputs from previous layer neurons.
        double[] inputs;
        //Output of neuron.
        double output;

        public Neuron(int previousLayerSize)
        {
            //Create weights array.
            weights = new double[previousLayerSize];
            w_0 = (randomNumberGenerator.NextDouble() * 2.0) - 1.0;
            x_0 = 1.0;
            for (int i = 0; i < weights.Length; i++)
                weights[i] = (randomNumberGenerator.NextDouble() * 2.0) - 1.0;
        }

        private static double SigmoidFunction(double x)
        {
            return 1.0 / (1.0 + Math.Exp(-x * 1.0));
        }

        public double CalculateOutput(double[] previousLayerOutputs)
        {
            inputs = previousLayerOutputs;
            double n = w_0 * x_0;
            for (int i = 0; i < weights.Length; i++)
                n += weights[i] * previousLayerOutputs[i];
            output = SigmoidFunction(n);
            return output;
        }

        public double GetOutput()
        {
            return output;
        }

        public double[] GetWeights()
        {
            return weights;
        }

        public double GetW_0()
        {
            return w_0;
        }

        public void SetWeights(double[] weights, double w_0)
        {
            if (weights.Length != this.weights.Length)
                return;

            this.weights = weights;
            this.w_0 = w_0;
        }

        public void ModifyWeights(double eta, double generalizedDelta)
        {
            for (int j = 0; j < weights.Length; j++)
            {
                double delta_w = eta * generalizedDelta * inputs[j];
                weights[j] += delta_w;
            }
            //Modify bias weight
            w_0 += eta * generalizedDelta * x_0;
        }
    }
}
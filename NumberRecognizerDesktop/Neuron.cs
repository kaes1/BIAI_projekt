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

            //Initialize bias randomly using normal distribution.
            //double u1 = 1.0 - randomNumberGenerator.NextDouble(); //Uniform(0,1] random doubles
            //double u2 = 1.0 - randomNumberGenerator.NextDouble(); // - || -
            //w_0 = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); //Random normal(0,1)
            //x_0 = 1.0;
            ////Initialize weights.
            //for (int i = 0; i < weights.Length; i++)
            //{
            //    u1 = 1.0 - randomNumberGenerator.NextDouble();
            //    u2 = 1.0 - randomNumberGenerator.NextDouble();
            //    weights[i] = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); //Random normal(0,1)
            //}
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
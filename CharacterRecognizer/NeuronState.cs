using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterRecognizer
{
    [Serializable]
    public class NeuronState
    {
        public double x_0;
        public double w_0;
        public double[] weights;

        public NeuronState() { }

        public NeuronState(double x_0, double w_0, double[] weights)
        {
            this.x_0 = x_0;
            this.w_0 = w_0;
            this.weights = (double[])weights.Clone();
        }
    }
}

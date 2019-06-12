using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberRecognizerDesktop
{
    public abstract class NeuralNetwork
    {
        protected double eta;
        protected int hiddenLayerSize;

        public abstract void Train(List<CharacterImage> dataset);

        public abstract char Recognize(CharacterImage image);

        public double GetLearningRateEta()
        {
            return eta;
        }

        public int GetHiddenLayerSize()
        {
            return hiddenLayerSize;
        }

        public abstract double[] GetWeightsForSaving();
        public abstract void LoadWeightsFromSave(double[] allWeights);
    }
}

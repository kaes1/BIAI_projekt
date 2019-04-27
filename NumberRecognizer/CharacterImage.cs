using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberRecognizer
{
    public class CharacterImage
    {
        private const int numberOfPixels = 784;
        private char label;
        //Pixels values 0 - 255.
        private int[] pixels;
        //Normalized pixels values 0.0 - 1.0.
        private double[] normalizedPixels;

        //Constructor. Values are strings ranging from "0" to "255".
        public CharacterImage(string[] values)
        {
            label = values[0][0];
            pixels = new int[numberOfPixels];
            normalizedPixels = new double[numberOfPixels];
            for (int i = 0; i < numberOfPixels; i++)
            { 
                pixels[i] = int.Parse(values[i + 1]);
                normalizedPixels[i] = pixels[i] / 255.0;
            }
        }

        public char GetLabel()
        {
            return label;
        }

        public double[] GetNormalizedPixels()
        {
            return normalizedPixels;
        }
    }
}

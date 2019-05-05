using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberRecognizerDesktop
{
    public class CharacterImageMNIST : CharacterImage
    {
        //Constructor. Values are strings ranging from "0" to "255".
        public CharacterImageMNIST(string[] values)
        {
            //Set basic parameters.
            Width = 28;
            Height = 28;
            NumberOfPixels = 784;
            //Read label.
            Label = values[0][0];

            //Create pixel arrays.
            Pixels = new int[NumberOfPixels];
            NormalizedPixels = new double[NumberOfPixels];
            //Fill pixel arrays.
            for (int i = 0; i < NumberOfPixels; i++)
            {
                Pixels[i] = int.Parse(values[i + 1]);
                NormalizedPixels[i] = Pixels[i] / 255.0;
            }
        }
    }
}

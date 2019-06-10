using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberRecognizerDesktop
{
    public class CharacterImage
    {
        public int Width { get; internal set; }
        public int Height { get; internal set; }
        public int NumberOfPixels { get; internal set; }
        public char Label {  get; internal set; }

        //Pixels values 0 - 255.
        public int[] Pixels { get; internal set; }
        //Normalized pixels values 0.0 - 1.0.
        public double[] NormalizedPixels { get; internal set; }

        public CharacterImage()
        {

        }

        public CharacterImage(int width, int height, char label, int[] pixels)
        {
            Width = width;
            Height = height;
            NumberOfPixels = width * height;
            Label = label;
            Pixels = new int[NumberOfPixels];
            NormalizedPixels = new double[NumberOfPixels];
            for (int i = 0; i < NumberOfPixels; i++)
            {
                Pixels[i] = pixels[i];
                NormalizedPixels[i] = Pixels[i] / 255.0;
            }
        }
    }
}

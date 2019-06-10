using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberRecognizerDesktop
{
    public class CharacterImageUCI : CharacterImage
    {
        string fontFamily;
        string fontVariant;
        float strength;
        public bool italic { get; }
        float orientation;
        int m_top;
        int m_left;
        int originalHeight;
        int originalWidth;


        public CharacterImageUCI(string[] values)
        {
            //Set basic parameters.
            Width = 20;
            Height = 20;
            NumberOfPixels = 400;
            //Read label.
            Label = Convert.ToChar(int.Parse(values[2]));

            //Create pixel arrays.
            Pixels = new int[NumberOfPixels];
            NormalizedPixels = new double[NumberOfPixels];
            //Fill pixel arrays.
            for (int i = 0; i < NumberOfPixels; i++)
            {
                Pixels[i] = int.Parse(values[12 + i]);
                NormalizedPixels[i] = Pixels[i] / 255.0;
            }

            //Read information specific to this dataset.
            fontFamily = values[0];
            fontVariant = values[1];
            strength = float.Parse(values[3], System.Globalization.CultureInfo.InvariantCulture);
            italic = values[4] == "1";
            orientation = float.Parse(values[5], System.Globalization.CultureInfo.InvariantCulture);
            m_top = int.Parse(values[6]);
            m_left = int.Parse(values[7]);
            originalHeight = int.Parse(values[8]);
            originalWidth = int.Parse(values[9]);
        }

        public string GetFontFamily()
        {
            return fontFamily;
        }

        public string GetFontVariant()
        {
            return fontVariant;
        }

    }
}

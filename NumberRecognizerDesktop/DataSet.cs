using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberRecognizerDesktop
{
    public class DataSet
    {
        public List<CharacterImage> Images { get; }
        public SortedDictionary<string, List<CharacterImage>> ImagesByFontFamily { get; }
        public SortedDictionary<char, List<CharacterImage>> ImagesByCharacter { get; }

        public DataSet()
        {
            Images = new List<CharacterImage>();
            ImagesByFontFamily = new SortedDictionary<string, List<CharacterImage>>();
            ImagesByCharacter = new SortedDictionary<char, List<CharacterImage>>();
        }

        public void Add(CharacterImage image)
        {
            Images.Add(image);

            if (ImagesByFontFamily.TryGetValue(image.FontFamily, out var listByFont))
                listByFont.Add(image);
            else
                ImagesByFontFamily[image.FontFamily] = new List<CharacterImage>() { image };

            if (ImagesByCharacter.TryGetValue(image.Label, out var listByCharacter))
                listByCharacter.Add(image);
            else
                ImagesByCharacter[image.Label] = new List<CharacterImage>() { image };
        }
    }
}

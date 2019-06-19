using System;
using System.Collections.Generic; 

namespace CharacterRecognizer
{
    public class DataSet
    {
        public List<CharacterImage> Images { get; }
        public SortedDictionary<char, List<CharacterImage>> ImagesByCharacter { get; }
        public SortedDictionary<string, List<CharacterImage>> ImagesByFontFamily { get; }
        public SortedDictionary<string, SortedDictionary<char, List<CharacterImage>>> ImagesByFontFamilyAndCharacter { get; }

        private DataSet TestSet = null;
        private DataSet TrainingSet = null;

        public DataSet()
        {
            Images = new List<CharacterImage>();
            ImagesByFontFamily = new SortedDictionary<string, List<CharacterImage>>();
            ImagesByCharacter = new SortedDictionary<char, List<CharacterImage>>();
            ImagesByFontFamilyAndCharacter = new SortedDictionary<string, SortedDictionary<char, List<CharacterImage>>>();
        }

        public void Add(CharacterImage image)
        {
            Images.Add(image);

            if (ImagesByCharacter.TryGetValue(image.Label, out var listByCharacter))
                listByCharacter.Add(image);
            else
                ImagesByCharacter[image.Label] = new List<CharacterImage>() { image };

            if (ImagesByFontFamily.TryGetValue(image.FontFamily, out var listByFont))
                listByFont.Add(image);
            else
                ImagesByFontFamily[image.FontFamily] = new List<CharacterImage>() { image };

            if (ImagesByFontFamilyAndCharacter.TryGetValue(image.FontFamily, out var dictionaryByCharacter))
            {
                //Dictionary for this fontFamily exists.
                if (dictionaryByCharacter.TryGetValue(image.Label, out var listByFontFamilyAndCharacter))
                    listByFontFamilyAndCharacter.Add(image);
                else
                    dictionaryByCharacter[image.Label] = new List<CharacterImage>() { image };
            }
            else
            {
                //Dictionary for this fontFamily does not exist yet.
                ImagesByFontFamilyAndCharacter[image.FontFamily] = new SortedDictionary<char, List<CharacterImage>>();
                ImagesByFontFamilyAndCharacter[image.FontFamily].Add(image.Label, new List<CharacterImage>() { image });
            }
        }

        public DataSet GetTrainingSet()
        {
            if(TrainingSet == null)
                CreateTrainingAndTestSets();
            return TrainingSet;
        }

        public DataSet GetTestSet()
        {
            if (TestSet == null)
                CreateTrainingAndTestSets();
            return TestSet;
        }

        private void CreateTrainingAndTestSets()
        {
            Random rng = new Random(1);
            TrainingSet = new DataSet();
            TestSet = new DataSet();
            foreach (KeyValuePair<string, SortedDictionary<char, List<CharacterImage>>> dictionaryPair in ImagesByFontFamilyAndCharacter)
            {
                foreach (KeyValuePair<char, List<CharacterImage>> listPair in dictionaryPair.Value)
                {
                    var tempList = new List<CharacterImage>(listPair.Value);
                    int imagesToAdd = (int)(listPair.Value.Count * 0.8);

                    for (int i = 0; i < imagesToAdd; i++)
                    {
                        int randomIndex = rng.Next(0, tempList.Count);
                        TrainingSet.Add(tempList[randomIndex]);
                        tempList.RemoveAt(randomIndex);
                    }
                    foreach (CharacterImage img in tempList)
                        TestSet.Add(img);    
                }
            }
        }
    }
}

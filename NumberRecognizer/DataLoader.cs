using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberRecognizer
{
    public static class DataLoader
    {
        public static List<CharacterImage> LoadFromCSV(string path)
        {
            var dataset = new List<CharacterImage>();
            //Read csv.
            using (var reader = new StreamReader(path))
            {
                //Skip first line of csv.
                var firstline = reader.ReadLine();
                //Read the rest of csv, create image for each line and add to images list.
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    CharacterImage newImage = new CharacterImage(values);
                    dataset.Add(newImage);
                }
            }
            return dataset;
        }

    }
}

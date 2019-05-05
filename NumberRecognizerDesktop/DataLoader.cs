﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberRecognizerDesktop
{
    public static class DataLoader
    {
        public static List<CharacterImageMNIST> LoadFromFileCSV_MNIST(string filePath)
        {
            var dataset = new List<CharacterImageMNIST>();
            //Read csv.
            using (var reader = new StreamReader(filePath))
            {
                //Skip first line of csv.
                var firstline = reader.ReadLine();
                //Read the rest of csv, create image for each line and add to images list.
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    CharacterImageMNIST newImage = new CharacterImageMNIST(values);
                    dataset.Add(newImage);
                }
            }

            return dataset;
        }


        public static List<List<CharacterImageUCI>> LoadFromFolderCSV_UCI(string folderPath)
        {
            var uciSets = new List<List<CharacterImageUCI>>();

            //Get all csv files in specified directory.
            foreach (string file in Directory.EnumerateFiles(folderPath, "*.csv"))
            {
                //Remove weird fonts
                if (file.EndsWith("VLADIMIR.csv") || 
                    file.EndsWith("VIVALDI.csv") || file.EndsWith("STYLUS.csv") || file.EndsWith("SNAP.csv") || file.EndsWith("SKETCHFLOW.csv") ||
                    file.EndsWith("SHOWCARD.csv") || file.EndsWith("SCRIPT.csv") || file.EndsWith("SCRIPTB.csv") || file.EndsWith("ROMANTIC.csv") ||
                    file.EndsWith("RAVIE.csv") || file.EndsWith("RAGE.csv") || file.EndsWith("PALACE.csv") || file.EndsWith("MONEY.csv") ||
                    file.EndsWith("MISTRAL.csv") || file.EndsWith("MATURA.csv") || file.EndsWith("MAGNETO.csv") || file.EndsWith("KUNSTLER.csv") ||
                    file.EndsWith("JOKERMAN.csv") || file.EndsWith("HARRINGTON.csv") || file.EndsWith("HARLOW.csv") || file.EndsWith("GOTHICE.csv") ||
                    file.EndsWith("GIGI.csv") || file.EndsWith("FRENCH.csv") || file.EndsWith("ENGLISH.csv") || file.EndsWith("CURLZ.csv") ||
                    file.EndsWith("COMMERCIALSCRIPT.csv") || file.EndsWith("BRADLEY.csv") || file.EndsWith("BLACKADDER.csv"))
                    continue;

                var dataset = new List<CharacterImageUCI>();

                using (var reader = new StreamReader(file))
                {
                    //Skip first line of csv.
                    var firstline = reader.ReadLine();
                    //Read the rest of csv, create image for each line and add to images list.
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        
                        //Add only digits and capital letters, which are not italic.
                        char label = Convert.ToChar(int.Parse(values[2]));
                        bool italic = values[4] == "1";
                        string fontVariant = values[1];
                        if ((label >= '0' && label <= '9' || label >= 'A' && label <= 'Z') && !italic && !fontVariant.ToUpperInvariant().Equals("SCANNED"))
                        {
                            CharacterImageUCI newImage = new CharacterImageUCI(values);
                            dataset.Add(newImage);
                        }      
                    }
                }

                uciSets.Add(dataset);
            }

            return uciSets;
        }

    }
}

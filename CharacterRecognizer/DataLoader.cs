using System;
using System.IO;

namespace CharacterRecognizer
{
    public static class DataLoader
    {
        public static CharacterImage LoadFromBMP(string filePath)
        {
            CharacterImage characterImage = null;
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(filePath);
            if (bmp != null)
            {
                int[] pixels = new int[20 * 20];
                for (int y = 0; y < 20; y++)
                    for (int x = 0; x < 20; x++)
                    {
                        System.Drawing.Color pixelColor = bmp.GetPixel(x, y);
                        int grayscaleValue = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                        pixels[y * 20 + x] = grayscaleValue;
                    }
                characterImage = new CharacterImage(20, 20, Path.GetFileName(filePath)[0], pixels);
                bmp.Dispose();
            }
            return characterImage;
        }

        public static DataSet LoadAllData()
        {
            return LoadDataSet(@"UCI");
        }

        public static DataSet LoadDataSet(string folderPath)
        {
            DataSet dataSet = new DataSet();
            if (!Directory.Exists(folderPath))
                return dataSet;
            foreach (string fileName in Directory.EnumerateFiles(folderPath, "*.csv"))
                using (var reader = new StreamReader(fileName))
                {
                    //Skip first line of csv.
                    reader.ReadLine();
                    //Read the rest of csv, create image for each line and add to images list.
                    while (!reader.EndOfStream)
                    {
                        //Read one line with values for one image.
                        var values = reader.ReadLine().Split(',');
                        //Create images only for letters and digits.
                        char label = Convert.ToChar(int.Parse(values[2]));
                        if (!(label >= '0' && label <= '9' || label >= 'A' && label <= 'Z'))
                            continue;
                        //For this dataset width and height are both 20.
                        int width = 20;
                        int height = 20;
                        //Fill pixel array.
                        int[] pixels = new int[width * height];
                        for (int i = 0; i < width * height; i++)
                            pixels[i] = int.Parse(values[12 + i]);
                        //Read information specific to this dataset.
                        string fontFamily = values[0];
                        string fontVariant = values[1];
                        float strength = float.Parse(values[3], System.Globalization.CultureInfo.InvariantCulture);
                        bool italic = values[4] == "1";
                        CharacterImage newImage = new CharacterImage(20, 20, label, pixels, fontFamily, fontVariant, italic, strength);
                        dataSet.Add(newImage);
                    }
                }
            return dataSet;
        }
    }
}

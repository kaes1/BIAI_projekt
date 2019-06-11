using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberRecognizerDesktop
{
    public static class DataLoader
    {
        //private static readonly String[] enabledCSV = { "ROMAN.csv", "ARIAL.csv", "WIDE.csv", "STENCIL.csv" };

        public static CharacterImage LoadFromBMP(string filePath)
        {
            CharacterImage characterImage = null;
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(filePath);
            if (bmp != null)
            {
                int[] pixels = new int[bmp.Width * bmp.Height];
                for (int y = 0; y < bmp.Height; y++)
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        System.Drawing.Color pixelColor = bmp.GetPixel(x, y);
                        int grayscaleValue = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                        pixels[y * bmp.Width + x] = grayscaleValue;
                    }
                characterImage = new CharacterImage(bmp.Width, bmp.Height, 'Z', pixels);
                bmp.Dispose();
            }
            return characterImage;
        }

        public static DataSet LoadDataSet(string folderPath)
        {
            DataSet dataSet = new DataSet();
            foreach (string fileName in Directory.EnumerateFiles(folderPath, "*.csv"))
                //if (enabledCSV.Any(enabledName => fileName.EndsWith(enabledName)))
                if (true)
                    using (var reader = new StreamReader(fileName))
                    {
                        //Skip first line of csv.
                        reader.ReadLine();
                        //Read the rest of csv, create image for each line and add to images list.
                        while (!reader.EndOfStream)
                        {
                            //Read one line with values for one image
                            var values = reader.ReadLine().Split(',');
                            //For this dataset width and height are both 20.
                            int width = 20;
                            int height = 20;
                            char label = Convert.ToChar(int.Parse(values[2]));
                            //Fill pixel array.
                            int[] pixels = new int[width * height];
                            for (int i = 0; i < width * height; i++)
                                pixels[i] = int.Parse(values[12 + i]);
                            //Read information specific to this dataset.
                            string fontFamily = values[0];
                            string fontVariant = values[1];
                            float strength = float.Parse(values[3], System.Globalization.CultureInfo.InvariantCulture);
                            bool italic = values[4] == "1";
                            float orientation = float.Parse(values[5], System.Globalization.CultureInfo.InvariantCulture);
                            int m_top = int.Parse(values[6]);
                            int m_left = int.Parse(values[7]);
                            int originalHeight = int.Parse(values[8]);
                            int originalWidth = int.Parse(values[9]);

                            CharacterImage newImage = new CharacterImage(20, 20, label, pixels, fontFamily, fontVariant, italic, strength);

                            if ((newImage.Label >= '0' && newImage.Label <= '9' || newImage.Label >= 'A' && newImage.Label <= 'Z') /*&& !newImage.GetFontVariant().ToUpperInvariant().Equals("SCANNED")*/)
                                dataSet.Add(newImage);
                        }
                    }
            return dataSet;
        }

        public static DataSet LoadDataSetDigits(string folderPath)
        {
            DataSet dataSet = new DataSet();
            foreach (string fileName in Directory.EnumerateFiles(folderPath, "*.csv"))
                //if (enabledCSV.Any(enabledName => fileName.EndsWith(enabledName)))
                if (true)
                    using (var reader = new StreamReader(fileName))
                    {
                        //Skip first line of csv.
                        reader.ReadLine();
                        //Read the rest of csv, create image for each line and add to images list.
                        while (!reader.EndOfStream)
                        {
                            //Read one line with values for one image
                            var values = reader.ReadLine().Split(',');
                            //For this dataset width and height are both 20.
                            int width = 20;
                            int height = 20;
                            char label = Convert.ToChar(int.Parse(values[2]));
                            //Fill pixel array.
                            int[] pixels = new int[width * height];
                            for (int i = 0; i < width * height; i++)
                                pixels[i] = int.Parse(values[12 + i]);
                            //Read information specific to this dataset.
                            string fontFamily = values[0];
                            string fontVariant = values[1];
                            float strength = float.Parse(values[3], System.Globalization.CultureInfo.InvariantCulture);
                            bool italic = values[4] == "1";
                            float orientation = float.Parse(values[5], System.Globalization.CultureInfo.InvariantCulture);
                            int m_top = int.Parse(values[6]);
                            int m_left = int.Parse(values[7]);
                            int originalHeight = int.Parse(values[8]);
                            int originalWidth = int.Parse(values[9]);

                            CharacterImage newImage = new CharacterImage(20, 20, label, pixels, fontFamily, fontVariant, italic, strength);

                            if (newImage.Label >= '0' && newImage.Label <= '9')

                                dataSet.Add(newImage);
                        }
                    }
            return dataSet;
        }

        public static DataSet LoadDataSetLetters(string folderPath)
        {
            DataSet dataSet = new DataSet();
            foreach (string fileName in Directory.EnumerateFiles(folderPath, "*.csv"))
                //if (enabledCSV.Any(enabledName => fileName.EndsWith(enabledName)))
                if (true)
                    using (var reader = new StreamReader(fileName))
                    {
                        //Skip first line of csv.
                        reader.ReadLine();
                        //Read the rest of csv, create image for each line and add to images list.
                        while (!reader.EndOfStream)
                        {
                            //Read one line with values for one image
                            var values = reader.ReadLine().Split(',');
                            //For this dataset width and height are both 20.
                            int width = 20;
                            int height = 20;
                            char label = Convert.ToChar(int.Parse(values[2]));
                            //Fill pixel array.
                            int[] pixels = new int[width * height];
                            for (int i = 0; i < width * height; i++)
                                pixels[i] = int.Parse(values[12 + i]);
                            //Read information specific to this dataset.
                            string fontFamily = values[0];
                            string fontVariant = values[1];
                            float strength = float.Parse(values[3], System.Globalization.CultureInfo.InvariantCulture);
                            bool italic = values[4] == "1";
                            float orientation = float.Parse(values[5], System.Globalization.CultureInfo.InvariantCulture);
                            int m_top = int.Parse(values[6]);
                            int m_left = int.Parse(values[7]);
                            int originalHeight = int.Parse(values[8]);
                            int originalWidth = int.Parse(values[9]);

                            CharacterImage newImage = new CharacterImage(20, 20, label, pixels, fontFamily, fontVariant, italic, strength);

                            if (newImage.Label >= 'A' && newImage.Label <= 'Z' && newImage.Italic == false)
                                dataSet.Add(newImage);
                        }
                    }
            return dataSet;
        }

    }
}

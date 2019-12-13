using System.Collections.Generic;
using CommonLibrary.DataDTO;
using System.IO;
using System.Drawing;
using System;

namespace CommonLibrary.Transformators
{
    public class ImageTranformatter
    {
        private string _path;
        private string _fileExt;

        public ImageTranformatter(string path, string fileExt)
        {
            _path = path;
            _fileExt = fileExt;
        }

        /// <summary>
        /// Вытаскивание RGB компонент из изображений 28x28, получение данных для обучения нейросети
        /// </summary>
        public DataNumberDTO_28x28_Set[] GetData28x28(ref Dictionary<string, string> errors)
        {
            var length = 28 * 28;
            var images = Directory.GetFiles(_path, $"*.{_fileExt}");
            var dataSet = new DataNumberDTO_28x28_Set[images.Length];
            for (int i = 0; i < images.Length; i++)
            {
                var fileName = images[i];
                try
                {
                    var bitmap = new Bitmap(fileName);
                    var fileInfo = new FileInfo(fileName);
                    var rightAnswer = int.Parse(fileInfo.Name.Split('_')[0]);
                    var colorPixels = new Color[length];
                    for (int x = 0; x < 28; x++)
                    {
                        for (int y = 0; y < 28; y++)
                        {
                            colorPixels[x + y] = bitmap.GetPixel(x, y);
                        }
                    }
                    dataSet[i] = new DataNumberDTO_28x28_Set(i, rightAnswer, colorPixels);
                }
                catch (Exception ex)
                {
                    errors.Add(fileName, ex.Message);
                }
            }
            return dataSet;
        }
    }
}
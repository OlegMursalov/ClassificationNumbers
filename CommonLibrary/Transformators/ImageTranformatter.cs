using System.Collections.Generic;
using CommonLibrary.DataDTO;
using System.IO;
using System.Drawing;

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
        public Dictionary<int, DataNumberDTO_28x28_Set> GetData28x28()
        {
            var dataSet = new Dictionary<int, DataNumberDTO_28x28_Set>();
            var images = Directory.GetFiles(_path, $"*.{_fileExt}");
            for (int i = 0; i < images.Length; i++)
            {
                var bitmap = new Bitmap(images[i]);
                var colorPixels = new Color[28, 28];
                for (int x = 0; x < 28; x++)
                {
                    for (int y = 0; y < 28; y++)
                    {
                        colorPixels[x, y] = bitmap.GetPixel(x, y);
                    }
                }
                var item = new DataNumberDTO_28x28_Set(i, );
            }
            return dataSet;
        }
    }
}
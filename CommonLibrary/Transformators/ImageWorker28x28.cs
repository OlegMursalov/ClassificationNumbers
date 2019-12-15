using System.Collections.Generic;
using CommonLibrary.DataDTO;
using System.IO;
using System.Drawing;
using System;
using System.Runtime.Serialization.Json;
using System.Text;

namespace CommonLibrary.Transformators
{
    /// <summary>
    /// Работник с изображениями 28x28 pixels
    /// </summary>
    public class ImageWorker28x28
    {
        private string[] _images;

        private readonly int _widthImage = 28;
        private readonly int _heightImage = 28;

        public ImageWorker28x28(string path, string fileExt)
        {
            _images = Directory.GetFiles(path, $"*.{fileExt}");
        }

        public ImageWorker28x28(string[] images)
        {
            _images = images;
        }

        /// <summary>
        /// Вытаскивание RGB - компонент из изображений 28x28, получение данных для обучения нейросети
        /// </summary>
        public DataNumberDTO_28x28_Set[] GetRGBData(ref Dictionary<string, string> errors)
        {
            var dataSet = new DataNumberDTO_28x28_Set[_images.Length];
            for (int i = 0; i < _images.Length; i++)
            {
                var fileName = _images[i];
                try
                {
                    var bitmap = new Bitmap(fileName);
                    var rightAnswer = GetRightAnswer(fileName);
                    var colorPixels = GetColorsByRows(bitmap);
                    dataSet[i] = new DataNumberDTO_28x28_Set(i, rightAnswer, colorPixels);
                }
                catch (Exception ex)
                {
                    errors.Add(fileName, ex.Message);
                }
            }
            return dataSet;
        }

        /// <summary>
        /// Получить правильный ответ из имени JSON файла (цифра от 0 до 9)
        /// </summary>
        private int GetRightAnswer(string fileName)
        {
            var fileInfo = new FileInfo(fileName);
            var rightAnswer = int.Parse(fileInfo.Name.Split('_')[0]);
            return rightAnswer;
        }

        /// <summary>
        /// Получить построчно массив RGB - компонент из картинки 28x28 pixels
        /// </summary>
        private Color[] GetColorsByRows(Bitmap bitmap)
        {
            var list = new List<Color>();
            for (int y = 0; y < _heightImage; y++)
            {
                for (int x = 0; x < _widthImage; x++)
                {
                    var color = bitmap.GetPixel(x, y);
                    list.Add(color);
                }
            }
            return list.ToArray();
        }

        /// <summary>
        /// Сериализует наборы 28x28 изображений для тренировки нейросети
        /// </summary>
        public string SerializeRGBDataToJSON(DataNumberDTO_28x28_Set[] dataNumberDTO_28x28_Set, ref string exMessage)
        {
            var jsonStr = string.Empty;
            try
            {
                var ms = new MemoryStream();
                var serializer = new DataContractJsonSerializer(typeof(DataNumberDTO_28x28_Set[]));
                serializer.WriteObject(ms, dataNumberDTO_28x28_Set);
                var bytes = ms.ToArray();
                jsonStr = Encoding.UTF8.GetString(bytes);
            }
            catch (Exception ex)
            {
                exMessage = ex.Message;
            }
            return jsonStr;
        }
    }
}
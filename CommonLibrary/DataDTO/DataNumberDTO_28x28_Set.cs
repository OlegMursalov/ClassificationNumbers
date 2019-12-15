using System.Drawing;
using System.Runtime.Serialization;
using System.Linq;
using System.Collections.Generic;

namespace CommonLibrary.DataDTO
{
    /// <summary>
    /// Изображение с цифрой 28x28 pixels
    /// </summary>
    [DataContract]
    public class DataNumberDTO_28x28_Set
    {
        private string _pixelColorsStr;

        protected Color[] _pixelColors;

        public Color[] PixelColors
        {
            get
            {
                if (_pixelColors == null)
                {
                    _pixelColors = GetPixelColors().ToArray();
                    return _pixelColors;
                }
                else
                {
                    return _pixelColors;
                }
            }
        }

        private IEnumerable<Color> GetPixelColors()
        {
            var array = _pixelColorsStr.Split('_').ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                var items = array[i].Split(',');
                var r = int.Parse(items[0]);
                var g = int.Parse(items[1]);
                var b = int.Parse(items[2]);
                var a = int.Parse(items[3]);
                yield return Color.FromArgb(a, r, g, b);
            }
        }

        /// <summary>
        /// Номер item of data set
        /// </summary>
        [DataMember(Name = "Id")]
        public int Id { get; private set; }

        /// <summary>
        /// Правильный ответ - цифра от 0 до 9
        /// </summary>
        [DataMember(Name = "Number")]
        public int Number { get; private set; }

        /// <summary>
        /// Массив цветов (RGB - компонент) пикселей из изображения
        /// </summary>
        [DataMember(Name = "PixelColors")]
        public string PixelColorsStr
        {
            get
            {
                if (string.IsNullOrEmpty(_pixelColorsStr))
                {
                    var pixelColorsStr = _pixelColors.Select(i => $"{i.R}, {i.G}, {i.B}, {i.A}").ToArray();
                    _pixelColorsStr = string.Join(" _ ", pixelColorsStr);
                }
                return _pixelColorsStr;
            }
            private set
            {
                _pixelColorsStr = value;
            }
        }

        public DataNumberDTO_28x28_Set(int id, int number, Color[] pixelColors)
        {
            Id = id;
            Number = number;
            _pixelColors = pixelColors;
        }
    }
}
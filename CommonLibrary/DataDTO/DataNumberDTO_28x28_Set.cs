using System.Drawing;
using System.Runtime.Serialization;
using System.Linq;

namespace CommonLibrary.DataDTO
{
    /// <summary>
    /// Изображение с цифрой 28x28 pixels
    /// </summary>
    [DataContract]
    public class DataNumberDTO_28x28_Set
    {
        protected Color[] _pixelColors;

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
                var pixelColorsStr = _pixelColors.Select(i => $"{i.A}, {i.G}, {i.B}").ToArray();
                return string.Join(" _ ", pixelColorsStr);
            }
            private set
            {
                // not implementing
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
using System.Drawing;
using System.Runtime.Serialization;

namespace CommonLibrary.DataDTO
{
    /// <summary>
    /// Изображение с цифрой 28x28 pixels
    /// </summary>
    [DataContract]
    public class DataNumberDTO_28x28_Set
    {
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
        public Color[] PixelColors { get; private set; }
        
        public DataNumberDTO_28x28_Set(int id, int number, Color[] pixelColors)
        {
            Id = id;
            Number = number;
            PixelColors = pixelColors;
        }
    }
}
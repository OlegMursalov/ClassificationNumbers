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
        /// Массив цветов (ARGB - компонент) пикселей из изображения
        /// </summary>
        [DataMember(Name = "PixelColors")]
        public ColorSimplifiedDTO[] ARGBAComponents { get; private set; }
        
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

        public DataNumberDTO_28x28_Set(int id, int number, Color[] pixelColors)
        {
            Id = id;
            Number = number;
            ARGBAComponents = GetColorSimplifiedDTOFromPixelColors(pixelColors);
        }

        /// <summary>
        /// Получить только ARGB - компоненты из пикселей
        /// </summary>
        /// <returns></returns>
        private ColorSimplifiedDTO[] GetColorSimplifiedDTOFromPixelColors(Color[] pixelColors)
        {
            var ARGBaComponents = new ColorSimplifiedDTO[pixelColors.Length];
            for (var i = 0; i < pixelColors.Length; i++)
            {
                ARGBaComponents[i] = new ColorSimplifiedDTO
                {
                    R = pixelColors[i].R,
                    G = pixelColors[i].G,
                    B = pixelColors[i].B,
                    A = pixelColors[i].A
                };
            }
            return ARGBaComponents;
        }
    }
}
using System.Drawing;

namespace CommonLibrary.DataDTO
{
    /// <summary>
    /// Изображение с цифрой 28x28 pixels
    /// </summary>
    public class DataNumberDTO_28x28_Set
    {
        /// <summary>
        /// Правильный ответ - цифра от 0 до 9
        /// </summary>
        public int Number { get; }

        /// <summary>
        /// Массив цветов (RGB - компонент) пикселей из изображения
        /// </summary>
        public Color[,] PixelColors { get; }

        public DataNumberDTO_28x28_Set(int number, Color[,] pixelColors)
        {
            Number = number;
            PixelColors = pixelColors;
        }
    }
}
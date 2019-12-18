using ClassificationNumbers.Forms;
using CommonLibrary.DataDTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassificationNumbers.Drawing
{
    public class Image28x28Painter : IDisposable
    {
        public readonly string ImageName = "images28x28data.png";

        private readonly int amountPicturesInline = 30;
        private readonly int amountPicturesRows = 30;
        private readonly int widthOneImage = 28;
        private readonly int heightOneImage = 28;

        private PainterForm _painterForm;
        private Graphics _currentGraphics;
        private Bitmap _bitmap;
        private DataNumberDTO_28x28_Set[] _dataNumberDTO_28x28_Set;

        public Image28x28Painter(PainterForm painterForm, DataNumberDTO_28x28_Set[] dataNumberDTO_28x28_Set)
        {
            _painterForm = painterForm;
            _dataNumberDTO_28x28_Set = dataNumberDTO_28x28_Set;
            int width = amountPicturesInline * widthOneImage;
            int height = amountPicturesRows * heightOneImage;
            _bitmap = new Bitmap(width, height);
            _currentGraphics = Graphics.FromImage(_bitmap);
        }

        /// <summary>
        /// Создает изображение входных данных 28x28 картинок
        /// </summary>
        public void CreateImage(Action<int> progressBarIncrement)
        {
            var counter = 0;
            var x_offset = 0;
            var y_offset = 0;
            var amountOfImagesByOnePercent = Math.Floor((double)_dataNumberDTO_28x28_Set.Length / 100);
            for (int i = 0; i < _dataNumberDTO_28x28_Set.Length; i++)
            {
                var x = 0;
                var y = 0;
                var dataSet = _dataNumberDTO_28x28_Set[i];
                var rgbaComponents = dataSet.RGBAComponents;
                for (int j = 0; j < rgbaComponents.Length; j++)
                {
                    var colorSimplifiedDTO = rgbaComponents[j];
                    var colorPixel = Color.FromArgb(colorSimplifiedDTO.A, colorSimplifiedDTO.R, colorSimplifiedDTO.G, colorSimplifiedDTO.B);
                    _bitmap.SetPixel(x + x_offset, y + y_offset, colorPixel);
                    x++;
                    if (x >= widthOneImage)
                    {
                        y++;
                        x = 0;
                    }
                }

                counter++;
                ChangeOffset(ref x_offset, ref y_offset, ref counter);

                _painterForm.Invoke(progressBarIncrement, 1);
            }
            SaveImageToPictureBox();
        }

        private void ChangeOffset(ref int x_offset, ref int y_offset, ref int counter)
        {
            x_offset += widthOneImage;
            if (counter == amountPicturesInline)
            {
                counter = 0;
                x_offset = 0;
                y_offset += heightOneImage;
            }
        }

        private void SaveImageToPictureBox()
        {
            _bitmap.Save(ImageName);
        }

        public void Dispose()
        {
            if (_currentGraphics != null)
            {
                _currentGraphics.Dispose();
            }
            if (_bitmap != null)
            {
                _bitmap.Dispose();
            }
        }
    }
}

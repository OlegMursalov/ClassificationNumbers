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
        private readonly int pixelsLength = 28;

        private PainterForm _painterForm;
        private Graphics _currentGraphics;
        private Bitmap _bitmap;
        private DataNumberDTO_28x28_Set[] _dataNumberDTO_28x28_Set;

        public Image28x28Painter(PainterForm painterForm, DataNumberDTO_28x28_Set[] dataNumberDTO_28x28_Set)
        {
            _painterForm = painterForm;
            _dataNumberDTO_28x28_Set = dataNumberDTO_28x28_Set;
            int width = amountPicturesInline * 28;
            int height = (_dataNumberDTO_28x28_Set.Length / amountPicturesInline) * 28;
            _bitmap = new Bitmap(width, height);
            _currentGraphics = Graphics.FromImage(_bitmap);
        }

        /// <summary>
        /// Создает изображение входных данных 28x28 картинок
        /// </summary>
        public void CreateImage(Action<int> progressBarIncrement)
        {
            var x_offset = 0;
            var y_offset = 0;
            var counter = 0;
            for (int i = 0; i < _dataNumberDTO_28x28_Set.Length; i++)
            {
                var dataSet = _dataNumberDTO_28x28_Set[i];
                var colorPixels = dataSet.PixelColors;
                for (int x = 0; x < pixelsLength; x++)
                {
                    for (int y = 0; y < pixelsLength; y++)
                    {
                        var colorPixel = colorPixels[x + y];
                        _currentGraphics.DrawEllipse(new Pen(colorPixel), new RectangleF(x + x_offset, y + y_offset, 1, 1));
                    }
                }
                ChangeOffset(ref x_offset, ref y_offset, ref counter);
            }
            SaveImageToPictureBox();
        }

        private void ChangeOffset(ref int x_offset, ref int y_offset, ref int counter)
        {
            x_offset += pixelsLength;
            counter++;
            if (counter == pixelsLength)
            {
                counter = 0;
                x_offset = 0;
                y_offset += pixelsLength;
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

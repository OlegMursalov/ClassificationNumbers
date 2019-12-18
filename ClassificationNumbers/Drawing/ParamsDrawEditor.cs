using System;
using System.Drawing;

namespace ClassificationNumbers.Drawing
{
    public class ParamsDrawEditor : IDisposable
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Brush Brush { get; private set; }
        public Bitmap Canvas { get; private set; }

        public bool IsCrealAll { get; private set; }
        public bool AreCoordnatesSet { get; private set; }

        public ParamsDrawEditor(Color color)
        {
            Brush = new SolidBrush(color);
        }

        public void SetCanvas(Bitmap newCanvas)
        {
            Canvas = newCanvas;
        }

        public void SetCoordnatesStateParams(bool state)
        {
            AreCoordnatesSet = state;
        }

        public void SetClearAllStateParams(bool state)
        {
            IsCrealAll = state;
        }

        public void SetEllipseCoordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Dispose()
        {
            if (Brush != null)
            {
                Brush.Dispose();
            }
            if (Canvas != null)
            {
                Canvas.Dispose();
            }
        }
    }
}
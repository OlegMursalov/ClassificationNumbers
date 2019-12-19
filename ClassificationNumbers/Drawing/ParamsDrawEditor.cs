using System;
using System.Drawing;

namespace ClassificationNumbers.Drawing
{
    public class ParamsDrawEditor : IDisposable
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Brush BrushPoint { get; private set; }
        public Bitmap Canvas { get; private set; }

        public bool IsCrealAll { get; private set; }
        public bool AreCoordnatesSet { get; private set; }

        public ParamsDrawEditor(Color brushPoint)
        {
            BrushPoint = new SolidBrush(brushPoint);
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
            if (BrushPoint != null)
            {
                BrushPoint.Dispose();
            }
            if (Canvas != null)
            {
                Canvas.Dispose();
            }
        }
    }
}
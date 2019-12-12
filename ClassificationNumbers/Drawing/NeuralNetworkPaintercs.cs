using ClassificationNumbers.MainClasses;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ClassificationNumbers.Drawing
{
    public class NeuralNetworkPainter
    {
        private NeuralNetwork _neuralNetwork;
        private PictureBox _pictureBox;
        private Graphics _currentGraphics;

        public NeuralNetworkPainter(PictureBox pictureBox, NeuralNetwork neuralNetwork)
        {
            _pictureBox = pictureBox;
            _neuralNetwork = neuralNetwork;
            _currentGraphics = _pictureBox.CreateGraphics();
        }

        public void Draw()
        {
            var blackPen = new Pen(Color.Black);
            _currentGraphics.DrawLine(blackPen, 23, 0, 244, 679);
            _currentGraphics.DrawEllipse(blackPen, new RectangleF(43, 45, 12, 79));
            _currentGraphics.Save();
            _pictureBox.InitialImage = new Bitmap(_pictureBox.Width, _pictureBox.Height, _currentGraphics);
        }
    }
}
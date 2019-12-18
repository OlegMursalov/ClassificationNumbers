using CommonLibrary.DataDTO;
using CommonLibrary.NeuralNetworks;
using CommonLibrary.Transformators;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClassificationNumbers.Forms
{
    public partial class CheckerNNForm : Form
    {
        private readonly int _sizePen = 10;
        private readonly int sizeImg = 28;

        private Neural3NetworkCreator _neural3NetworkCreator;
        private Bitmap _mainBitmap;
        private Graphics _mainGraphics;
        private Pen _pen;
        
        public CheckerNNForm(Neural3NetworkCreator neural3NetworkCreator)
        {
            InitializeComponent();
            _neural3NetworkCreator = neural3NetworkCreator;
            _mainGraphics = _mainPictureBox.CreateGraphics();
            _pen = new Pen(Color.Black);
        }

        private void _mainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _mainGraphics.DrawEllipse(_pen, new RectangleF(e.X, e.Y, _sizePen, _sizePen));
            }
        }

        private void _clearEditorBtn_Click(object sender, EventArgs e)
        {
            _mainGraphics.Clear(Color.White);
        }

        /// <summary>
        /// Сжимает картинку в редакторе до 28x28 pixels, возвращает RGBA - составляющие
        /// </summary>
        private Color[] GetRGBAComponents28x28FromEditor()
        {
            var image = new Bitmap(_mainPictureBox.Width, _mainPictureBox.Height, _mainGraphics);
            image.Save("result.png");
            var resizedImage = ImageWorker28x28.ResizeImage(image, sizeImg, sizeImg);
            return ImageWorker28x28.GetColorsByRows(resizedImage);
        }

        /// <summary>
        /// Проверка нейросети.
        /// Нейросеть должна предсказать, что это за цифра, отрисованная в редакторе.
        /// </summary>
        private void _checkNNBtn_Click(object sender, EventArgs e)
        {
            var id = int.MaxValue;
            int number = int.MaxValue;
            var neural3NetworkChecker = new Neural3NetworkChecker(_neural3NetworkCreator);
            var colors = GetRGBAComponents28x28FromEditor();
            var dataNumberDTO_28x28_Set = new DataNumberDTO_28x28_Set(id, number, colors);
            var result = neural3NetworkChecker.Check(dataNumberDTO_28x28_Set);

            // Момент истины
            MessageBox.Show($"Цифра - {result.NeuronNumber}, sutput signal - {result.Signal}");
        }
    }
}
using ClassificationNumbers.Drawing;
using CommonLibrary.DataDTO;
using CommonLibrary.NeuralNetworks;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClassificationNumbers.Forms
{
    public partial class CheckerNNForm : Form
    {
        private readonly int _sizePen = 10;

        private ParamsDrawEditor _paramsDrawEditor;

        private Neural3NetworkCreator _neural3NetworkCreator;
        
        public CheckerNNForm(Neural3NetworkCreator neural3NetworkCreator)
        {
            InitializeComponent();
            _neural3NetworkCreator = neural3NetworkCreator;
            _paramsDrawEditor = new ParamsDrawEditor(Color.Black);
        }

        private void _mainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _paramsDrawEditor.SetEllipseCoordinates(e.X, e.Y);
                _paramsDrawEditor.SetCoordnatesStateParams(state: true);
                RepaintMainPictureBox();
            }
        }

        private void _mainPictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (_paramsDrawEditor.AreCoordnatesSet)
            {
                int x = _paramsDrawEditor.X;
                int y = _paramsDrawEditor.Y;
                if (_paramsDrawEditor.Canvas != null)
                {
                    using (Graphics g = Graphics.FromImage(_paramsDrawEditor.Canvas))
                    {
                        g.DrawImage(_paramsDrawEditor.Canvas, 0, 0);
                        g.FillEllipse(_paramsDrawEditor.Brush, new RectangleF(x, y, _sizePen, _sizePen));
                    }
                }
                else
                {
                    e.Graphics.FillEllipse(_paramsDrawEditor.Brush, new RectangleF(x, y, _sizePen, _sizePen));
                    var canvas = new Bitmap(_mainPictureBox.Width, _mainPictureBox.Height, e.Graphics);
                    _paramsDrawEditor.SetCanvas(canvas);
                }
                _paramsDrawEditor.SetCoordnatesStateParams(state: false);
            }
            if (_paramsDrawEditor.IsCrealAll)
            {
                if (_paramsDrawEditor.Canvas != null)
                {
                    using (Graphics g = Graphics.FromImage(_paramsDrawEditor.Canvas))
                    {
                        g.Clear(Color.White);
                    }
                    _paramsDrawEditor.SetClearAllStateParams(state: false);
                }
            }
        }

        private void _clearEditorBtn_Click(object sender, EventArgs e)
        {
            _paramsDrawEditor.SetClearAllStateParams(state: true);
            RepaintMainPictureBox();
        }

        /// <summary>
        /// Перерисовывает главное окно простого графического редактора
        /// </summary>
        private void RepaintMainPictureBox()
        {
            _mainPictureBox.Invalidate();
            _mainPictureBox.Update();
            _mainPictureBox.Image = _paramsDrawEditor.Canvas;
        }

        /// <summary>
        /// Сжимает картинку в редакторе до 28x28 pixels, возвращает RGBA - составляющие
        /// </summary>
        private Color[] GetRGBAComponents28x28FromEditor()
        {
            /*var image = new Bitmap(_mainPictureBox.Width, _mainPictureBox.Height, _mainGraphics);
            var resizedImage = ImageWorker28x28.ResizeImage(image, sizeImg, sizeImg);
            return ImageWorker28x28.GetColorsByRows(resizedImage);*/
            return new Color[0];
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
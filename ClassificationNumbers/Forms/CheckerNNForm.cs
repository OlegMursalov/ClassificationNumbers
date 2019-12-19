using ClassificationNumbers.Drawing;
using CommonLibrary.DataDTO;
using CommonLibrary.NeuralNetworks;
using CommonLibrary.Transformators;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ClassificationNumbers.Forms
{
    public partial class CheckerNNForm : Form
    {
        private readonly int _sizeImg = 28;
        private readonly int _sizePen = 10;

        private ParamsDrawEditor _paramsDrawEditor;

        private Neural3NetworkCreator _neural3NetworkCreator;

        private Neural3NetworkTeacher _neural3NetworkTeacher;

        public CheckerNNForm(Neural3NetworkCreator neural3NetworkCreator, Neural3NetworkTeacher neural3NetworkTeacher)
        {
            InitializeComponent();
            _neural3NetworkCreator = neural3NetworkCreator;
            _neural3NetworkTeacher = neural3NetworkTeacher;
            _paramsDrawEditor = new ParamsDrawEditor(brushPoint: Color.Black);
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
                        g.FillEllipse(_paramsDrawEditor.BrushPoint, new RectangleF(x, y, _sizePen, _sizePen));
                    }
                }
                else
                {
                    e.Graphics.FillEllipse(_paramsDrawEditor.BrushPoint, new RectangleF(x, y, _sizePen, _sizePen));
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
            var resizedImage = ImageWorker28x28.ResizeImage(_paramsDrawEditor.Canvas, _sizeImg, _sizeImg);
            return ImageWorker28x28.GetColorsByRows(resizedImage, isSetColorForTransparencyPixels: true, colorForTransparency: Color.White);
        }
        
        /// <summary>
        /// Проверка нейросети.
        /// Нейросеть должна предсказать, что это за цифра, отрисованная в редакторе.
        /// </summary>
        private void _checkNNBtn_Click(object sender, EventArgs e)
        {
            var id = int.MaxValue;
            int number = int.MaxValue;

            var minSignal = _neural3NetworkTeacher.MinSignal;
            var maxSignal = _neural3NetworkTeacher.MaxSignal;
            var expectedSignal = _neural3NetworkTeacher.ExpectedSignal;

            var neural3NetworkChecker = new Neural3NetworkChecker(_neural3NetworkCreator, minSignal, maxSignal, expectedSignal);

            var colors = GetRGBAComponents28x28FromEditor();
            var dataNumberDTO_28x28_Set = new DataNumberDTO_28x28_Set(id, number, colors);

            var result = neural3NetworkChecker.Check(dataNumberDTO_28x28_Set);
            
            // Момент истины
            MessageBox.Show($"Цифра - {result.NeuronNumber}, sutput signal - {result.Signal}");
        }
    }
}
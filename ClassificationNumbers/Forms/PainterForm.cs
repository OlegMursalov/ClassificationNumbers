using ClassificationNumbers.Drawing;
using ClassificationNumbers.MainClasses;
using CommonLibrary.DataDTO;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassificationNumbers.Forms
{
    public partial class PainterForm : Form
    {
        private NeuralNetwork _neuralNetwork;
        private NeuralNetworkPainter _neuralNetworkPainter;

        private Image28x28Painter _image28x28Painter;
        private DataNumberDTO_28x28_Set[] _dataNumberDTO_28x28_Set;

        public PainterForm(NeuralNetwork neuralNetwork)
        {
            _neuralNetwork = neuralNetwork;
            InitializeComponent();
        }

        public PainterForm(DataNumberDTO_28x28_Set[] dataNumberDTO_28x28_Set)
        {
            _dataNumberDTO_28x28_Set = dataNumberDTO_28x28_Set;
            InitializeComponent();
        }

        /// <summary>
        /// Отрисовать картинки 28x28 pixels
        /// </summary>
        public async void DrawImages28x28()
        {
            _mainProgressBar.Value = 0;
            _mainProgressBar.Minimum = 0;
            _mainProgressBar.Maximum = 100;
            _mainPictureBox.Image = null;
            using (_image28x28Painter = new Image28x28Painter(this, _dataNumberDTO_28x28_Set))
            {
                await Task.Run(() =>
                {
                    _image28x28Painter.CreateImage((percent) => { _mainProgressBar.Value += percent; });
                });
                _mainPictureBox.Image = Image.FromFile(_image28x28Painter.ImageName);
            }
        }

        /// <summary>
        /// Отрисовать нейронную сеть
        /// </summary>
        public async void DrawNeuralNetworkAsync()
        {
            _mainProgressBar.Value = 0;
            _mainProgressBar.Minimum = 0;
            _mainProgressBar.Maximum = 100;
            _mainPictureBox.Image = null;
            using (_neuralNetworkPainter = new NeuralNetworkPainter(this, _neuralNetwork))
            {
                await Task.Run(() =>
                {
                    _neuralNetworkPainter.CreateImage((percent) => { _mainProgressBar.Value += percent; });
                });
                _mainPictureBox.Image = Image.FromFile(_neuralNetworkPainter.ImageName);
            }
        }
    }
}
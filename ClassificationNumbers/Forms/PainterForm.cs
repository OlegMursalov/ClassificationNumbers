using ClassificationNumbers.Drawing;
using CommonLibrary.NeuralNetworks;
using CommonLibrary.DataDTO;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassificationNumbers.Forms
{
    public partial class PainterForm : Form
    {
        private Neural3NetworkCreator _neural3NetworkCreator;
        private NeuralNetworkPainter _neuralNetworkPainter;

        private Image28x28Painter _image28x28Painter;
        private DataNumberDTO_28x28_Set[] _dataNumberDTO_28x28_Set;

        public PainterForm(Neural3NetworkCreator neural3NetworkCreator)
        {
            _neural3NetworkCreator = neural3NetworkCreator;
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
            _mainProgressBar.Maximum = _dataNumberDTO_28x28_Set.Length;
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
            using (_neuralNetworkPainter = new NeuralNetworkPainter(this, _neural3NetworkCreator))
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
using ClassificationNumbers.Drawing;
using ClassificationNumbers.MainClasses;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassificationNumbers
{
    public partial class PainterForm : Form
    {
        private NeuralNetwork _neuralNetwork;
        private NeuralNetworkPainter _neuralNetworkPainter;

        public PainterForm(NeuralNetwork neuralNetwork)
        {
            _neuralNetwork = neuralNetwork;
            InitializeComponent();
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
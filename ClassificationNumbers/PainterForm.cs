using ClassificationNumbers.Drawing;
using ClassificationNumbers.MainClasses;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClassificationNumbers
{
    public partial class PainterForm : Form
    {
        private NeuralNetwork _neuralNetwork;
        private Bitmap _neuralNetworkBitmap;

        public PainterForm(NeuralNetwork neuralNetwork)
        {
            InitializeComponent();
            _neuralNetwork = neuralNetwork;
        }

        /// <summary>
        /// Отрисовать нейронную сеть
        /// </summary>
        public Bitmap DrawNeuralNetwork()
        {
            var neuralNetworkPainter = new NeuralNetworkPainter(this, _neuralNetwork);
            _neuralNetworkBitmap = neuralNetworkPainter.Draw();
            return _neuralNetworkBitmap;
        }
    }
}
using ClassificationNumbers.MainClasses;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ClassificationNumbers.Drawing
{
    public class NeuralNetworkPainter
    {
        private readonly Point _initialPointLeftCorner = new Point(25, 25);
        private readonly int _widthNeuron = 40;
        private readonly int _heightNeuron = 40;
        private readonly int _ySpace = 120;
        private readonly int _offset_x_y = 20;

        private NeuralNetwork _neuralNetwork;
        private PainterForm _painterForm;
        private Graphics _currentGraphics;

        private Point[] _inputNeuronPoints;
        private Point[] _hiddenNeuronPoints;
        private Point[] _outputNeuronPoints;

        private List<RelationLine> _inputHiddenRelationPoints;
        private List<RelationLine> _hiddenOutputRelationPoints;

        public NeuralNetworkPainter(PainterForm painterForm, NeuralNetwork neuralNetwork)
        {
            _painterForm = painterForm;
            _neuralNetwork = neuralNetwork;
            _currentGraphics = _painterForm.CreateGraphics();
        }

        public Bitmap Draw()
        {
            // Отрисовка нейронов входного слоя
            _inputNeuronPoints = DrawNeurons(new Pen(Color.Blue), _neuralNetwork.InputLayer.Neurons, 0, _ySpace);
            // Отрисовка нейронов скрытого слоя
            _hiddenNeuronPoints = DrawNeurons(new Pen(Color.Gray), _neuralNetwork.HiddenLayer.Neurons, 100, _ySpace);
            // Отрисовка нейронов выходного слоя
            _outputNeuronPoints = DrawNeurons(new Pen(Color.Red), _neuralNetwork.OutputLayer.Neurons, 200, _ySpace);

            // Отрисовка связей между нейронами входного и скрытого слоях
            _inputHiddenRelationPoints = DrawRelations(new Pen(Color.Green), _inputNeuronPoints, _hiddenNeuronPoints);

            // Отрисовка связей между нейронами скрытого и выходного слоях
            _hiddenOutputRelationPoints = DrawRelations(new Pen(Color.Green), _hiddenNeuronPoints, _outputNeuronPoints);
            
            return SetImageToPictureBox();
        }

        private List<RelationLine> DrawRelations(Pen pen, Point[] neuronsA, Point[] neuronsB)
        {
            var relationPoints = new List<RelationLine>();
            for (int i = 0; i < neuronsA.Length; i++)
            {
                for (int j = 0; j < neuronsB.Length; j++)
                {
                    var relationLine = new RelationLine(neuronsA[i], neuronsB[j]);
                    relationPoints.Add(relationLine);
                    _currentGraphics.DrawLine(pen, relationLine.Input.X + _offset_x_y, relationLine.Input.Y + _offset_x_y, relationLine.Output.X + _offset_x_y, relationLine.Output.Y + _offset_x_y);
                }
            }
            return relationPoints;
        }

        private Point[] DrawNeurons(Pen pen, Neuron[] neurons, int xSpace, int ySpace)
        {
            var neuronPoints = new Point[neurons.Length];
            var x = _initialPointLeftCorner.X + xSpace;
            var y = _initialPointLeftCorner.Y;
            for (int i = 0; i < neurons.Length; i++)
            {
                neuronPoints[i] = new Point(x, y);
                _currentGraphics.DrawEllipse(pen, new RectangleF(neuronPoints[i].X, neuronPoints[i].Y, _widthNeuron, _heightNeuron));
                y += ySpace;
            }
            return neuronPoints;
        }

        private Bitmap SetImageToPictureBox()
        {
            _currentGraphics.Save();
            var bitmap = new Bitmap(_painterForm.Width, _painterForm.Height, _currentGraphics);
            _painterForm.BackgroundImage = bitmap;
            return bitmap;
        }
    }
}
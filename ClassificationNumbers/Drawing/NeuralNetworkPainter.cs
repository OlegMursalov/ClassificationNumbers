using ClassificationNumbers.NeuralNetworks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ClassificationNumbers.Forms;

namespace ClassificationNumbers.Drawing
{
    public class NeuralNetworkPainter : IDisposable
    {
        public readonly string ImageName = "neuralNetwork.png";
        
        private readonly int _widthNeuron = 20;
        private readonly int _heightNeuron = 20;
        private readonly int _ySpace = 100;
        private readonly int _offset_x_y = 10;

        private NeuralNetwork _neuralNetwork;
        private PainterForm _painterForm;
        private Graphics _currentGraphics;
        private Bitmap _bitmap;

        private Point[] _inputNeuronPoints;
        private Point[] _hiddenNeuronPoints;
        private Point[] _outputNeuronPoints;

        private List<RelationLine> _inputHiddenRelationPoints;
        private List<RelationLine> _hiddenOutputRelationPoints;

        public NeuralNetworkPainter(PainterForm painterForm, NeuralNetwork neuralNetwork)
        {
            _painterForm = painterForm;
            _neuralNetwork = neuralNetwork;
            _bitmap = new Bitmap(_painterForm._mainPictureBox.Width, _painterForm._mainPictureBox.Height);
            _currentGraphics = Graphics.FromImage(_bitmap);
        }

        /// <summary>
        /// Создает изображение нейронной сети (нейроны, связи)
        /// </summary>
        public void CreateImage(Action<int> progressBarIncrement)
        {
            // Получение точек нейронов входного слоя
            _inputNeuronPoints = GetNeuronPoints(_neuralNetwork.InputLayer.Neurons, new Point(25, 25), 0, _ySpace);

            // Получение точек нейронов скрытого слоя
            _hiddenNeuronPoints = GetNeuronPoints(_neuralNetwork.HiddenLayer.Neurons, new Point(25, 25), 100, _ySpace);

            // Получение точек нейронов выходного слоя
            _outputNeuronPoints = GetNeuronPoints(_neuralNetwork.OutputLayer.Neurons, new Point(25, 25), 200, _ySpace);

            _painterForm.Invoke(progressBarIncrement, 10);

            // Отрисовка связей между нейронами входного и скрытого слоях
            _inputHiddenRelationPoints = DrawRelations(new Pen(Color.Green), _inputNeuronPoints, _hiddenNeuronPoints);
            _painterForm.Invoke(progressBarIncrement, 20);

            // Отрисовка связей между нейронами скрытого и выходного слоях
            _hiddenOutputRelationPoints = DrawRelations(new Pen(Color.Green), _hiddenNeuronPoints, _outputNeuronPoints);
            _painterForm.Invoke(progressBarIncrement, 20);

            // Отрисовка нейронов входного слоя
            DrawNeurons(new Pen(Color.Green), _inputNeuronPoints);
            _painterForm.Invoke(progressBarIncrement, 20);

            // Отрисовка нейронов скрытого слоя
            DrawNeurons(new Pen(Color.Blue), _hiddenNeuronPoints);
            _painterForm.Invoke(progressBarIncrement, 20);

            // Отрисовка нейронов выходного слоя
            DrawNeurons(new Pen(Color.Red), _outputNeuronPoints);
            _painterForm.Invoke(progressBarIncrement, 10);

            SaveImageToPictureBox();
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

        private void DrawNeurons(Pen pen, Point[] neuronPoints)
        {
            for (int i = 0; i < neuronPoints.Length; i++)
            {
                _currentGraphics.DrawEllipse(pen, new RectangleF(neuronPoints[i].X, neuronPoints[i].Y, _widthNeuron, _heightNeuron));
            }
        }

        private Point[] GetNeuronPoints(Neuron[] neurons, Point initialLeftCorner, int xSpace, int ySpace)
        {
            var neuronPoints = new Point[neurons.Length];
            var x = initialLeftCorner.X + xSpace;
            var y = initialLeftCorner.Y;
            for (int i = 0; i < neurons.Length; i++)
            {
                neuronPoints[i] = new Point(x, y);
                y += ySpace;
            }
            return neuronPoints;
        }

        private void SaveImageToPictureBox()
        {
            _bitmap.Save(ImageName);
        }

        public void Dispose()
        {
            if (_currentGraphics != null)
            {
                _currentGraphics.Dispose();
            }
            if (_bitmap != null)
            {
                _bitmap.Dispose();
            }
        }
    }
}
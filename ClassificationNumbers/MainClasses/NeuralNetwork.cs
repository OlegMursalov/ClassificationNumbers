using ClassificationNumbers.DataDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace ClassificationNumbers.MainClasses
{
    public class NeuralNetwork
    {
        private readonly double _helperNum = 100;
        private double _alpha;
        private double _minWeight;
        private double _maxWeight;
        private FunctionActivation _funcActivation;

        public Layer InputLayer { get; }
        public Layer HiddenLayer { get; }
        public Layer OutputLayer { get; }

        public Relation[,] InputHiddenRelations { get; }
        public Relation[,] HiddenOutputRelations { get; }

        public NeuralNetwork(FunctionActivation funcActivation, int amountInputNeurons, int amountHiddenNeurons, int amountOutputNeurons, double alpha, double minWeight, double maxWeight)
        {
            _funcActivation = funcActivation;
            InputLayer = new Layer(amountInputNeurons);
            HiddenLayer = new Layer(funcActivation, amountHiddenNeurons);
            OutputLayer = new Layer(funcActivation, amountOutputNeurons);
            _alpha = alpha;
            _minWeight = minWeight;
            _maxWeight = maxWeight;
            InputHiddenRelations = CreateRelations(InputLayer, HiddenLayer);
            HiddenOutputRelations = CreateRelations(HiddenLayer, OutputLayer);
        }

        private Relation[,] CreateRelations(Layer layer1, Layer layer2)
        {
            var rand = new Random();
            var minW = (int)(_minWeight * _helperNum);
            var maxW = (int)(_maxWeight * _helperNum);
            var relations = new Relation[layer1.Neurons.Length, layer2.Neurons.Length];
            for (int i = 0; i < layer1.Neurons.Length; i++)
            {
                for (int j = 0; j < layer2.Neurons.Length; j++)
                {
                    var initialWeight = (double)rand.Next(minW, maxW) / _helperNum;
                    relations[i, j] = new Relation(layer1.Neurons[i], layer2.Neurons[j], initialWeight);
                }
            }
            return relations;
        }

        /// <summary>
        /// Главный метод нейросети - обучение
        /// </summary>
        public void Learn(Dictionary<int, DataNumberDTO_5x5> data)
        {
            // Поэтапная тренировка по каждой картинке
            for (var i = 0; i < data.Count; i++)
            {
                var rightAnswer = data[i].Number;
                var signals = data[i].ImageRGBComponents;
                signals = CalcOutputSignalsFromLayer(signals, HiddenLayer, InputHiddenRelations);
                signals = CalcOutputSignalsFromLayer(signals, OutputLayer, HiddenOutputRelations);
            }
        }

        /// <summary>
        /// Получение выходных сигналов для слоя
        /// </summary>
        /// <returns></returns>
        public double[] CalcOutputSignalsFromLayer(double[] inputSignals, Layer outputLayer, Relation[,] relations)
        {
            var array = new double[inputSignals.Length];
            for (int i = 0; i < outputLayer.Neurons.Length; i++)
            {
                double sumX = 0;
                var outputNeuron = outputLayer.Neurons[i];
                for (int j = 0; j < relations.Length; j++)
                {
                    var relation = relations[j, i];
                    if (relation.OutputNeuron.Number == outputNeuron.Number)
                    {
                        sumX += relation.Weight * inputSignals[j];
                    }
                }
                array[i] = sumX;
            }
            return array;
        }
    }
}
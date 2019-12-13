using CommonLibrary.DataDTO;
using System;
using System.Collections.Generic;

namespace ClassificationNumbers.MainClasses
{
    public class NeuralNetwork
    {
        private readonly double _helperNum = 100;
        private readonly double _expectedSignal = 1;

        private double _alpha;
        private double _minWeight;
        private double _maxWeight;
        private FunctionActivation _funcActivation;

        public Layer InputLayer { get; }
        public Layer HiddenLayer { get; }
        public Layer OutputLayer { get; }

        public Relation[,] InputHiddenRelations { get; }
        public Relation[,] HiddenOutputRelations { get; }

        /// <summary>
        /// Функция активации
        /// </summary>
        public double CalcOutputSignal(double inputSignal)
        {
            if (_funcActivation == FunctionActivation.None)
            {
                return inputSignal;
            }
            else if (_funcActivation == FunctionActivation.Sigmoida)
            {
                return (1 / (1 + Math.Pow(Math.E, -inputSignal)));
            }
            return inputSignal;
        }

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

                // Вычисление комбинированного и сглаженного сигнала, пропущенного через сигмоиду,
                // данный сигнал прошел через все узлы и вышел из output layer
                var signals = data[i].ImageRGBComponents;
                signals = CalcSignalsFromLayer(signals, InputLayer, HiddenLayer, InputHiddenRelations);
                var outputSignals = CalcSignalsFromLayer(signals, HiddenLayer, OutputLayer, HiddenOutputRelations);

                // Обновление весов на нужных ребрах, в зависимости от ошибки и правильного ответа
                UpdateWeights(HiddenLayer, HiddenOutputRelations, outputSignals, rightAnswer);
                UpdateWeights(InputLayer, InputHiddenRelations, outputSignals, rightAnswer);
            }
        }

        /// <summary>
        /// Вычисление сглаженного и комбинированного сигналов для нейронов следующего слоя, пропущенных через функцию активации
        /// </summary>
        private double[] CalcSignalsFromLayer(double[] inputSignals, Layer inputLayer, Layer outputLayer, Relation[,] relations)
        {
            var array = new double[inputSignals.Length];
            for (int i = 0; i < outputLayer.Neurons.Length; i++)
            {
                double sumX = 0;
                for (int j = 0; j < inputLayer.Neurons.Length; j++)
                {
                    sumX += inputSignals[j] * relations[j, i].Weight;
                }
                array[i] = CalcOutputSignal(sumX);
            }
            return array;
        }

        public double DerivateByFuncActivation()
        {
            if (_funcActivation == FunctionActivation.None)
            {
                return 0;
            }
            else if (_funcActivation == FunctionActivation.Sigmoida)
            {
                
            }
            return 0;
        }

        /// <summary>
        /// Нахождение ошибки только для одного выходного нейрона (так как нас интересует, по сути, только один нейрон),
        /// но при этом деление этой ошибки пропорционально на каждое ребро, которое входит в этот нейрон из предыдущего слоя.
        /// Затем обновление веса, используя производную от функции активации (градиентный спуск).
        /// </summary>
        private void UpdateWeights(Layer layer, Relation[,] relations, double[] outputSignals, int numberOutputNeuron)
        {
            // Забираем выходной сигнал из нейрона, ответственного за эту цифру
            var mainOutputSignal = outputSignals[numberOutputNeuron];

            // Ошибка будет ожидаемый сигнал (_expectedSignal) минус фактический (0.53, например) и все в квадрате, чтобы уйти от знака минуса
            var mainError = Math.Pow(_expectedSignal - mainOutputSignal, 2);

            #region [Думаю, можно уйти от разделения ошибки на ребра, пропорционально весу]
            // Теперь будем делить ошибку на каждое ребро пропорционально весу ребра
            // var errors = new double[outputSignals.Length];

            // Найдем сумму всех весов, связанных с выходным нейроном
            /*double commonWeights = 0;
            for (int i = 0; i < relations.Length; i++)
            {
                commonWeights += relations[i, numberOutputNeuron].Weight;
            }

            // Найдем части ошибок, распределенных пропорционально весам для будущего обновления весов
            var partsOfMainError = new double[relations.Length];
            for (int i = 0; i < relations.Length; i++)
            {
                partsOfMainError[i] = (relations[i, numberOutputNeuron].Weight / commonWeights) * mainError;
            }*/
            #endregion

            // Обновляем веса по методу градиентного спуска (используя коэффициент обучения и производную от функции активации)
            // Коэффициент обучения - это шаг в градиентном спуске
            // Производная по функции активации 
            for (int i = 0; i < relations.Length; i++)
            {
                
            }
        }
    }
}
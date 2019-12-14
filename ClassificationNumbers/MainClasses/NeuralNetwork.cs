using CommonLibrary.DataDTO;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace ClassificationNumbers.MainClasses
{
    public class NeuralNetwork
    {
        private readonly double _helperNum = 100;
        private readonly double _expectedSignal = 1;
        private readonly double _minSignal = 0.01;
        private readonly double _maxSignal = 0.99;

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
        public void Learn(DataNumberDTO_28x28_Set[] dataSet)
        {
            // Поэтапная тренировка по каждой картинке
            for (var i = 0; i < dataSet.Length; i++)
            {
                var rightAnswer = dataSet[i].Number;

                // Трансформирование RGB - компонент в входной сигнал для нейронов входного слоя
                var pixelColors = dataSet[i].PixelColors;
                var signalsFromInputLayer = TransformWhiteBlackPixelsToSignals(pixelColors);

                // Вычисление комбинированного и сглаженного сигнала, пропущенного через сигмоиду,
                // данный сигнал прошел через все узлы и вышел из output layer
                var signalsFromHiddenLayer = CalcSignalsFromLayer(signalsFromInputLayer, InputLayer, HiddenLayer, InputHiddenRelations);
                var signalsFromOutputLayer = CalcSignalsFromLayer(signalsFromHiddenLayer, HiddenLayer, OutputLayer, HiddenOutputRelations);

                // Обновление весов на нужных ребрах, в зависимости от ошибки и правильного ответа
                var errorsHiddenLayer = UpdateWeights(HiddenOutputRelations, signalsFromHiddenLayer, signalsFromOutputLayer, rightAnswer);
                UpdateWeights(errorsHiddenLayer, InputHiddenRelations, signalsFromInputLayer, signalsFromHiddenLayer);
            }
        }

        /// <summary>
        /// Преобразование над RGB - составляющими, превращение их в сигналы в указанном диапазоне.
        /// Данный метод работает только с черно-белыми изображениями.
        /// При этом минимальный сигнал - _minSignal (0.01), чтобы на вход сигмоиды не поступали нули.
        /// </summary>
        private double[] TransformWhiteBlackPixelsToSignals(Color[] pixelColors)
        {
            var signals = new double[pixelColors.Length];
            for (var i = 0; i < pixelColors.Length; i++)
            {
                double sumRgbComponents = pixelColors[i].R + pixelColors[i].G + pixelColors[i].B;
                if (sumRgbComponents <= 10)
                {
                    signals[i] = _minSignal;
                }
                else
                {
                    signals[i] = sumRgbComponents / 1000;
                }
            }
            return signals;
        }

        /// <summary>
        /// Вычисление сглаженного и комбинированного сигналов для нейронов следующего слоя, пропущенных через функцию активации
        /// </summary>
        private double[] CalcSignalsFromLayer(double[] inputSignals, Layer inputLayer, Layer outputLayer, Relation[,] relations)
        {
            var array = new double[outputLayer.Neurons.Length];
            for (int i = 0; i < outputLayer.Neurons.Length; i++)
            {
                double sumX = 0;
                var outNeuron = outputLayer.Neurons[i];
                for (int j = 0; j < inputLayer.Neurons.Length; j++)
                {
                    var inNeuron = inputLayer.Neurons[j];
                    var relation = relations[j, i];
                    if (relation.InputNeuron.Number == inNeuron.Number && relation.OutputNeuron.Number == outNeuron.Number)
                    {
                        sumX += inputSignals[j] * relation.Weight;
                    }
                }
                array[i] = CalcOutputSignal(sumX);
            }
            return array;
        }

        /// <summary>
        /// Производная от функции активации по весу одного ребра
        /// </summary>
        public double DerivateByFuncActivation(double e, double inputSignal, double outputSignal)
        {
            // e - пропорциональная ошибка на нейроне
            // inputSignal - сигнал, который пришел на этот нейрон от предыдущего нейрона из предыдущего слоя
            // outputSignal - комбинированный и сглаженный сигнал, пропущенный через функцию активации на данном нейроне

            if (_funcActivation == FunctionActivation.None)
            {
                return 0;
            }
            else if (_funcActivation == FunctionActivation.Sigmoida)
            {
                return -2 * e * outputSignal * (1 - outputSignal) * inputSignal;
            }
            return 0;
        }

        /// <summary>
        /// Обновление весов по распределенным ошибкам
        /// </summary>
        private void UpdateWeights(double[] errors, Relation[,] relations, double[] inputSignals, double[] outputSignals)
        {
            for (int i = 0; i < errors.Length; i++)
            {
                // Ошибка для текущего нейрона
                var mainError = errors[i];

                // Теперь будем делить ошибку на каждое ребро пропорционально весу ребра, которое входит в текущий нейрон
                var proportionalErrors = new double[outputSignals.Length];

                // Найдем сумму всех весов, связанных с выходным нейроном
                double commonWeights = 0;
                for (int j = 0; j < relations.Length; j++)
                {
                    commonWeights += relations[j, i].Weight;
                }

                // Найдем части ошибок, распределенных пропорционально весам для будущего обновления весов
                for (int j = 0; j < relations.Length; j++)
                {
                    proportionalErrors[i] = (relations[j, i].Weight / commonWeights) * mainError;
                }

                // Обновляем веса по методу градиентного спуска (используя коэффициент обучения и производную от функции активации).
                // Коэффициент обучения - это шаг в градиентном спуске.
                // Производная по функции активации - направление градиента.
                for (int j = 0; j < proportionalErrors.Length; j++)
                {
                    var e = proportionalErrors[j];
                    var inputSignal = inputSignals[j];
                    var outputSignal = outputSignals[j];
                    var derivation = DerivateByFuncActivation(e, inputSignal, outputSignal);
                    var newWeight = relations[i, j].Weight - _alpha * derivation;
                    relations[i, j].SetWeight(newWeight);
                }
            }
        }

        /// <summary>
        /// Нахождение ошибки только для одного выходного нейрона (так как нас интересует, по сути, только один нейрон),
        /// но при этом деление этой ошибки пропорционально на каждое ребро, которое входит в этот нейрон из предыдущего слоя.
        /// Затем обновление весов, используя производную от функции активации (градиентный спуск).
        /// </summary>
        private double[] UpdateWeights(Relation[,] relations, double[] inputSignals, double[] outputSignals, int numberOutputNeuron)
        {
            // Забираем выходной сигнал из нейрона, ответственного за эту цифру
            var mainOutputSignal = outputSignals[numberOutputNeuron];

            // Ошибка будет ожидаемый сигнал (_expectedSignal) минус фактический (0.53, например) и все в квадрате, чтобы уйти от знака минуса
            var mainError = Math.Pow(_expectedSignal - mainOutputSignal, 2);

            // Теперь будем делить ошибку на каждое ребро пропорционально весу ребра
            var proportionalErrors = new double[outputSignals.Length];

            // Найдем сумму всех весов, связанных с выходным нейроном
            double commonWeights = 0;
            for (int i = 0; i < relations.Length / outputSignals.Length; i++)
            {
                commonWeights += relations[i, numberOutputNeuron].Weight;
            }

            // Найдем части ошибок, распределенных пропорционально весам для будущего обновления весов
            for (int i = 0; i < relations.Length / outputSignals.Length; i++)
            {
                proportionalErrors[i] = (relations[i, numberOutputNeuron].Weight / commonWeights) * mainError;
            }

            // Обновляем веса по методу градиентного спуска (используя коэффициент обучения и производную от функции активации).
            // Коэффициент обучения - это шаг в градиентном спуске.
            // Производная по функции активации - направление градиента.
            for (int i = 0; i < proportionalErrors.Length; i++)
            {
                var e = proportionalErrors[i];
                var inputSignal = inputSignals[i];
                var outputSignal = outputSignals[i];
                var derivation = DerivateByFuncActivation(e, inputSignal, outputSignal);
                var newWeight = relations[i, numberOutputNeuron].Weight - _alpha * derivation;
                relations[i, numberOutputNeuron].SetWeight(newWeight);
            }
            
            // Вернем распределенные ошибки для обновления весов на предыдущем слое
            return proportionalErrors;
        }
    }
}
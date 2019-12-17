using CommonLibrary.DataDTO;
using System;
using static CommonLibrary.NeuralNetworks.Delegates;

namespace CommonLibrary.NeuralNetworks
{
    public class Neural3NetworkTeacher
    {
        private Neural3NetworkCreator _neural3NetworkCreator;

        /// <summary>
        /// Функция активации в нейронах в hidden и output слоях
        /// </summary>
        private FuncActivationDelegate _funcActivation;

        /// <summary>
        /// Производная от функции активации в нейронах в hidden и output слоях
        /// </summary>
        private DerivativeOfFuncActivationDelegate _derivativeOfFuncActivation;

        /// <summary>
        /// Ожидаемый сигнал на выходе из нейронов output слоя
        /// </summary>
        private double _expectedSignal;

        /// <summary>
        /// Минимально возможный сигнал
        /// </summary>
        private double _minSignal;

        /// <summary>
        /// Максимально возможный сигнал
        /// </summary>
        private double _maxSignal;

        /// <summary>
        /// Коэффициент обучения нейронной сети (шаг в градиентном спуске)
        /// </summary>
        private double _alpha;

        public Neural3NetworkTeacher(Neural3NetworkCreator neural3NetworkCreator)
        {
            _neural3NetworkCreator = neural3NetworkCreator;
            var funcActivationWorker = new FuncActivationWorker(_neural3NetworkCreator.FuncActivationType);
            _funcActivation = funcActivationWorker.GetFunction();
            _derivativeOfFuncActivation = funcActivationWorker.DerivateByFuncActivation();
        }

        public Neural3NetworkTeacher(Neural3NetworkCreator neural3NetworkCreator, double minSignal, double maxSignal, double expectedSignal, double alpha) : this(neural3NetworkCreator)
        {
            _minSignal = minSignal;
            _maxSignal = maxSignal;
            _expectedSignal = expectedSignal;
            _alpha = alpha;
        }
        
        /// <summary>
        /// Главный метод нейросети - обучение на картинках 28x28 pixels
        /// </summary>
        public void Learn(DataNumberDTO_28x28_Set[] dataSet)
        {
            // Поэтапная тренировка по каждой картинке
            for (var i = 0; i < dataSet.Length; i++)
            {
                var rightAnswer = dataSet[i].Number;

                // Трансформирование ARGB - компонент в входной сигнал для нейронов входного слоя
                var ARGBaComponents = dataSet[i].ARGBAComponents;
                var signalsFromInputLayer = TransformWhiteBlackPixelsToSignals(ARGBaComponents);

                var inputLayer = _neural3NetworkCreator.InputLayer;
                var hiddenLayer = _neural3NetworkCreator.HiddenLayer;
                var outputLayer = _neural3NetworkCreator.OutputLayer;
                var inputHiddenRelations = _neural3NetworkCreator.InputHiddenRelations;
                var hiddenOutputRelations = _neural3NetworkCreator.HiddenOutputRelations;

                // Вычисление комбинированного и сглаженного сигнала, пропущенного через сигмоиду,
                // данный сигнал прошел через все узлы и вышел из output layer
                var signalsFromHiddenLayer = CalcSignalsFromLayer(signalsFromInputLayer, inputLayer, hiddenLayer, inputHiddenRelations);
                var signalsFromOutputLayer = CalcSignalsFromLayer(signalsFromHiddenLayer, hiddenLayer, outputLayer, hiddenOutputRelations);

                // Обновление весов на нужных ребрах, в зависимости от ошибки и правильного ответа
                var errorsHiddenLayer = UpdateWeights(hiddenOutputRelations, signalsFromHiddenLayer, signalsFromOutputLayer, rightAnswer);
                UpdateWeights(errorsHiddenLayer, inputHiddenRelations, signalsFromInputLayer, signalsFromHiddenLayer);
            }
        }

        /// <summary>
        /// Преобразование над ARGB - составляющими, превращение их в сигналы в указанном диапазоне.
        /// Данный метод работает только с черно-белыми изображениями.
        /// </summary>
        private double[] TransformWhiteBlackPixelsToSignals(ColorSimplifiedDTO[] ARGBaComponents)
        {
            var signals = new double[ARGBaComponents.Length];
            for (var i = 0; i < ARGBaComponents.Length; i++)
            {
                double sumARGBaComponents = ARGBaComponents[i].R + ARGBaComponents[i].G + ARGBaComponents[i].B + ARGBaComponents[i].A;
                signals[i] = (sumARGBaComponents + 1) / 1022;
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
                array[i] = _funcActivation.Invoke(sumX);
            }
            return array;
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
                    var derivation = _derivativeOfFuncActivation.Invoke(e, inputSignal, outputSignal);
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
                var derivation = _derivativeOfFuncActivation.Invoke(e, inputSignal, outputSignal);
                var newWeight = relations[i, numberOutputNeuron].Weight - _alpha * derivation;
                relations[i, numberOutputNeuron].SetWeight(newWeight);
            }

            // Вернем распределенные ошибки для обновления весов на предыдущем слое
            return proportionalErrors;
        }
    }
}
using CommonLibrary.DataDTO;
using CommonLibrary.Helpers;
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
        public double ExpectedSignal { get; }

        /// <summary>
        /// Минимально возможный сигнал
        /// </summary>
        public double MinSignal { get; }

        /// <summary>
        /// Максимально возможный сигнал
        /// </summary>
        public double MaxSignal { get; }

        /// <summary>
        /// Коэффициент обучения нейронной сети (шаг в градиентном спуске)
        /// </summary>
        public double Alpha { get; }

        public Neural3NetworkTeacher(Neural3NetworkCreator neural3NetworkCreator)
        {
            _neural3NetworkCreator = neural3NetworkCreator;
            var funcActivationWorker = new FuncActivationWorker(_neural3NetworkCreator.FuncActivationType);
            _funcActivation = funcActivationWorker.GetFunction();
            _derivativeOfFuncActivation = funcActivationWorker.DerivateByFuncActivation();
        }

        public Neural3NetworkTeacher(Neural3NetworkCreator neural3NetworkCreator, double minSignal, double maxSignal, double expectedSignal, double alpha) : this(neural3NetworkCreator)
        {
            MinSignal = minSignal;
            MaxSignal = maxSignal;
            ExpectedSignal = expectedSignal;
            Alpha = alpha;
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

                var neural3NetworkHelper = new Neural3NetworkHelper(_neural3NetworkCreator);

                // Трансформирование ARGB - компонент в входной сигнал для нейронов входного слоя
                var rgbaComponents = dataSet[i].RGBAComponents;
                var signalsFromInputLayer = neural3NetworkHelper.TransformWhiteBlackPixelsToSignals(rgbaComponents, MinSignal, MaxSignal, ExpectedSignal);

                var inputLayer = _neural3NetworkCreator.InputLayer;
                var hiddenLayer = _neural3NetworkCreator.HiddenLayer;
                var outputLayer = _neural3NetworkCreator.OutputLayer;
                var inputHiddenRelations = neural3NetworkHelper.GetInputHiddenRelations();
                var hiddenOutputRelations = neural3NetworkHelper.GetHiddenOutputRelations();

                // Вычисление комбинированного и сглаженного сигнала, пропущенного через сигмоиду,
                // данный сигнал прошел через все узлы и вышел из output layer
                var signalsFromHiddenLayer = neural3NetworkHelper.CalcSignalsFromLayer(signalsFromInputLayer, inputLayer, hiddenLayer, inputHiddenRelations, _funcActivation);
                var signalsFromOutputLayer = neural3NetworkHelper.CalcSignalsFromLayer(signalsFromHiddenLayer, hiddenLayer, outputLayer, hiddenOutputRelations, _funcActivation);

                // Обновление весов на нужных ребрах, в зависимости от ошибки и правильного ответа
                var errorsHiddenLayer = UpdateWeights(hiddenOutputRelations, signalsFromHiddenLayer, signalsFromOutputLayer, rightAnswer);
                UpdateWeights(errorsHiddenLayer, inputHiddenRelations, signalsFromInputLayer, signalsFromHiddenLayer);
            }
        }

        /// <summary>
        /// Обновление весов по распределенным ошибкам
        /// </summary>
        private void UpdateWeights(double[] errors, Relation[,] relations, double[] inputSignals, double[] outputSignals)
        {
            for (int i = 0; i < errors.Length; i++)
            {
                // Узнаем выходной сигнал из нейрона
                var mainOutputSignal = outputSignals[i];

                // Ошибка для текущего нейрона
                var mainError = errors[i];

                // Теперь будем делить ошибку на каждое ребро пропорционально весу ребра, которое входит в текущий нейрон
                var proportionalErrors = new double[inputSignals.Length];

                // Найдем сумму всех весов, связанных с выходным нейроном
                double commonWeights = 0;
                for (int j = 0; j < relations.GetLength(0); j++)
                {
                    commonWeights += relations[j, i].Weight;
                }

                // Найдем части ошибок, распределенных пропорционально весам для будущего обновления весов
                for (int j = 0; j < relations.GetLength(0); j++)
                {
                    proportionalErrors[j] = (relations[j, i].Weight / commonWeights) * mainError;
                }

                // Обновляем веса по методу градиентного спуска (используя коэффициент обучения и производную от функции активации).
                // Коэффициент обучения - это шаг в градиентном спуске.
                // Производная по функции активации - направление градиента.
                for (int j = 0; j < proportionalErrors.Length; j++)
                {
                    var e = proportionalErrors[j];
                    var inputSignal = inputSignals[j];
                    var derivation = _derivativeOfFuncActivation.Invoke(e, inputSignal, mainOutputSignal);
                    var newWeight = relations[j, i].Weight - Alpha * derivation;
                    relations[j, i].SetWeight(newWeight);
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
            var mainError = Math.Pow(ExpectedSignal - mainOutputSignal, 2);

            // Теперь будем делить ошибку на каждое ребро пропорционально весу ребра
            var proportionalErrors = new double[inputSignals.Length];

            // Найдем сумму всех весов, связанных с выходным нейроном
            double commonWeights = 0;
            for (int i = 0; i < relations.GetLength(0); i++)
            {
                commonWeights += relations[i, numberOutputNeuron].Weight;
            }

            // Найдем части ошибок, распределенных пропорционально весам для будущего обновления весов
            for (int i = 0; i < relations.GetLength(0); i++)
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
                var derivation = _derivativeOfFuncActivation.Invoke(e, inputSignal, mainOutputSignal);
                var newWeight = relations[i, numberOutputNeuron].Weight - Alpha * derivation;
                relations[i, numberOutputNeuron].SetWeight(newWeight);
            }

            // Вернем распределенные ошибки для обновления весов на предыдущем слое
            return proportionalErrors;
        }
    }
}
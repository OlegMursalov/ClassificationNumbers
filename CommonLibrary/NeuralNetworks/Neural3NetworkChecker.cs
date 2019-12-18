using CommonLibrary.DataDTO;
using CommonLibrary.Helpers;
using static CommonLibrary.NeuralNetworks.Delegates;

namespace CommonLibrary.NeuralNetworks
{
    public class Neural3NetworkChecker
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

        public Neural3NetworkChecker(Neural3NetworkCreator neural3NetworkCreator)
        {
            _neural3NetworkCreator = neural3NetworkCreator;
            var funcActivationWorker = new FuncActivationWorker(_neural3NetworkCreator.FuncActivationType);
            _funcActivation = funcActivationWorker.GetFunction();
            _derivativeOfFuncActivation = funcActivationWorker.DerivateByFuncActivation();
        }

        public Neural3NetworkChecker(Neural3NetworkCreator neural3NetworkCreator, double minSignal, double maxSignal, double expectedSignal) : this(neural3NetworkCreator)
        {
            _minSignal = minSignal;
            _maxSignal = maxSignal;
            _expectedSignal = expectedSignal;
        }

        /// <summary>
        /// Главный метод нейросети - обучение на картинках 28x28 pixels
        /// </summary>
        public OutputSignalDTO Check(DataNumberDTO_28x28_Set imageDataSet)
        {
            var rightAnswer = imageDataSet.Number;

            var neural3NetworkHelper = new Neural3NetworkHelper(_neural3NetworkCreator);

            // Трансформирование ARGB - компонент в входной сигнал для нейронов входного слоя
            var rgbaComponents = imageDataSet.RGBAComponents;
            var signalsFromInputLayer = neural3NetworkHelper.TransformWhiteBlackPixelsToSignals(rgbaComponents, _minSignal, _maxSignal, _expectedSignal);

            var inputLayer = _neural3NetworkCreator.InputLayer;
            var hiddenLayer = _neural3NetworkCreator.HiddenLayer;
            var outputLayer = _neural3NetworkCreator.OutputLayer;
            var inputHiddenRelations = neural3NetworkHelper.GetInputHiddenRelations();
            var hiddenOutputRelations = neural3NetworkHelper.GetHiddenOutputRelations();

            // Вычисление комбинированного и сглаженного сигнала, пропущенного через сигмоиду,
            // данный сигнал прошел через все узлы и вышел из output layer
            var signalsFromHiddenLayer = neural3NetworkHelper.CalcSignalsFromLayer(signalsFromInputLayer, inputLayer, hiddenLayer, inputHiddenRelations, _funcActivation);
            var signalsFromOutputLayer = neural3NetworkHelper.CalcSignalsFromLayer(signalsFromHiddenLayer, hiddenLayer, outputLayer, hiddenOutputRelations, _funcActivation);

            return neural3NetworkHelper.GetOutputSignalDTO(signalsFromOutputLayer);
        }
    }
}
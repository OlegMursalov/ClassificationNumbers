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

        public Neural3NetworkChecker(Neural3NetworkCreator neural3NetworkCreator)
        {
            _neural3NetworkCreator = neural3NetworkCreator;
            var funcActivationWorker = new FuncActivationWorker(_neural3NetworkCreator.FuncActivationType);
            _funcActivation = funcActivationWorker.GetFunction();
            _derivativeOfFuncActivation = funcActivationWorker.DerivateByFuncActivation();
        }

        /// <summary>
        /// Главный метод нейросети - обучение на картинках 28x28 pixels
        /// </summary>
        public OutputSignalDTO Check(DataNumberDTO_28x28_Set imageDataSet, out double[] signalsFromInputLayer, out double[] signalsFromHiddenLayer, out double[] signalsFromOutputLayer)
        {
            var rightAnswer = imageDataSet.Number;

            var neural3NetworkHelper = new Neural3NetworkHelper(_neural3NetworkCreator);

            // Трансформирование RGB - компонент в входной сигнал для нейронов входного слоя
            var RGBComponents = imageDataSet.RGBComponents;
            signalsFromInputLayer = neural3NetworkHelper.TransformWhiteBlackPixelsToSignals(RGBComponents);

            var inputLayer = _neural3NetworkCreator.InputLayer;
            var hiddenLayer = _neural3NetworkCreator.HiddenLayer;
            var outputLayer = _neural3NetworkCreator.OutputLayer;
            var inputHiddenRelations = neural3NetworkHelper.GetInputHiddenRelations();
            var hiddenOutputRelations = neural3NetworkHelper.GetHiddenOutputRelations();

            // Вычисление комбинированного и сглаженного сигнала, пропущенного через сигмоиду,
            // данный сигнал прошел через все узлы и вышел из output layer
            signalsFromHiddenLayer = neural3NetworkHelper.CalcSignalsFromLayer(signalsFromInputLayer, inputLayer, hiddenLayer, inputHiddenRelations, _funcActivation);
            signalsFromOutputLayer = neural3NetworkHelper.CalcSignalsFromLayer(signalsFromHiddenLayer, hiddenLayer, outputLayer, hiddenOutputRelations, _funcActivation);

            return neural3NetworkHelper.GetOutputSignalDTO(signalsFromOutputLayer);
        }
    }
}
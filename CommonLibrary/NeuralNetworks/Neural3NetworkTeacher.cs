using CommonLibrary.DataDTO;
using CommonLibrary.Helpers;
using System;
using static CommonLibrary.NeuralNetworks.Delegates;

namespace CommonLibrary.NeuralNetworks
{
    public class Neural3NetworkTeacher
    {
        public Neural3NetworkCreator Neural3NetworkCreator { get; }

        /// <summary>
        /// Функция активации в нейронах в hidden и output слоях
        /// </summary>
        private FuncActivationDelegate _funcActivation;

        /// <summary>
        /// Производная от функции активации в нейронах в hidden и output слоях
        /// </summary>
        public DerivativeOfFuncActivationDelegate DerivativeOfFuncActivation { get; }

        /// <summary>
        /// Коэффициент обучения нейронной сети (шаг в градиентном спуске)
        /// </summary>
        public double Alpha { get; }

        public Neural3NetworkTeacher(Neural3NetworkCreator neural3NetworkCreator)
        {
            Neural3NetworkCreator = neural3NetworkCreator;
            var funcActivationWorker = new FuncActivationWorker(Neural3NetworkCreator.FuncActivationType);
            _funcActivation = funcActivationWorker.GetFunction();
            DerivativeOfFuncActivation = funcActivationWorker.DerivateByFuncActivation();
        }

        public Neural3NetworkTeacher(Neural3NetworkCreator neural3NetworkCreator, double alpha) : this(neural3NetworkCreator)
        {
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

                var neural3NetworkHelper = new Neural3NetworkHelper(Neural3NetworkCreator);

                // Трансформирование RGB - компонент в входной сигнал для нейронов входного слоя
                var RGBComponents = dataSet[i].RGBComponents;
                var signalsFromInputLayer = neural3NetworkHelper.TransformWhiteBlackPixelsToSignals(RGBComponents);

                var inputLayer = Neural3NetworkCreator.InputLayer;
                var hiddenLayer = Neural3NetworkCreator.HiddenLayer;
                var outputLayer = Neural3NetworkCreator.OutputLayer;
                var inputHiddenRelations = neural3NetworkHelper.GetInputHiddenRelations();
                var hiddenOutputRelations = neural3NetworkHelper.GetHiddenOutputRelations();

                // Вычисление комбинированного и сглаженного сигнала, пропущенного через сигмоиду,
                // данный сигнал прошел через все узлы и вышел из output layer
                var signalsFromHiddenLayer = neural3NetworkHelper.CalcSignalsFromLayer(signalsFromInputLayer, inputLayer, hiddenLayer, inputHiddenRelations, _funcActivation);
                var signalsFromOutputLayer = neural3NetworkHelper.CalcSignalsFromLayer(signalsFromHiddenLayer, hiddenLayer, outputLayer, hiddenOutputRelations, _funcActivation);

                var neural3NetworkWeightsUpdater = new Neural3NetworkWeightsUpdater(this, signalsFromInputLayer, signalsFromHiddenLayer, signalsFromOutputLayer);

                // Обновление весов на нужных ребрах, в зависимости от ошибки и правильного ответа
                var errorsHiddenLayer = neural3NetworkWeightsUpdater.UpdateWeights(hiddenOutputRelations, signalsFromHiddenLayer, signalsFromOutputLayer, rightAnswer);
                neural3NetworkWeightsUpdater.UpdateWeights(errorsHiddenLayer, inputHiddenRelations, signalsFromInputLayer, signalsFromHiddenLayer);
            }
        }
    }
}
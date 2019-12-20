using CommonLibrary.Consts;
using System;

namespace CommonLibrary.NeuralNetworks
{
    public class Neural3NetworkWeightsUpdater
    {
        public Neural3NetworkTeacher Neural3NetworkTeacher { get; }

        public double[] SignalsFromInputLayer { get; }
        public double[] SignalsFromHiddenLayer { get; }
        public double[] SignalsFromOutputLayer { get; }

        public Neural3NetworkWeightsUpdater(Neural3NetworkTeacher neural3NetworkTeacher, double[] signalsFromInputLayer, double[] signalsFromHiddenLayer, double[] signalsFromOutputLayer)
        {
            Neural3NetworkTeacher = neural3NetworkTeacher;
            SignalsFromInputLayer = signalsFromInputLayer;
            SignalsFromHiddenLayer = signalsFromHiddenLayer;
            SignalsFromOutputLayer = signalsFromOutputLayer;
        }

        /// <summary>
        /// Обновление весов по распределенным ошибкам
        /// </summary>
        public void UpdateWeights(double[] errors, Relation[,] relations, double[] inputSignals, double[] outputSignals)
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
                    var derivation = Neural3NetworkTeacher.DerivativeOfFuncActivation.Invoke(e, inputSignal, mainOutputSignal);
                    var newWeight = relations[j, i].Weight - Neural3NetworkTeacher.Alpha * derivation;
                    relations[j, i].SetWeight(newWeight);
                }
            }
        }

        /// <summary>
        /// Нахождение ошибки только для одного выходного нейрона (так как нас интересует, по сути, только один нейрон),
        /// но при этом деление этой ошибки пропорционально на каждое ребро, которое входит в этот нейрон из предыдущего слоя.
        /// Затем обновление весов, используя производную от функции активации (градиентный спуск).
        /// </summary>
        public double[] UpdateWeights(Relation[,] relations, double[] inputSignals, double[] outputSignals, int numberOutputNeuron)
        {
            var expectedSignal = Neural3NetworkConsts.ExpectedSignal;

            // Забираем выходной сигнал из нейрона, ответственного за эту цифру
            var mainOutputSignal = outputSignals[numberOutputNeuron];

            // Ошибка будет ожидаемый сигнал (_expectedSignal) минус фактический (0.53, например) и все в квадрате, чтобы уйти от знака минуса
            var mainError = Math.Pow(expectedSignal - mainOutputSignal, 2);

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
                var derivation = Neural3NetworkTeacher.DerivativeOfFuncActivation.Invoke(e, inputSignal, mainOutputSignal);
                var newWeight = relations[i, numberOutputNeuron].Weight - Neural3NetworkTeacher.Alpha * derivation;
                relations[i, numberOutputNeuron].SetWeight(newWeight);
            }

            // Вернем распределенные ошибки для обновления весов на предыдущем слое
            return proportionalErrors;
        }
    }
}
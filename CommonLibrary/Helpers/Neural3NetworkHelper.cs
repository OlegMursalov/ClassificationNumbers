using CommonLibrary.DataDTO;
using CommonLibrary.NeuralNetworks;
using static CommonLibrary.NeuralNetworks.Delegates;

namespace CommonLibrary.Helpers
{
    public class Neural3NetworkHelper
    {
        private Neural3NetworkCreator _neural3NetworkCreator;

        public Neural3NetworkHelper(Neural3NetworkCreator neural3NetworkCreator)
        {
            _neural3NetworkCreator = neural3NetworkCreator;
        }

        /// <summary>
        /// Возвращает двумерный массив связей между нейронами входного и скрытого слоев
        /// </summary>
        public Relation[,] GetInputHiddenRelations()
        {
            return GetRelations(_neural3NetworkCreator.InputLayer, _neural3NetworkCreator.HiddenLayer, _neural3NetworkCreator.InputHiddenRelations);
        }

        /// <summary>
        /// Возвращает двумерный массив связей между нейронами скрытого и выходного слоев
        /// </summary>
        public Relation[,] GetHiddenOutputRelations()
        {
            return GetRelations(_neural3NetworkCreator.HiddenLayer, _neural3NetworkCreator.OutputLayer, _neural3NetworkCreator.HiddenOutputRelations);
        }

        private Relation[,] GetRelations(Layer layer1, Layer layer2, Relation[] relations)
        {
            var c = 0;
            var hiddenNeuronsAmount = layer1.Neurons.Length;
            var outputNeuronsAmount = layer2.Neurons.Length;
            var newRelations = new Relation[hiddenNeuronsAmount, outputNeuronsAmount];
            for (int i = 0; i < hiddenNeuronsAmount; i++)
            {
                for (int j = 0; j < outputNeuronsAmount; j++)
                {
                    newRelations[i, j] = relations[c];
                    c++;
                }
            }
            return newRelations;
        }

        /// <summary>
        /// Преобразование над ARGB - составляющими, превращение их в сигналы в указанном диапазоне.
        /// Данный метод работает только с черно-белыми изображениями.
        /// </summary>
        public double[] TransformWhiteBlackPixelsToSignals(ColorSimplifiedDTO[] rgbaComponents, double minSignal, double maxSignal, double expectedSignal)
        {
            var signals = new double[rgbaComponents.Length];
            for (var i = 0; i < rgbaComponents.Length; i++)
            {
                double sumRGBAComponents = rgbaComponents[i].R + rgbaComponents[i].G + rgbaComponents[i].B + rgbaComponents[i].A;
                signals[i] = maxSignal / (sumRGBAComponents + minSignal + expectedSignal);
            }
            return signals;
        }

        /// <summary>
        /// Вычисление сглаженного и комбинированного сигналов для нейронов следующего слоя, пропущенных через функцию активации
        /// </summary>
        public double[] CalcSignalsFromLayer(double[] inputSignals, Layer inputLayer, Layer outputLayer, Relation[,] relations, FuncActivationDelegate funcActivation)
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
                array[i] = funcActivation.Invoke(sumX);
            }
            return array;
        }

        public OutputSignalDTO GetOutputSignalDTO(double[] signalsFromOutputLayer)
        {
            int number = 0;
            double maxSignal = 0;

            for (int i = 0; i < signalsFromOutputLayer.Length; i++)
            {
                var signal = signalsFromOutputLayer[i];
                if (signal > maxSignal)
                {
                    number = i;
                    maxSignal = signal;
                }
            }

            return new OutputSignalDTO
            {
                NeuronNumber = number,
                Signal = maxSignal
            };
        }
    }
}
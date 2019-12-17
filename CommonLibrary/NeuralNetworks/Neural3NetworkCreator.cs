using System;

namespace CommonLibrary.NeuralNetworks
{
    /// <summary>
    /// Создатель трехслойной нейронной сети
    /// </summary>
    public class Neural3NetworkCreator
    {
        /// <summary>
        /// Коэффициент обучения нейронной сети (шаг в градиентном спуске)
        /// </summary>
        public double Alpha { get; }

        /// <summary>
        /// Минимально возможный вес для ребра между нейронами
        /// </summary>
        public double MinWeight { get; }

        /// <summary>
        /// Максимально возможный вес для ребра между нейронами
        /// </summary>
        public double MaxWeight { get; }

        /// <summary>
        /// Тип функции активации в нейронах в hidden и output слоях
        /// </summary>
        public FunctionActivationEnum FuncActivationType { get; }

        public delegate double FuncActivationDelegate(double inputSignal);

        /// <summary>
        /// Делегат функции активации в нейронах в hidden и output слоях
        /// </summary>
        public FuncActivationDelegate FuncActivation;

        /// <summary>
        /// Вспомогательное число
        /// </summary>
        public double HelperNum { get; } = 100;

        /// <summary>
        /// Ожидаемый сигнал на выходе из нейронов output слоя
        /// </summary>
        public double ExpectedSignal { get; } = 1;

        /// <summary>
        /// Минимально возможный сигнал
        /// </summary>
        public double MinSignal { get; } = 0.01;

        /// <summary>
        /// Максимально возможный сигнал
        /// </summary>
        public double MaxSignal { get; } = 0.99;

        public Layer InputLayer { get; }
        public Layer HiddenLayer { get; }
        public Layer OutputLayer { get; }

        public Relation[,] InputHiddenRelations { get; }
        public Relation[,] HiddenOutputRelations { get; }

        public Neural3NetworkCreator(FunctionActivationEnum funcActivationType, int amountInputNeurons, int amountHiddenNeurons, int amountOutputNeurons, double alpha, double minWeight, double maxWeight)
        {
            FuncActivationType = funcActivationType;
            var funcActivationConverter = new FuncActivationWorker(FuncActivationType);
            FuncActivation = funcActivationConverter.GetFunction();
            InputLayer = new Layer(amountInputNeurons);
            HiddenLayer = new Layer(FuncActivationType, amountHiddenNeurons);
            OutputLayer = new Layer(FuncActivationType, amountOutputNeurons);
            Alpha = alpha;
            MinWeight = minWeight;
            MaxWeight = maxWeight;
            InputHiddenRelations = CreateRelations(InputLayer, HiddenLayer);
            HiddenOutputRelations = CreateRelations(HiddenLayer, OutputLayer);
        }

        private Relation[,] CreateRelations(Layer layer1, Layer layer2)
        {
            var rand = new Random();
            var minW = (int)(MinWeight * HelperNum);
            var maxW = (int)(MaxWeight * HelperNum);
            var relations = new Relation[layer1.Neurons.Length, layer2.Neurons.Length];
            for (int i = 0; i < layer1.Neurons.Length; i++)
            {
                for (int j = 0; j < layer2.Neurons.Length; j++)
                {
                    var initialWeight = (double)rand.Next(minW, maxW) / HelperNum;
                    relations[i, j] = new Relation(layer1.Neurons[i], layer2.Neurons[j], initialWeight);
                }
            }
            return relations;
        }
    }
}
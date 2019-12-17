using System;
using System.Runtime.Serialization;

namespace CommonLibrary.NeuralNetworks
{
    /// <summary>
    /// Создатель трехслойной нейронной сети
    /// </summary>
    [DataContract]
    public class Neural3NetworkCreator
    {
        /// <summary>
        /// Минимально возможный вес для ребра между нейронами
        /// </summary>
        [DataMember]
        public double MinWeight { get; private set; }

        /// <summary>
        /// Максимально возможный вес для ребра между нейронами
        /// </summary>
        [DataMember]
        public double MaxWeight { get; private set; }

        /// <summary>
        /// Вспомогательное число
        /// </summary>
        [DataMember]
        public double HelperNum { get; private set; } = 100;

        /// <summary>
        /// Тип функции активации в нейронах в hidden и output слоях
        /// </summary>
        [DataMember]
        public FunctionActivationEnum FuncActivationType { get; private set; }

        [DataMember]
        public Layer InputLayer { get; private set; }

        [DataMember]
        public Layer HiddenLayer { get; private set; }

        [DataMember]
        public Layer OutputLayer { get; private set; }

        [DataMember]
        public Relation[] InputHiddenRelations { get; private set; }

        [DataMember]
        public Relation[] HiddenOutputRelations { get; private set; }

        public Neural3NetworkCreator(FunctionActivationEnum funcActivationType, int amountInputNeurons, int amountHiddenNeurons, int amountOutputNeurons, double minWeight, double maxWeight)
        {
            FuncActivationType = funcActivationType;
            var funcActivationConverter = new FuncActivationWorker(FuncActivationType);
            InputLayer = new Layer(amountInputNeurons);
            HiddenLayer = new Layer(FuncActivationType, amountHiddenNeurons);
            OutputLayer = new Layer(FuncActivationType, amountOutputNeurons);
            MinWeight = minWeight;
            MaxWeight = maxWeight;
            InputHiddenRelations = CreateRelations(InputLayer, HiddenLayer);
            HiddenOutputRelations = CreateRelations(HiddenLayer, OutputLayer);
        }

        private Relation[] CreateRelations(Layer layer1, Layer layer2)
        {
            var c = 0;
            var rand = new Random();
            var minW = (int)(MinWeight * HelperNum);
            var maxW = (int)(MaxWeight * HelperNum);
            var relations = new Relation[layer1.Neurons.Length * layer2.Neurons.Length];
            for (int i = 0; i < layer1.Neurons.Length; i++)
            {
                for (int j = 0; j < layer2.Neurons.Length; j++)
                {
                    var initialWeight = (double)rand.Next(minW, maxW) / HelperNum;
                    relations[c] = new Relation(layer1.Neurons[i], layer2.Neurons[j], initialWeight);
                    c++;
                }
            }
            return relations;
        }
    }
}
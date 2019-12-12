using System;

namespace ClassificationNumbers.MainClasses
{
    public class NeuralNetwork
    {
        private readonly int _helperNum = 100;

        private Layer _inputLayer;
        private Layer _hiddenLayer;
        private Layer _outputLayer;
        private float _alpha;
        private float _minWeight;
        private float _maxWeight;

        private Relation[,] _inputHiddenRelations;
        private Relation[,] _hiddenOutputRelations;

        public NeuralNetwork(int amountInputNeurons, int amountHiddenNeurons, int amountOutputNeurons, float alpha, float minWeight, float maxWeight)
        {
            _inputLayer = new Layer(amountInputNeurons);
            _hiddenLayer = new Layer(amountHiddenNeurons);
            _outputLayer = new Layer(amountOutputNeurons);
            _alpha = alpha;
            _minWeight = minWeight;
            _maxWeight = maxWeight;
            _inputHiddenRelations = CreateRelations(_inputLayer, _hiddenLayer);
            _hiddenOutputRelations = CreateRelations(_hiddenLayer, _outputLayer);
        }

        private Relation[,] CreateRelations(Layer layer1, Layer layer2)
        {
            var rand = new Random();
            var minW = (int)_minWeight * _helperNum;
            var maxW = (int)_maxWeight * _helperNum;
            var relations = new Relation[layer1.Neurons.Length, layer2.Neurons.Length];
            for (int i = 0; i < layer1.Neurons.Length; i++)
            {
                for (int j = 0; j < layer2.Neurons.Length; j++)
                {
                    var initialWeight = (float)(rand.Next(minW, maxW) / _helperNum);
                    relations[i, j] = new Relation(layer1.Neurons[i], layer2.Neurons[j], initialWeight);
                }
            }
            return relations;
        }
    }
}
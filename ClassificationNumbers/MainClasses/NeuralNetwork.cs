namespace ClassificationNumbers.MainClasses
{
    public class NeuralNetwork
    {
        private Layer _inputLayer;
        private Layer _hiddenLayer;
        private Layer _outputLayer;

        private Relation[,] _inputHiddenRelations;
        private Relation[,] _hiddenOutputRelations;

        public NeuralNetwork(int amountInputNeurons, int amountHiddenNeurons, int amountOutputNeurons)
        {
            _inputLayer = new Layer(amountInputNeurons);
            _hiddenLayer = new Layer(amountHiddenNeurons);
            _outputLayer = new Layer(amountOutputNeurons);
            _inputHiddenRelations = CreateRelations(_inputLayer, _hiddenLayer);
            _hiddenOutputRelations = CreateRelations(_hiddenLayer, _outputLayer);
        }

        private Relation[,] CreateRelations(Layer layer1, Layer layer2)
        {
            var relations = new Relation[layer1.Neurons.Length, layer2.Neurons.Length];
            for (int i = 0; i < layer1.Neurons.Length; i++)
            {
                for (int j = 0; j < layer2.Neurons.Length; j++)
                {
                    relations[i, j] = new Relation(layer1.Neurons[i], layer2.Neurons[j]);
                }
            }
            return relations;
        }
    }
}
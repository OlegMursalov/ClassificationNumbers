namespace CommonLibrary.NeuralNetworks
{
    public class Layer
    {
        public Neuron[] _neurons;
        private FunctionActivationEnum _functionActivationEnum;

        public Neuron[] Neurons => _neurons;

        public Layer(int amountNeurons)
        {
            _neurons = CreateNeurons(amountNeurons);
        }

        public Layer(FunctionActivationEnum functionActivationEnum, int amountNeurons)
        {
            _functionActivationEnum = functionActivationEnum;
            _neurons = CreateNeurons(amountNeurons);
        }

        private Neuron[] CreateNeurons(int amount)
        {
            var neurons = new Neuron[amount];
            for (int i = 0; i < neurons.Length; i++)
            {
                neurons[i] = new Neuron(i, _functionActivationEnum);
            }
            return neurons;
        }
    }
}
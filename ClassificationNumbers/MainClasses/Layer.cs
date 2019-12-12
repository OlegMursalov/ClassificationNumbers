namespace ClassificationNumbers.MainClasses
{
    public class Layer
    {
        public Neuron[] _neurons;
        private FunctionActivation _funcActivation;

        public Neuron[] Neurons => _neurons;

        public Layer(int amountNeurons)
        {
            _neurons = CreateNeurons(amountNeurons);
        }

        public Layer(FunctionActivation funcActivation, int amountNeurons)
        {
            _funcActivation = funcActivation;
            _neurons = CreateNeurons(amountNeurons);
        }

        private Neuron[] CreateNeurons(int amount)
        {
            var neurons = new Neuron[amount];
            for (int i = 0; i < neurons.Length; i++)
            {

            }
            return neurons;
        }
    }
}
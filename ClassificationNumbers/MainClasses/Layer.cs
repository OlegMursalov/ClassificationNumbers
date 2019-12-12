namespace ClassificationNumbers.MainClasses
{
    public class Layer
    {
        public Neuron[] _neurons;

        public Neuron[] Neurons => _neurons;

        public Layer(int amountNeurons)
        {
            _neurons = new Neuron[amountNeurons];
        }
    }
}
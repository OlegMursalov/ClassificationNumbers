namespace ClassificationNumbers.MainClasses
{
    public class Relation
    {
        private Neuron _inputNeuron;
        private Neuron _outputNeuron;

        public double Weight { get; }

        public Relation(Neuron inputNeuron, Neuron outputNeuron, double weight)
        {
            _inputNeuron = inputNeuron;
            _outputNeuron = outputNeuron;
            Weight = weight;
        }
    }
}
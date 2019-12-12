namespace ClassificationNumbers.MainClasses
{
    public class Relation
    {
        public double Weight { get; }
        public Neuron InputNeuron { get; }
        public Neuron OutputNeuron { get; }

        public Relation(Neuron inputNeuron, Neuron outputNeuron, double weight)
        {
            InputNeuron = inputNeuron;
            OutputNeuron = outputNeuron;
            Weight = weight;
        }
    }
}
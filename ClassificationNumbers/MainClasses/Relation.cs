namespace ClassificationNumbers.MainClasses
{
    public class Relation
    {
        private double _weight;
        private Neuron _inputNeuron;
        private Neuron _outputNeuron;

        public Relation(Neuron inputNeuron, Neuron outputNeuron, double weight)
        {
            _inputNeuron = inputNeuron;
            _outputNeuron = outputNeuron;
            _weight = weight;
        }
    }
}
namespace ClassificationNumbers.MainClasses
{
    public class Relation
    {
        private float _weight;
        private Neuron _inputNeuron;
        private Neuron _outputNeuron;

        public Relation(Neuron inputNeuron, Neuron outputNeuron, float weight)
        {
            _inputNeuron = inputNeuron;
            _outputNeuron = outputNeuron;
            _weight = weight;
        }
    }
}
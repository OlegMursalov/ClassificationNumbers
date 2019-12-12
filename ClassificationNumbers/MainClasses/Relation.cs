namespace ClassificationNumbers.MainClasses
{
    public class Relation
    {
        public double Weight { get; private set; }
        public Neuron InputNeuron { get; }
        public Neuron OutputNeuron { get; }

        public Relation(Neuron inputNeuron, Neuron outputNeuron, double weight)
        {
            InputNeuron = inputNeuron;
            OutputNeuron = outputNeuron;
            Weight = weight;
        }

        /// <summary>
        /// Установить новый вес для связи между нейронами
        /// </summary>
        public void SetWeight(double newWeight)
        {
            Weight = newWeight;
        }
    }
}
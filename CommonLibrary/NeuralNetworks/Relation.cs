using System.Runtime.Serialization;

namespace CommonLibrary.NeuralNetworks
{
    [DataContract]
    public class Relation
    {
        [DataMember]
        public double Weight { get; private set; }

        [DataMember]
        public Neuron InputNeuron { get; private set; }

        [DataMember]
        public Neuron OutputNeuron { get; private set; }

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
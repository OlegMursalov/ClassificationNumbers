using System.Runtime.Serialization;

namespace CommonLibrary.NeuralNetworks
{
    [DataContract]
    public class Neuron
    {
        [DataMember]
        private FunctionActivationEnum _functionActivationEnum;

        [DataMember]
        public int Number { get; private set; }

        public Neuron(int number, FunctionActivationEnum functionActivationEnum)
        {
            Number = number;
            _functionActivationEnum = functionActivationEnum;
        }
    }
}
namespace CommonLibrary.NeuralNetworks
{
    public class Neuron
    {
        private FunctionActivationEnum _functionActivationEnum;

        public int Number { get; }

        public Neuron(int number, FunctionActivationEnum functionActivationEnum)
        {
            Number = number;
            _functionActivationEnum = functionActivationEnum;
        }
    }
}
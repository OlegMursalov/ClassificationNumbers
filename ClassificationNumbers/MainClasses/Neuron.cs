using System;

namespace ClassificationNumbers.MainClasses
{
    public class Neuron
    {
        private FunctionActivation _functionActivation;

        public int Number { get; }

        public Neuron(int number, FunctionActivation functionActivation)
        {
            Number = number;
            _functionActivation = functionActivation;
        }
    }
}

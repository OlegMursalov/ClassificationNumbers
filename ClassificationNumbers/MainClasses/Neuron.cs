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

        public double CalcOutputSignal(double inputSignal)
        {
            if (_functionActivation == FunctionActivation.None)
            {
                return inputSignal;
            }
            else if (_functionActivation == FunctionActivation.Sigmoida)
            {
                return (1 / (1 + Math.Pow(Math.E, -inputSignal)));
            }
            return inputSignal;
        }
    }
}

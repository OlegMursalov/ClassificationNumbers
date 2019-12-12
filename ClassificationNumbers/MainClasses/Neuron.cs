using System;

namespace ClassificationNumbers.MainClasses
{
    public class Neuron
    {
        private FunctionActivation _functionActivation;

        public Neuron(FunctionActivation functionActivation)
        {
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
            else
            {
                throw new Exception("Укажите функцию активации для нейрона");
            }
        }
    }
}

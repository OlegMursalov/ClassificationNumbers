namespace CommonLibrary.NeuralNetworks
{
    public class Delegates
    {
        public delegate double FuncActivationDelegate(double inputSignal);
        
        public delegate double DerivativeOfFuncActivationDelegate(double e, double inputSignal, double outputSignal);
    }
}
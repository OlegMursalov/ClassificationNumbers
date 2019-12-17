using CommonLibrary.NeuralNetworks;

namespace ClassificationNumbers.Helpers
{
    public static class FuncActivationHelper
    {
        public static FunctionActivationEnum MapFunction(string item)
        {
            if (item == "None")
                return FunctionActivationEnum.None;
            else if (item == "y = 1 / (1 + e^x)")
                return FunctionActivationEnum.Sigmoida;
            else
                return FunctionActivationEnum.None;
        }

        public static int MapFunction(FunctionActivationEnum functionActivationType)
        {
            return (int)functionActivationType;
        }
    }
}
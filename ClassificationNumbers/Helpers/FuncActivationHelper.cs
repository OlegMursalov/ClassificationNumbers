using ClassificationNumbers.MainClasses;

namespace ClassificationNumbers.Helpers
{
    public static class FuncActivationHelper
    {
        public static FunctionActivation MapFunction(string item)
        {
            if (item == "None")
                return FunctionActivation.None;
            if (item == "y = 1 / (1 + e^x)")
                return FunctionActivation.Sigmoida;
            return FunctionActivation.None;
        }
    }
}
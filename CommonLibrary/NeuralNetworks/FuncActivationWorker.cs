using System;
using static CommonLibrary.NeuralNetworks.Neural3NetworkCreator;

namespace CommonLibrary.NeuralNetworks
{
    public class FuncActivationWorker
    {
        private FunctionActivationEnum _funcActivationType;

        public FuncActivationWorker(FunctionActivationEnum funcActivationType)
        {
            _funcActivationType = funcActivationType;
        }

        /// <summary>
        /// Возвращает делегат функции активации в зависимости от типа функции
        /// </summary>
        /// <returns></returns>
        public FuncActivationDelegate GetFunction()
        {
            if (_funcActivationType == FunctionActivationEnum.None)
                return (signal) => signal;
            else if (_funcActivationType == FunctionActivationEnum.Sigmoida)
                return (signal) => (1 / (1 + Math.Pow(Math.E, -signal)));
            else
                throw new ArgumentException("Вы не указали функцию активации");
        }

        /// <summary>
        /// Возвращает делегат функции производной от функции активации по весу одного ребра
        /// </summary>
        public double DerivateByFuncActivation(double e, double inputSignal, double outputSignal)
        {
            // e - пропорциональная ошибка на нейроне
            // inputSignal - сигнал, который пришел на этот нейрон от предыдущего нейрона из предыдущего слоя
            // outputSignal - комбинированный и сглаженный сигнал, пропущенный через функцию активации на данном нейроне
            if (_funcActivationType == FunctionActivationEnum.None)
                return 0;
            else if (_funcActivationType == FunctionActivationEnum.Sigmoida)
                return -2 * e * outputSignal * (1 - outputSignal) * inputSignal;
            else
                throw new ArgumentException("Неизвестная производная от функции активации");
        }
    }
}
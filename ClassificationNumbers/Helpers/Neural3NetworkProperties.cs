using ClassificationNumbers.Forms;
using CommonLibrary.NeuralNetworks;

namespace ClassificationNumbers.Helpers
{
    public class Neural3NetworkProperties
    {
        private MainForm _mainForm;

        /// <summary>
        /// Количество входных нейронов
        /// </summary>
        public int AmountInputNeurons => int.Parse(_mainForm._amountInputNeuronsN.Text);

        /// <summary>
        /// Количество скрытых нейронов
        /// </summary>
        public int AmountHiddenNeurons => int.Parse(_mainForm._amountHiddenNeuronsN.Text);
        
        /// <summary>
        /// Количество выходных нейронов
        /// </summary>
        public int AmountOutputNeurons => int.Parse(_mainForm._amountOutputNeuronsN.Text);

        /// <summary>
        /// Коэфициент обучения
        /// </summary>
        public double Alpha => double.Parse(_mainForm._alphaN.Text);

        /// <summary>
        /// Минимальный возможный вес для ребра
        /// </summary>
        public double MinWeight => double.Parse(_mainForm._minWeightN.Text);

        /// <summary>
        /// Максимальный возможный вес для ребра
        /// </summary>
        public double MaxWeight => double.Parse(_mainForm._maxWeightN.Text);

        /// <summary>
        /// Функция активации для нейрона
        /// </summary>
        public FunctionActivationEnum FuncActivation
        {
            get
            {
                var funcActivationStr = _mainForm._funcActivationsList.SelectedItem as string;
                return FuncActivationHelper.MapFunction(funcActivationStr);
            }
        }

        public Neural3NetworkProperties(MainForm mainForm)
        {
            _mainForm = mainForm;
        }

        public void SetInForm()
        {
            _mainForm._amountInputNeuronsN.Text = "784";
            _mainForm._amountHiddenNeuronsN.Text = "100";
            _mainForm._amountOutputNeuronsN.Text = "10";
            _mainForm._alphaN.Text = "0,28";
            _mainForm._minWeightN.Text = "0,01";
            _mainForm._maxWeightN.Text = "0,1";
            _mainForm._funcActivationsList.SelectedIndex = 1;
        }
    }
}
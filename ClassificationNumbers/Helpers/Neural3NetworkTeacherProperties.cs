using ClassificationNumbers.Forms;
using CommonLibrary.NeuralNetworks;

namespace ClassificationNumbers.Helpers
{
    public class Neural3NetworkTeacherProperties
    {
        private MainForm _mainForm;

        /// <summary>
        /// Коэфициент обучения
        /// </summary>
        public double Alpha => double.Parse(_mainForm._alphaN.Text);

        /// <summary>
        /// Минимально возможный сигнал для входных нейронов
        /// </summary>
        public double MinSignal => double.Parse(_mainForm._minSignalN.Text);

        /// <summary>
        /// Максимально возможный сигнал для входных нейронов
        /// </summary>
        public double MaxSignal => double.Parse(_mainForm._maxSignalN.Text);

        /// <summary>
        /// Ожидаемый сигнал на выходе нейронов выходного слоя
        /// </summary>
        public double ExpectedSignal => double.Parse(_mainForm._expectedSignalN.Text);

        public Neural3NetworkTeacherProperties(MainForm mainForm)
        {
            _mainForm = mainForm;
        }

        public void SetInFormByDefault()
        {
            _mainForm._alphaN.Text = "0,28";
            _mainForm._minSignalN.Text = "0,01";
            _mainForm._maxSignalN.Text = "0,99";
            _mainForm._expectedSignalN.Text = "1";
        }
    }
}
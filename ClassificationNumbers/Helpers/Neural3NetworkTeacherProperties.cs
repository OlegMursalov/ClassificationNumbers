using ClassificationNumbers.Forms;

namespace ClassificationNumbers.Helpers
{
    public class Neural3NetworkTeacherProperties
    {
        private MainForm _mainForm;

        /// <summary>
        /// Коэфициент обучения
        /// </summary>
        public double Alpha => double.Parse(_mainForm._alphaN.Text);

        public Neural3NetworkTeacherProperties(MainForm mainForm)
        {
            _mainForm = mainForm;
        }

        public void SetInFormByDefault()
        {
            _mainForm._alphaN.Text = "0,28";
        }
    }
}
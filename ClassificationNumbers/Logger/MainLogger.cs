using System.Windows.Forms;

namespace ClassificationNumbers.Logger
{
    public class MainLogger
    {
        private ListBox _mainListBox;

        public MainLogger(ListBox listBox)
        {
            _mainListBox = listBox;
        }

        public void Log(string message, bool isShowMsg)
        {
            _mainListBox.Items.Add(message);
            if (isShowMsg)
            {
                MessageBox.Show(message);
            }
        }
    }
}
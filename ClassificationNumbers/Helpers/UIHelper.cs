using System.Windows.Forms;

namespace ClassificationNumbers.Helpers
{
    public static class UIHelper
    {
        /// <summary>
        /// Заблокировать все элементы управления на форме
        /// </summary>
        public static void BlockAllControls(Form form)
        {
            SetStateToAllControls(form, false);
        }

        /// <summary>
        /// Разблокировать все элементы управления на форме
        /// </summary>
        public static void EnableAllControls(Form form)
        {
            SetStateToAllControls(form, true);
        }

        private static void SetStateToAllControls(Form form, bool state)
        {
            foreach (var item in form.Controls)
            {
                var control = item as Control;
                if (control != null)
                {
                    control.Enabled = state;
                }
            }
        }
    }
}
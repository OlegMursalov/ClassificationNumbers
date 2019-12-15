using CommonLibrary.DataDTO;
using CommonLibrary.Transformators;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ClassificationNumbers.Forms
{
    public partial class GeneratingDataForm : Form
    {
        private string[] _images_28x28_Set;
        private DataNumberDTO_28x28_Set[] _dataNumberDTO_28x28_Set;

        public GeneratingDataForm()
        {
            InitializeComponent();
        }

        private void _selectImages28x28_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                openFileDialog.Filter = "Png Files|*.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _images_28x28_Set = openFileDialog.FileNames;
                }
            }

            _statusSelectImgLbl.BackColor = Color.Green;
            _statusSelectImgLbl.Text = "Картинки выбраны";
        }

        private void _generateJSONData_Click(object sender, EventArgs e)
        {
            if (_images_28x28_Set == null || _images_28x28_Set.Length == 0)
            {
                MessageBox.Show("Не выбраны картинки для генерации JSON данных");
                return;
            }

            var errors = new Dictionary<string, string>();
            var imageTransformatter28x28 = new ImageWorker28x28(_images_28x28_Set);
            _dataNumberDTO_28x28_Set = imageTransformatter28x28.GetData(ref errors);

            

            _statusDataLbl.BackColor = Color.Green;
            _statusDataLbl.Text = "Данные получены";
        }

        private void X()
        {
            for (var i = 0; i < _dataNumberDTO_28x28_Set.Length; i++)
            {
                _mainRichTxb.Text += _dataNumberDTO_28x28_Set.ToString();
            }
        }
    }
}
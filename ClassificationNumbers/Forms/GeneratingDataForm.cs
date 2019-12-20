using CommonLibrary.DataDTO;
using CommonLibrary.Transformators;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClassificationNumbers.Forms
{
    public partial class GeneratingDataForm : Form
    {
        private string[] _images_28x28_Set;
        private DataNumberDTO_28x28_Set[] _dataNumberDTO_28x28_Set;
        private string _dataNumberDTO_28x28_SetJSON;

        public GeneratingDataForm()
        {
            InitializeComponent();
        }

        private void _selectImages28x28Btn_Click(object sender, EventArgs e)
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

        private void _generateJSONDataBtn_Click(object sender, EventArgs e)
        {
            if (_images_28x28_Set == null || _images_28x28_Set.Length == 0)
            {
                MessageBox.Show("Не выбраны картинки для генерации JSON данных");
                return;
            }

            _backgroundWorker.DoWork += GenerateJSONData_DoWork;
            _backgroundWorker.RunWorkerCompleted += GenerateJSONData_RunWorkerCompleted;

            _backgroundWorker.RunWorkerAsync();
        }

        private void GenerateJSONData_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            _mainRichTxb.Text = _dataNumberDTO_28x28_SetJSON;
            _statusDataLbl.BackColor = Color.Green;
            _statusDataLbl.Text = "Данные получены";
            _backgroundWorker.DoWork -= GenerateJSONData_DoWork;
            _backgroundWorker.RunWorkerCompleted -= GenerateJSONData_RunWorkerCompleted;
        }

        private void GenerateJSONData_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var errors = new Dictionary<string, string>();
            var imageTransformatter28x28 = new ImageWorker28x28(_images_28x28_Set);
            _dataNumberDTO_28x28_Set = imageTransformatter28x28.GetRGBData(ref errors);
            var exMessage = string.Empty;
            _dataNumberDTO_28x28_SetJSON = imageTransformatter28x28.SerializeRGBDataToJSON(_dataNumberDTO_28x28_Set, ref exMessage);
        }

        private void _saveDataJsonInFileBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_dataNumberDTO_28x28_SetJSON))
            {
                MessageBox.Show("Не получены JSON данные");
                return;
            }

            var savedFileName = string.Empty;

            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JSON Files|*.json";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var fs = saveFileDialog.OpenFile())
                    {
                        savedFileName = saveFileDialog.FileName;
                        var bytes = Encoding.UTF8.GetBytes(_dataNumberDTO_28x28_SetJSON);
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }
            }

            if (!string.IsNullOrEmpty(savedFileName))
            {
                _statusSaveLbl.BackColor = Color.Green;
                _statusSaveLbl.Text = $"Данные JSON сохранены в файл {savedFileName}";
            }
        }
    }
}
using ClassificationNumbers.Helpers;
using ClassificationNumbers.NeuralNetworks;
using CommonLibrary.DataDTO;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;

namespace ClassificationNumbers.Forms
{
    public partial class MainForm : Form
    {
        private Neural3NetworkCreator _neural3NetworkCreator;
        private PainterForm _painterForm;
        private GeneratingDataForm _generatingDataForm;

        private OpenFileDialog _pngImagesDialogSelecting;
        private FileStream _mainFileStream;

        private DataNumberDTO_28x28_Set[] _dataNumberDTO_28x28_Set;

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Создаем простую трехслойную нейросеть.
        /// Создаем нейроны, генерируем между ними связи со случайными значениями весов.
        /// </summary>
        private void _createNeuralNetworkBtn_Click(object sender, EventArgs e)
        {
            var properties = new NeuralNetworkProperties(this);

            var functionActivation = properties.FuncActivation;
            var amountInputNeurons = properties.AmountInputNeurons;
            var amountHiddenNeurons = properties.AmountHiddenNeurons;
            var amountOutputNeurons = properties.AmountOutputNeurons;
            var alpha = properties.Alpha;
            var minWeight = properties.MinWeight;
            var maxWeight = properties.MaxWeight;

            _neural3NetworkCreator = new Neural3NetworkCreator(functionActivation, amountInputNeurons, amountHiddenNeurons, amountOutputNeurons, alpha, minWeight, maxWeight);
        }

        private void _LearnBtn_Click(object sender, EventArgs e)
        {
            if (_dataNumberDTO_28x28_Set == null || _dataNumberDTO_28x28_Set.Length == 0)
            {
                MessageBox.Show("Нет данных, пожалуйста, выберите подходящий JSON файл.");
                return;
            }

            // Обучение трехслойной нейронной сети
            // ЗАДАЧА - классифицировать на картинках цифры от 0 до 9, написанные от руки
            // Входные данные, где int - цифры, а float[] - массив преобразованных RGB компонент из картинок
            _mainBackgroundWorker.DoWork += LearnNeuralNetwork_DoWork;
            _mainBackgroundWorker.RunWorkerCompleted += LearnNeuralNetwork_RunWorkerCompleted;
            _mainBackgroundWorker.RunWorkerAsync();
        }

        private void LearnNeuralNetwork_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void LearnNeuralNetwork_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

        }

        /// <summary>
        /// Выбираем JSON файл, подгружаем его и вытаскиваем data set для тренировки neural networks
        /// </summary>
        private void _loadJsonDataSetBtn_Click(object sender, EventArgs e)
        {
            _pngImagesDialogSelecting = new OpenFileDialog();
            _pngImagesDialogSelecting.Filter = "Json Files|*.json";
            if (_pngImagesDialogSelecting.ShowDialog() == DialogResult.OK)
            {
                var fileName = _pngImagesDialogSelecting.FileName;
                _mainFileStream = new FileStream(fileName, FileMode.Open);
                _mainBackgroundWorker.DoWork += LoadJsonDataSet_DoWork;
                _mainBackgroundWorker.RunWorkerCompleted += LoadJsonDataSet_RunWorkerCompleted;
                _mainBackgroundWorker.RunWorkerAsync();
            }
        }

        private void LoadJsonDataSet_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (_pngImagesDialogSelecting != null)
            {
                _pngImagesDialogSelecting.Dispose();
            }
            if (_mainFileStream != null)
            {
                _mainFileStream.Dispose();
            }
        }

        private void LoadJsonDataSet_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var serializer = new DataContractJsonSerializer(typeof(DataNumberDTO_28x28_Set[]));
            _dataNumberDTO_28x28_Set = (DataNumberDTO_28x28_Set[])serializer.ReadObject(_mainFileStream);
        }

        /// <summary>
        /// Установить характеристики простой трехслойной нейронной сети по-умолчанию
        /// </summary>
        private void _setDefaultPropertiesBtn_Click(object sender, EventArgs e)
        {
            var properties = new NeuralNetworkProperties(this);
            properties.SetInForm();
        }

        /// <summary>
        /// Отрисовывает нейронную сеть
        /// </summary>
        private void _drawNeuralNetworkBtn_Click(object sender, EventArgs e)
        {
            if (_neural3NetworkCreator == null)
            {
                MessageBox.Show("Нейросеть не создана.");
                return;
            }

            if (_painterForm != null)
            {
                MessageBox.Show("Второе окно уже используется для отрисовки.");
                return;
            }

            _painterForm = new PainterForm(_neural3NetworkCreator);
            _painterForm.FormClosed += _painterForm_FormClosed;
            _painterForm.Width = 1400;
            _painterForm.Height = 800;
            _painterForm.Show();
            _painterForm.DrawNeuralNetworkAsync();
        }

        private void _painterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _painterForm = null;
        }

        /// <summary>
        /// Отрисовывает данных картинок 28x28 пикселей
        /// </summary>
        private void _visualizationDataBtn_Click(object sender, EventArgs e)
        {
            if (_dataNumberDTO_28x28_Set == null)
            {
                MessageBox.Show("Не были подгружены JSON данные картинок 28x28 pixels.");
                return;
            }

            if (_painterForm != null)
            {
                MessageBox.Show("Второе окно уже используется для отрисовки.");
                return;
            }

            _painterForm = new PainterForm(_dataNumberDTO_28x28_Set);
            _painterForm.FormClosed += _painterForm_FormClosed;
            _painterForm.Width = 1400;
            _painterForm.Height = 800;
            _painterForm.Show();
            _painterForm.DrawImages28x28();
        }

        private void _generateJsonData28x28_Click(object sender, EventArgs e)
        {
            _generatingDataForm = new GeneratingDataForm();
            _generatingDataForm.Show();
        }
    }
}
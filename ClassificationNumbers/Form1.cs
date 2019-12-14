using ClassificationNumbers.Drawing;
using ClassificationNumbers.Helpers;
using ClassificationNumbers.MainClasses;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using CommonLibrary.DataDTO;
using System.IO;
using System.Runtime.Serialization.Json;

namespace ClassificationNumbers
{
    public partial class Form1 : Form
    {
        private NeuralNetwork _neuralNetwork;
        private DataNumberDTO_28x28_Set[] _dataNumberDTO_28x28_Set;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
            
            _neuralNetwork = new NeuralNetwork(functionActivation, amountInputNeurons, amountHiddenNeurons, amountOutputNeurons, alpha, minWeight, maxWeight);

            // Создаем художника для рисования нейросети в picture box
            // Делаем для глядности и лучшего изучения темы
            // var neuralNetworkPainter = new NeuralNetworkPainter(_mainPictureBox, _neuralNetwork);
            // neuralNetworkPainter.Draw();
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
            var dataSet = _dataNumberDTO_28x28_Set;
            _neuralNetwork.Learn(dataSet);
        }

        /// <summary>
        /// Выбираем JSON файл, подгружаем его и вытаскиваем data set для тренировки neural networks
        /// </summary>
        private void _loadJsonDataSetBtn_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Json Files|*.json";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileName = openFileDialog.FileName;
                using (var fs = new FileStream(fileName, FileMode.Open))
                {
                    var serializer = new DataContractJsonSerializer(typeof(DataNumberDTO_28x28_Set[]));
                    _dataNumberDTO_28x28_Set = (DataNumberDTO_28x28_Set[])serializer.ReadObject(fs);
                }
            }
        }

        /// <summary>
        /// Установить характеристики простой трехслойной нейронной сети по-умолчанию
        /// </summary>
        private void _setDefaultPropertiesBtn_Click(object sender, EventArgs e)
        {
            var properties = new NeuralNetworkProperties(this);
            properties.SetInForm();
        }
    }
}

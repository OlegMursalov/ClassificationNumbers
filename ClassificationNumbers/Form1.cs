using ClassificationNumbers.Drawing;
using ClassificationNumbers.Helpers;
using ClassificationNumbers.MainClasses;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using ClassificationNumbers.DataDTO;

namespace ClassificationNumbers
{
    public partial class Form1 : Form
    {
        private NeuralNetwork _neuralNetwork;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void _createNeuralNetworkBtn_Click(object sender, EventArgs e)
        {
            // Количество входных нейронов
            var amountInputNeurons = int.Parse(_amountInputNeuronsN.Text);
            // Количество скрытых нейронов
            var amountHiddenNeurons = int.Parse(_amountHiddenNeuronsN.Text);
            // Количество выходных нейронов
            var amountOutputNeurons = int.Parse(_amountOutputNeuronsN.Text);
            // Коэфициент обучения
            var alpha = double.Parse(_alphaN.Text);
            // Минимальный возможный вес для ребра
            var minWeight = double.Parse(_minWeightN.Text);
            // Максимальный возможный вес для ребра
            var maxWeight = double.Parse(_maxWeightN.Text);
            // Функция активации
            var funcActivationStr = _funcActivationsList.SelectedItem as string;
            var functionActivation = FuncActivationHelper.MapFunction(funcActivationStr);

            // Создали простую трехслойную нейросеть
            // Создаем нейроны, генерируем между ними связи с случайными значениями весов
            _neuralNetwork = new NeuralNetwork(
                functionActivation,
                amountInputNeurons, amountHiddenNeurons, amountOutputNeurons, 
                alpha, minWeight, maxWeight);

            // Создаем художника для рисования нейросети в picture box
            // Делаем для глядности и лучшего изучения темы
            var neuralNetworkPainter = new NeuralNetworkPainter(_mainPictureBox, _neuralNetwork);
            neuralNetworkPainter.Draw();
        }

        private void _LearnBtn_Click(object sender, EventArgs e)
        {
            // Обучение трехслойной нейронной сети
            // ЗАДАЧА - классифицировать на картинках цифры от 0 до 9, написанные от руки
            // Входные данные, где int - цифры, а float[] - массив преобразованных RGB компонент из картинок
            var data = new Dictionary<int, DataNumberDTO_5x5>();
            data.Add(0, new DataNumberDTO_5x5(5, new double[] { 0.87, 0.23, 0.03, 0.01, 0.57 }));
            data.Add(1, new DataNumberDTO_5x5(5, new double[] { 0.78, 0.03, 0.01, 0.01, 0.28 }));
            data.Add(2, new DataNumberDTO_5x5(5, new double[] { 0.09, 0.11, 0.28, 0.78, 0.97 }));
            _neuralNetwork.Learn(data);
        }
    }
}
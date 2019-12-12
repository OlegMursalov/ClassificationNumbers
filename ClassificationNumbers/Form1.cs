using ClassificationNumbers.Drawing;
using ClassificationNumbers.Helpers;
using ClassificationNumbers.MainClasses;
using System;
using System.Windows.Forms;

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
    }
}

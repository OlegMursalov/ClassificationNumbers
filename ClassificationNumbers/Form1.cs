using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassificationNumbers.MainClasses;

namespace ClassificationNumbers
{
    public partial class Form1 : Form
    {
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
            var functionActivation = _funcActivationsList.SelectedItem as string;

            // Создали простую трехслойную нейросеть
            // Создаем нейроны, генерируем между ними связи с случайными значениями весов
            /*var neuralNetwork = new NeuralNetwork(

                amountInputNeurons, amountHiddenNeurons, amountOutputNeurons, 
                alpha, minWeight, maxWeight);*/

            
        }
    }
}

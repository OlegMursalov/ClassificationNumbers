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
            var amountInputNeurons = int.Parse(_amountInputNeuronsTxb.Text);
            var amountHiddenNeurons = int.Parse(_amountHiddenNeuronsTxb.Text);
            var amountOutputNeurons = int.Parse(_amountOutputNeuronsTxb.Text);
            var alpha = float.Parse(_alphaTxb.Text);
        }
    }
}

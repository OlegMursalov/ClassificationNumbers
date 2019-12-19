using CommonLibrary.Helpers;
using CommonLibrary.NeuralNetworks;
using System;
using System.Windows.Forms;

namespace ClassificationNumbers.Forms
{
    public partial class RightAnswerForm : Form
    {
        private Neural3NetworkWeightsUpdater _neural3NetworkWeightsUpdater;
        private Neural3NetworkHelper _neural3NetworkHelper;

        public RightAnswerForm(int resultNumber, Neural3NetworkWeightsUpdater neural3NetworkWeightsUpdater, Neural3NetworkHelper neural3NetworkHelper)
        {
            InitializeComponent();
            _resultNumN.Value = resultNumber;
            _neural3NetworkWeightsUpdater = neural3NetworkWeightsUpdater;
            _neural3NetworkHelper = neural3NetworkHelper;
        }

        private void _updateWeightsNNBtn_Click(object sender, EventArgs e)
        {
            var rightAnswer = Convert.ToInt32(_rightNumN.Value);

            var neural3NetworkCreator = _neural3NetworkWeightsUpdater.Neural3NetworkTeacher.Neural3NetworkCreator;
            
            var signalsFromInputLayer = _neural3NetworkWeightsUpdater.SignalsFromInputLayer;
            var signalsFromHiddenLayer = _neural3NetworkWeightsUpdater.SignalsFromHiddenLayer;
            var signalsFromOutputLayer = _neural3NetworkWeightsUpdater.SignalsFromOutputLayer;

            var hiddenOutputRelations = _neural3NetworkHelper.GetHiddenOutputRelations();
            var inputHiddenRelations = _neural3NetworkHelper.GetInputHiddenRelations();

            // Обновление весов на нужных ребрах, в зависимости от ошибки и правильного ответа
            var errorsHiddenLayer = _neural3NetworkWeightsUpdater.UpdateWeights(hiddenOutputRelations, signalsFromHiddenLayer, signalsFromOutputLayer, rightAnswer);
            _neural3NetworkWeightsUpdater.UpdateWeights(errorsHiddenLayer, inputHiddenRelations, signalsFromInputLayer, signalsFromHiddenLayer);

            MessageBox.Show("Веса нейросети успешно обновлены!");
            this.Close();
        }
    }
}
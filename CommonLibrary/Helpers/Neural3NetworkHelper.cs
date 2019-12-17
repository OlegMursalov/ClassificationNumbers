using CommonLibrary.NeuralNetworks;

namespace CommonLibrary.Helpers
{
    public class Neural3NetworkHelper
    {
        private Neural3NetworkCreator _neural3NetworkCreator;

        public Neural3NetworkHelper(Neural3NetworkCreator neural3NetworkCreator)
        {
            _neural3NetworkCreator = neural3NetworkCreator;
        }

        /// <summary>
        /// Возвращает двумерный массив связей между нейронами входного и скрытого слоев
        /// </summary>
        public Relation[,] GetInputHiddenRelations()
        {
            return GetRelations(_neural3NetworkCreator.InputLayer, _neural3NetworkCreator.HiddenLayer, _neural3NetworkCreator.InputHiddenRelations);
        }

        /// <summary>
        /// Возвращает двумерный массив связей между нейронами скрытого и выходного слоев
        /// </summary>
        public Relation[,] GetHiddenOutputRelations()
        {
            return GetRelations(_neural3NetworkCreator.HiddenLayer, _neural3NetworkCreator.OutputLayer, _neural3NetworkCreator.HiddenOutputRelations);
        }

        private Relation[,] GetRelations(Layer layer1, Layer layer2, Relation[] relations)
        {
            var c = 0;
            var hiddenNeuronsAmount = layer1.Neurons.Length;
            var outputNeuronsAmount = layer2.Neurons.Length;
            var newRelations = new Relation[hiddenNeuronsAmount, outputNeuronsAmount];
            for (int i = 0; i < hiddenNeuronsAmount; i++)
            {
                for (int j = 0; j < outputNeuronsAmount; j++)
                {
                    newRelations[i, j] = relations[c];
                    c++;
                }
            }
            return newRelations;
        }
    }
}
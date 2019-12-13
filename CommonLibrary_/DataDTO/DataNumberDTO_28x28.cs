namespace ClassificationNumbers.DataDTO
{
    public class DataNumberDTO_28x28
    {
        public int Number { get; }
        public double[] ImageRGBComponents { get; }

        public DataNumberDTO_28x28(int number, double[] imageRGBComponents)
        {
            Number = number;
            ImageRGBComponents = imageRGBComponents;
        }
    }
}
namespace ClassificationNumbers.DataDTO
{
    public class DataNumberDTO_5x5
    {
        public int Number { get; }
        public double[] ImageRGBComponents { get; }

        public DataNumberDTO_5x5(int number, double[] imageRGBComponents)
        {
            Number = number;
            ImageRGBComponents = imageRGBComponents;
        }
    }
}
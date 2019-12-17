namespace CommonLibrary.DataDTO
{
    public class DataNumberDTO_5x5
    {
        public int Number { get; }
        public double[] ImageARGBComponents { get; }

        public DataNumberDTO_5x5(int number, double[] imageARGBComponents)
        {
            Number = number;
            ImageARGBComponents = imageARGBComponents;
        }
    }
}
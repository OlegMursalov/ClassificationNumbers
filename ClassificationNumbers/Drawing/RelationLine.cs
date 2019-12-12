using System.Drawing;

namespace ClassificationNumbers.Drawing
{
    public class RelationLine
    {
        public Point Input { get; }
        public Point Output { get; }

        public RelationLine(Point input, Point output)
        {
            Input = input;
            Output = output;
        }
    }
}
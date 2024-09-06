using Interfaces_Demo.Interfaces;

namespace Interfaces_Demo.Models
{
    internal class Line :INumeric
    {
        //Data Members
        private Point2D _firstEnd;
        private Point2D _secondEnd;

        //Default Constructor
        public Line()
        {
            FirstEnd = new Point2D();
            SecondEnd = new Point2D();
        }

        public Line(Point2D p1, Point2D p2)
        {
            FirstEnd = p1;
            SecondEnd = p2;
        }

        //Properties
        public Point2D FirstEnd
        {
            get { return _firstEnd; }
            set
            {
                if (value == null)
                    throw new NullReferenceException("An end point in a line cannot be null");
                _firstEnd = value;
            }
        }

        public Point2D SecondEnd
        {
            get { return _secondEnd; }
            set
            {
                if (value == null)
                    throw new NullReferenceException("An end point in a line cannot be null");
                _secondEnd = value;
            }
        }

        public override string ToString()
        {
            return $"First End: {FirstEnd} , Second End: {SecondEnd}";
        }

        /* 
         *  Requirement: Find the length of a line
         *  Distance between 2 points: //Sqtr((X1-X2)^2 + (Y1-Y2)^2)
         */
        public double GetLength()
        {
            return Math.Sqrt(
                Math.Pow(FirstEnd.X - SecondEnd.X, 2) +
                Math.Pow(FirstEnd.Y - SecondEnd.Y, 2));
        }

        public double GetDoubleValue()
        {
            return GetLength();
        }
    }
}

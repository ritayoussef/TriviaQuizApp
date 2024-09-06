//Note the use of a namespace
using Interfaces_Demo.Interfaces;
using Interfaces_Demo.Models;
using System.Text;

namespace Interfaces_Demo
{
    internal class GeometryApp
    {
        private const int SIZE = 20;
        private Point2D[] points;
        private Line[] lines;
        private Square[] squares;
        private Cube[] cubes;

        private Random random;

        public GeometryApp()
        {
            points = new Point2D[SIZE];
            lines = new Line[SIZE];
            squares = new Square[SIZE];
            cubes = new Cube[SIZE];
            random = new Random();
        }

        /* Requirements:
             * Points: Find the average distance from center, furthest point, its index and object.
             * Lines: Find the average length of a line, longest line, its index and object.
             * Squares: Find the average area of square, largest area, its index and object.
             */
        public void ProcessPoints()
        {
            // fill with random points
            for (int i = 0; i < SIZE; i++)
                points[i] = new Point2D(random.Next(200) - 100, random.Next(200) - 100);

            //Average distance from origin
            Console.WriteLine( $"Average distance from origin {Average(points)}");

            //Maximum distance from origin
            Console.WriteLine($"Maximum distance from origin {Max(points)}");
            //Index of point with distance from origin
            Console.WriteLine($"Index of point with distance from origin {MaxIndex(points)}");

            //Point with max distance from origin (object)
            Point2D maxPoint = MaxShapeObject(points) as Point2D;
            if( maxPoint != null ) 
            {
                Console.WriteLine($"Point with max distance from origin (object) {maxPoint.X},{maxPoint.Y}");
            }

            //Get All Values (in a string format)
            Console.WriteLine("Get All Values (in a string format)");
            Console.WriteLine(GetStringValues(points));
        }



        public void ProcessSquares()
        {
            // fill with random squares
            for (int i = 0; i < SIZE; i++)
                squares[i] = new Square(random.Next(200));

            //Average areas of squares
            Console.WriteLine($"Average areas of squares = {Average(squares)}");
            //Maximum square area
            Console.WriteLine($"Maximum square area {Max(squares)}");
            //Index maximum square area
            Console.WriteLine($"Index maximum square area {MaxIndex(squares)}");
            //maximum square area (object)
            Square maxSquare = MaxShapeObject(squares) as Square;
            if(maxSquare != null) 
            {
                Console.WriteLine($"maximum square area (object) {maxSquare.Side}");
            }

            //Get All Values (in a string format)
            Console.WriteLine("Get All Values (in a string format)");
            Console.WriteLine(GetStringValues(squares));
        }

        public double Average(INumeric[] values)
        {
            if (values.Length == 0)
                throw new ArgumentException("Cannot compute average for an empty array");

            double sum = 0.0;
            foreach (INumeric value in values)
            {
                sum += value.GetDoubleValue();
            }

            return sum / values.Length;
        }

        public double Max(INumeric[] values)
        {
            if (values.Length == 0)
                throw new ArgumentException("Cannot compute average for an empty array");

            double max = values[0].GetDoubleValue();
            foreach (INumeric value in values)
            {
                if(value.GetDoubleValue() > max)
                    max = value.GetDoubleValue();
            }

            return max;
        }

        public int MaxIndex(INumeric[] values)
        {
            if (values.Length == 0)
                throw new ArgumentException("Cannot compute average for an empty array");

            double max = values[0].GetDoubleValue();
            int index = 0;
            for (int i = 1; i < values.Length; i++)
            {
                if (values[i].GetDoubleValue() > max)
                {
                    max = values[i].GetDoubleValue();
                    index = i;
                }
            }
            

            return index;
        }

        public INumeric MaxShapeObject(INumeric[] values)
        {
            if (values.Length == 0)
                throw new ArgumentException("Cannot compute average for an empty array");


            INumeric max = values[0];
            foreach (INumeric value in values)
            {
                if (value.GetDoubleValue() > max.GetDoubleValue())
                    max = value;
            }
            //Square s = new Square();    
            return max;
        }

        public string GetStringValues(Object[] values)
        {
            StringBuilder builder = new StringBuilder();
            foreach (INumeric item in values)
            {
                builder.AppendLine(item.ToString());
            }

            return builder.ToString();
        }

        //public double Average(Square[] values)
        //{
        //    if (values.Length == 0)
        //        throw new ArgumentException("Cannot compute average for an empty array");

        //    double sum = 0.0;
        //    foreach (Square value in values)
        //    {
        //        sum += value.Area();
        //    }

        //    return sum / values.Length;
        //}

        public void ProcessLines()
        {
            //...
        }

        public void ProcessCubes()
        {
            Max(cubes);
        }
    }
}


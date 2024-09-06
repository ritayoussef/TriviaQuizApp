using Interfaces_Demo.Interfaces;

namespace Interfaces_Demo.Models
{
    internal class Point2D :INumeric
    {
        //Data Members
        private float x;
        private float y;

        //Default Constructor
        public Point2D()
        {
            x = y = 0.0f;
        }

        public Point2D(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        //Properties
        public float X
        {
            get { return x; }
            set { x = value; } // Validation rules: required or not?
        }

        public float Y
        {
            get { return y; }
            set { y = value; } // Validation rules: required or not?
        }

        public override string ToString()
        {
            return string.Format("({0:F2},{1:F2})", X, Y);
        }


        /* 
         *  Requirement: Distance from center (X=0, Y=0)
         *  Distance between 2 points: //Sqtr((X1-X2)^2 + (Y1-Y2)^2)
         */
        public double Distance()
        {
            return Math.Sqrt(X * X + Y * Y);
        }

        public double GetDoubleValue()
        {
            return Distance();
        }
    }
}

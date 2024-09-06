using Interfaces_Demo.Interfaces;

namespace Interfaces_Demo.Models
{
    internal class Square : INumeric, IStorable
    {
        //Data Members
        private double _side;

        //Default Constructor
        public Square()
        {
            Side = 1.0;
        }

        public Square(float side)
        {
            Side = side;
        }

        //Property
        public double Side
        {
            get { return _side; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Square side cannot be empty");
                _side = value;
            }
        }
        public override string ToString()
        {
            return $"Square: side={Side}";
        }

        /* 
         *  Requirement: Find the area of square
         */
        public double Area()
        {
            return Side * Side;
        }

        public virtual double GetDoubleValue()
        {
            return Area();
        }

        public bool Save(string location)
        {
            throw new NotImplementedException();
        }

        public bool Load(string location)
        {
            throw new NotImplementedException();
        }
    }

    class Cube : Square
    {
        //public override double GetDoubleValue()
        //{
        //    return 10;
        //}
    }
}

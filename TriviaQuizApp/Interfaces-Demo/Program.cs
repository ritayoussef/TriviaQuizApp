namespace Interfaces_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] doubleValues = new double[20];
            Random random = new Random();
            for (int i = 0; i < doubleValues.Length; i++)
                doubleValues[i] = random.Next(100);

            //Use the GeometryApp and process: Points, Lines & Squares
            GeometryApp app = new GeometryApp();
            app.ProcessSquares();
            //app.ProcessPoints();


        }


        //Find the average of an array of double numbers
        public static double Average(double[] values)
        {
            if (values.Length == 0)
                throw new ArgumentException("Cannot compute average for an empty array");

            double sum = 0.0;
            foreach (double value in values)
            {
                sum += value;
            }

            return sum / values.Length;
        }
    }
}
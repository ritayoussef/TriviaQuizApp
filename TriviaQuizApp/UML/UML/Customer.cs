using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UML
{
    /// <summary>
    /// Class created based on the UML diagram show in the UML slides in class.
    /// </summary>
    class Customer
    {
        //
        private int id;
        private string firstName;
        private string lastName;

        private float discountRate = 0.0f;
        //list or array
        //private double[] sales = new double[100];
        private List<double> sales = new List<double>();

        private Address address;
        public string GetFullName()
        {
            return firstName + "  " + lastName;
        }

        public string FullName
        {
            get { return firstName + "  " + lastName; }
        }

        //public void SetID(int xyz)
        //{
        //    id = xyz;
        //}



        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public double CalculateSales()
        {
            return 10;//change 
        }

        private void SetDiscountRate(float newRate)
        {
            if (newRate > 0)
                discountRate = newRate;
            else
                discountRate = 0.0f;
        }

        public List<double> Sales
        {
            get { return sales; }
        }


    }
}

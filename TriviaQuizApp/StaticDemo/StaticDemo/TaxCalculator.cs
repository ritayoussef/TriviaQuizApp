using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDemo
{
    /// <summary>
    ///         Static class: CAN NOT BE INTIALIZED
    ///         All its members must be static
    /// </summary>
    static class TaxCalculator
    {
        //static private data field
        private static double _taxRate;
        //static property
        public static string Agency { get; private set; }

        public static double TaxRate
        {
            get
            { return _taxRate; }
            
            set
            {
                if(value > 0)
                _taxRate = value;
            }

        }

        //Constructor
        static TaxCalculator()
        {
            Agency = "CRA";
            _taxRate = 0.15;
        }

        //static method
        public static double CalculateTaxes(double income)
        {
            return income * _taxRate;
        }

    }
}

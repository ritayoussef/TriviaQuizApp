using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Interfaces
{
    internal interface ICalculate
    {
        double CalculateShipping(Order order);
    }
}

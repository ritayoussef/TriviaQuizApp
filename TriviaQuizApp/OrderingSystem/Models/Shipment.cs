using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Models
{
    /// <summary>
    /// Shipment class used track shipment of an order
    /// </summary>
    internal class Shipment
    {
        public double Cost { get; set; }
        public DateTime ShippingDate { get; set; }
    }
}

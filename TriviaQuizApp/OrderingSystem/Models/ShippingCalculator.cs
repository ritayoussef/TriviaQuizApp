using OrderingSystem.Interfaces;

namespace OrderingSystem.Models
{
    /// <summary>
    /// ShippingCalculator class used to calculate the shipping cost of an order
    /// </summary>
    /// 


    internal class ShippingCalculator :ICalculate
    {
        private const double MIN_ORDER_VALUE = 50;

        public virtual double CalculateShipping(Order order)
        {
            if (order.TotalPrice < MIN_ORDER_VALUE)
                return order.TotalPrice * 0.25;

            return 0;
        }
    }

    class HolidayCalculator : ICalculate
    {
        private readonly List<string> NorthAmericanCountries = new List<string>() { "Canada", "USA", "Mexico" };
        private const double MIN_ORDER_VALUE_NA = 30;
        private const double SHIPPING_PERCENT_NA = 0.1;
        private const double SHIPPING_COST_WORLD = 20;
        public double CalculateShipping(Order order)
        {
            if (NorthAmericanCountries.Contains(order.DestinationCountry))
            {
                if (order.TotalPrice > MIN_ORDER_VALUE_NA)
                    return 0;
                return order.TotalPrice * SHIPPING_PERCENT_NA;
            }

            return SHIPPING_COST_WORLD;
        }
    }

}

/* //Solution 1: Using inheritance.
 internal class ShippingCalculator
    {
        private const double MIN_ORDER_VALUE = 50;

        public virtual double CalculateShipping(Order order)
        {
            if (order.TotalPrice < MIN_ORDER_VALUE)
                return order.TotalPrice * 0.25;

            return 0;
        }
    }

    class HolidayCalculator : ShippingCalculator
    {
        private readonly List<string> NorthAmericanCountries = new List<string>() { "Canada", "USA", "Mexico" };
        private const double MIN_ORDER_VALUE_NA = 30;
        private const double SHIPPING_PERCENT_NA = 0.1;
        private const double SHIPPING_COST_WORLD = 20;
        public override double CalculateShipping(Order order)
        {
            if (NorthAmericanCountries.Contains(order.DestinationCountry))
            {
                if (order.TotalPrice > MIN_ORDER_VALUE_NA)
                    return 0;
                return order.TotalPrice * SHIPPING_PERCENT_NA;
            }

            return SHIPPING_COST_WORLD;
        }
    }
 */

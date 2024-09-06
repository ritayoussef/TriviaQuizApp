using OrderingSystem.Interfaces;
using OrderingSystem.Models;


namespace OrderingSystem
{
    /// <summary>
    /// Class to process any order. 
    /// This is not a utility class. Different order processors are required for different operations.
    /// </summary>
    internal class OrderProcessor
    {
        //readonly keyword allows us to initialize an object only once (safety feature, HOW? Chocolate!!)
        //private readonly ShippingCalculator _shippingCalculator;
        private readonly ICalculate _shippingCalculator;

        //Constructor
        public OrderProcessor(ICalculate shippingCalculator)
        {
            //_shippingCalculator = new ShippingCalculator();
            _shippingCalculator = shippingCalculator;
        }

        //Process an order (order object does not belong to the class, hence passed as an argument)
        public void Process(Order order)
        {
            //Defensive programming: validating that order is not processed, avoid multiple processing.
            if (order.IsShipped)
                throw new InvalidOperationException("Order already processed");

            //Initialize the shipment when order is being processed
            order.Shipment = new Shipment
            {
                Cost = _shippingCalculator.CalculateShipping(order),
                ShippingDate = DateTime.Today.AddDays(2)
            };

            order.IsShipped = true;
            //order.SendEmailNotification();
            order.SendAllNotifications();
        }
    }
}

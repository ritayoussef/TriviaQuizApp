using OrderingSystem.Models;

namespace OrderingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hello World On-line Shopping Portal!");
                Console.WriteLine("----------------------------------");

                //Processor for all orders at Hello World On-line Shop
                //ShippingCalculator shippingCalculator = new ShippingCalculator();
                //OrderProcessor orderProcessor = new OrderProcessor(shippingCalculator);
                //OrderScenario1(orderProcessor);

                //Console.WriteLine("YAAY It is almost Christmas ... ");
                ////Holidays
                //HolidayCalculator holidayCalculator = new HolidayCalculator();
                //orderProcessor = new OrderProcessor(holidayCalculator);
                //OrderScenario1(orderProcessor);

                TestSorting();

            }
            catch (Exception e)
            {
                //DO NOT throw in main
                Console.WriteLine("Error: {0}", e.Message);
            }


            /* NEW REQUIREMENTS:
             * 1. During the holidays, we need to change the shipping calculator to handle the holidays shipping.
             *  - Shipping to North America: Free for 30$ or more | Less that 30$, shipping cost is 10%
             *  - Shipping to the rest of the world: 20$ shipping cost for all orders
             * 
             * 2. Clients have requested from Hello World to provide a notification when orders are shipped.
             *  - Start by adding an EMailService Class to handle email notifications.
             *  
             *  What if we want to add another service.. Let us examine it.
             *  
             * 3. You are an expert on Sorting as you have studied the sorting problem.
             * The program should be able to sort a list of orders.
             * How can we achieve that?
             */


        }

        static void OrderScenario1(OrderProcessor orderProcessor)
        {
            //Creating an order
            Order order1 = new Order(_DatePlaced: DateTime.Now, _totalPrice: 5.50)
            { DestinationCountry = "Canada" };

            order1.RegisterNotifcation(new EmailService() { Email = "Luara@PIII.ca" });
            order1.RegisterNotifcation(new EmailService() { Email = "123456789@johnabbot.qc.ca"});
            order1.RegisterNotifcation(new SMSNotification() { PhoneNumber = "+1514123467" });

            orderProcessor.Process(order1);
            Console.WriteLine(order1.OrderStatus);

        }

        static void OrderScenario2(OrderProcessor orderProcessor)
        {
            Console.WriteLine("---------------------------------------");

            Order order2 = new Order(_DatePlaced: DateTime.Now.AddHours(1), _totalPrice: 123.45)
            { DestinationCountry = "UK" };

            orderProcessor.Process(order2);
            Console.WriteLine(order2.OrderStatus);
        }

        static void TestSorting()
        {
            List<Order> orders = new List<Order>()
            {
                new Order(DateTime.Now, 123.45),
                new Order(DateTime.Now.AddDays(10), 55.55),
                new Order(DateTime.Now.AddDays(3), 400),
                new Order(DateTime.Now.AddDays(5), 1000.50),
                new Order(DateTime.Now.AddDays(20), 5.50),
                new Order(DateTime.Now.AddDays(25), 45),
                new Order(DateTime.Now.AddHours(1), 49.50),
            };

            orders.Sort();

            foreach (Order order in orders)
            {
                Console.WriteLine(order.DatePlaced);
            }
        }
    }
}
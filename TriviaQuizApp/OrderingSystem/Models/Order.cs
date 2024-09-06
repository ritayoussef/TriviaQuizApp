using OrderingSystem.Interfaces;
using OrderingSystem.Models;

namespace OrderingSystem
{
    /// <summary>
    /// Order class created to track different orders.
    /// </summary>
    internal class Order : IComparable<Order>
    {
        private double _totalPrice;
        private DateTime _datePlaced;

        public double TotalPrice
        {
            get { return _totalPrice; }
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Total price cannot be negative");
                _totalPrice = value;
            }
        }
        public DateTime DatePlaced
        {
            get { return _datePlaced; }
            private set
            {
                if (value < DateTime.Today)
                    throw new ArgumentException("Ordering Date cannot be in the past");
                _datePlaced = value;
            }
        }

        //Using auto-implemented properties for demo purposes only
        public bool IsShipped { get; set; }
        public Shipment Shipment { get; set; }
        public string DestinationCountry { get; set; }

        public Order(DateTime _DatePlaced, double _totalPrice)
        {
            DatePlaced = _DatePlaced;
            TotalPrice = _totalPrice;
            IsShipped = false;
        }

        public string OrderStatus
        {
            get => string.Format(
                "Order Date:{0}\n" +
                "Total Price:{1}\n" +
                "Shipping Cost:{2}\n" +
                "Shipping Date:{3}\n" +
                "Destination:{4}\n",
                DatePlaced,
                TotalPrice.ToString("c"),
                Shipment.Cost == 0 ? "Free" : Shipment.Cost.ToString("c"),
                IsShipped ? Shipment.ShippingDate.ToString() : "Not Shipped",
                DestinationCountry);
        }

        //private EmailService _emailService = new EmailService() { Email = "Test@service.com" };

        //public void SendEmailNotification()
        //{
        //    _emailService.SendEmail();
        //}

        private List<INotify> _notficationServices = new List<INotify>();

        public void RegisterNotifcation(INotify service) 
        {
            _notficationServices.Add(service);
        }

        public void SendAllNotifications()
        {
            foreach (INotify service in _notficationServices)
            {
                service.SendNotification();
            }
        }

        public int CompareTo(Order? other)
        {
            // if(this.DatePlaced > other.DatePlaced)
            //    return 1;

            ////return negative value this is less than other
            //if (this.DatePlaced < other.DatePlaced)
            //    return -1;

            ////Return 0 if both objects: this and other are equal
            //return 0;

            //Or we can use CompareTo in the DateTime
            return this.DatePlaced.CompareTo( other.DatePlaced);
        }
    }
}

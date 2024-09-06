using OrderingSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Models
{
    internal class SMSNotification : INotify
    {
        public string PhoneNumber { get; set; }
        public bool SendNotification()
        {
            Console.WriteLine($"Message Sent to {PhoneNumber}");
            return true;
        }
    }
}

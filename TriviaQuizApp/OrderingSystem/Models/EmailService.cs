using OrderingSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Models
{
    internal class EmailService : INotify
    {
        public string  Email { get; set; }

        public bool SendEmail()
        {
            Console.WriteLine($"Email sent to {Email}");
            return true;
        }

        public bool SendNotification()
        {
            return SendEmail();
        }
    }
}

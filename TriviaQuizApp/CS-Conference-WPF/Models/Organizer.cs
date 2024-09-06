using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Conference_WPF.Models
{
    internal class Organizer
    {
        public string Name { get; set; }
        public string Availability { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public override string ToString()
        {
            return $"{Name},{Availability},{Country},{City}";
        }
    }
}

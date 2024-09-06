using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Conference_WPF.Repos
{
    internal static class Data
    {
        public static List<string> GetCanadianCities() 
        {
            return new List<string>()
            {
                "Montreal", "Ottawa", "Quebec City", "Toronto", "Halifax", "Victoria", "Vancouver"
            };
        }

        public static List<string> GetUSCities()
        {
            return new List<string>()
            {
                "New York", "California", "Huston", "Orlando", "Miami", "Washington", "Seattle"
            };
        }

        public static List<string> GetOtherCities()
        {
            return new List<string>()
            {
                "Damascus", "Yerevan", "Paris", "Mexico City", "London", "Moscow", "Other"
            };
        }



    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CityGameLib
{
    public static class CityChecker
    {
        private static readonly HashSet<string> _validCities = new HashSet<string>
        {
            "Kharkiv", "Kiev", "Odessa", "Lvov", "Vinnitsa"
        };

        public static bool IsValidCity(string city)
        {
            return _validCities.Contains(city);
        }
    }
}

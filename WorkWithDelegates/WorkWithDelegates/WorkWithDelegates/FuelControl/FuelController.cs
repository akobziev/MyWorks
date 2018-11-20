using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithDelegates.FuelControl
{
    public class FuelController
    {
        public static void Warning(double fuelLevel)
        {
            Console.WriteLine($"Fuel level is at {fuelLevel}. Please refill.");
        }
    }
}

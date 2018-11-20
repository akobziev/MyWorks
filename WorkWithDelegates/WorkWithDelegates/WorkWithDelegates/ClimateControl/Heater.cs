using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithDelegates.ClimateControl
{
    public class Heater
    {
        public static void SwitchOn()
        {
            Console.WriteLine("Heater switched on");
        }

        public static void SwitchOff()
        {
            Console.WriteLine("Heater switched off");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithDelegates.ClimateControl
{
    public class Heater
    {
        public static bool State { get; set; }
        public static void SwitchOn()
        {
            Console.WriteLine("Heater switched on");
        }

        public static void SwitchOff()
        {
            Console.WriteLine("Heater switched off");
        }

        internal static void OnTemeratureChanged(object sender, TempChangeEventArgs e)
        {
            if (!State && e.Temperature < 14)
            {
                State = true;
                SwitchOn();
            }
            else if (State && e.Temperature > 18)
            {
                State = false;
                SwitchOff();
            }
        }
    }
}

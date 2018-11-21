using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithDelegates.ClimateControl
{
    public class AC
    {
        public static bool State { get; set; }
        private static void SwitchOn()
        {
            Console.WriteLine("Air conditioner switched on");
        }

        private static void SwitchOff()
        {
            Console.WriteLine("Air conditioner switched off");
        }

        public static void OnTemperatureChanged(object sender, TempChangeEventArgs ev)
        {
            if (!State && ev.Temperature > 25)
            {
                State = true;
                SwitchOn();
            }
            else if (State && ev.Temperature < 24)
            {
                State = false;
                SwitchOff();
            }
        }
    }
}

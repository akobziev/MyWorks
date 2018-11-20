using WorkWithDelegates.ClimateControl;
using WorkWithDelegates.FuelControl;

namespace WorkWithDelegates
{
    public class Program
    {
        public static void Main()
        {
            WorkWithDelegate();
            WorkWithEventsOne();
            WorkWithEventsTwo();
        }

        private static void WorkWithEventsTwo()
        {
            var car = new Car { FuelTank = 2 };
            car.FuelTank = 0.16;
            car.FuelTank = 0.14;
        }

        private static void WorkWithEventsOne()
        {
            var apartment = new Apartment { AirTemperature = 26 };
            apartment.AirTemperature = 23;
            apartment.AirTemperature = 13;
            apartment.AirTemperature = 19;
        }

        private static void WorkWithDelegate()
        {
            DoMath doMath = Calculator.DoSum;
            doMath += Calculator.DoSubtraction;
            doMath += Calculator.DoDivision;
            doMath += Calculator.DoMultiplication;

            doMath?.Invoke(10, 2);
        }
    }
}

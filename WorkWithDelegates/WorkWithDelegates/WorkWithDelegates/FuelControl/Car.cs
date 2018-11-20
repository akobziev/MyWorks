using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithDelegates.FuelControl
{
    public delegate void FuelLevelHendler(double fuelLevel);

    public class Car
    {
        private double _fuelTank;
        public event FuelLevelHendler fuelLevelWorning;

        public double FuelTank
        {
            get { return _fuelTank; }
            set
            {
                _fuelTank = value;
                if (_fuelTank <= 0.15)
                {
                    fuelLevelWorning?.Invoke(_fuelTank);
                }
            }
        }

        public Car()
        {
            fuelLevelWorning += FuelController.Warning;
        }
    }
}

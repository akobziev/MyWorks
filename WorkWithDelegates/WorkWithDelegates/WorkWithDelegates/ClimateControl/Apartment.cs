using System;

namespace WorkWithDelegates.ClimateControl
{
    public delegate void TemperatureController();

    public class Apartment
    {
        private int _airTemperature;
        public event EventHandler<TempChangeEventArgs> TemperatureChange;

        public int AirTemperature
        {
            get { return _airTemperature; }
            set
            {
                int oldTemperature = _airTemperature;
                _airTemperature = value;
                if (oldTemperature != _airTemperature)
                {
                    TemperatureChange?.Invoke(this, new TempChangeEventArgs(_airTemperature));
                }
            }
        }

        public Apartment()
        {
            TemperatureChange += AC.OnTemperatureChanged;
            TemperatureChange += Heater.OnTemeratureChanged;
        }
    }
}

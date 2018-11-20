namespace WorkWithDelegates.ClimateControl
{
    public delegate void TemperatureController();

    public class Apartment
    {
        private int _airTemperature;
        public event TemperatureController SwitchOnAc;
        public event TemperatureController SwitchOffAc;
        public event TemperatureController SwitchOnHeater;
        public event TemperatureController SwitchOffheater;

        public int AirTemperature
        {
            get { return _airTemperature; }
            set
            {
                _airTemperature = value;
                if (_airTemperature > 25)
                {
                    SwitchOnAc?.Invoke();
                }
                else if (_airTemperature < 24)
                {
                    SwitchOffAc?.Invoke();
                }
                if (_airTemperature < 14)
                {
                    SwitchOnHeater?.Invoke();
                }
                else if (_airTemperature > 18)
                {
                    SwitchOffheater?.Invoke();
                }
            }
        }

        public Apartment()
        {
            SwitchOnAc += AC.SwitchOn;
            SwitchOnHeater += Heater.SwitchOn;
            SwitchOffAc += AC.SwitchOff;
            SwitchOffheater += Heater.SwitchOff;
        }
    }
}

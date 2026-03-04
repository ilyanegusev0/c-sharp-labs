namespace ObserverPattern.Core
{
    internal class Sensor
    {
        public event EventHandler<TemperatureEventArgs>? TemperatureChanged;

        private double _temperature;

        public Sensor(double temperature)
        {
            _temperature = temperature;
        }

        public void ChangeTemperature(double degrees)
        {
            _temperature += degrees;
            TemperatureChanged?.Invoke(this, new TemperatureEventArgs(_temperature));
        }
    }
}

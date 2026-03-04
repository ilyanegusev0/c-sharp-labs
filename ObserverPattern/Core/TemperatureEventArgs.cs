namespace ObserverPattern.Core
{
    internal class TemperatureEventArgs : EventArgs
    {
        private double _temperature;

        public double Temperature => _temperature;

        public TemperatureEventArgs(double temperature)
        {
            _temperature = temperature;
        }
    }
}

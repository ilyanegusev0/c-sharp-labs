using ObserverPattern.Enums;

namespace ObserverPattern.Core
{
    internal class AirConditioner
    {
        private AirConfitionerState _state;

        public AirConditioner()
        {
            _state = AirConfitionerState.Off;
        }

        public void OnTemperatureChanged(object? sender, TemperatureEventArgs e)
        {
            if (e.Temperature < 17)
                _state = AirConfitionerState.Heating;
            else if (e.Temperature > 25)
                _state = AirConfitionerState.Cooling;
            else
                _state = AirConfitionerState.Off;

            switch (_state)
            {
                case AirConfitionerState.Off:
                    Console.WriteLine("[AC] OFF");
                    break;
                case AirConfitionerState.Heating:
                    Console.WriteLine("[AC] HEATING");
                    break;
                case AirConfitionerState.Cooling:
                    Console.WriteLine("[AC] COOLING");
                    break;
            }
        }
    }
}

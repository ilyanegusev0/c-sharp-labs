namespace ObserverPattern.Core
{
    internal class SecuritySystem
    {
        public void OnTemperatureChanged(object? sender, TemperatureEventArgs e)
        {
            if(e.Temperature > 40)
                Console.WriteLine("[SECURITY] OVERHEATING");
            else if (e.Temperature < 5)
                Console.WriteLine("[SECURITY] FREEZING");
        }
    }
}

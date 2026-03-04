namespace ObserverPattern.Core
{
    internal class Display
    {
        public void OnTemperatureChanged(object? sender, TemperatureEventArgs e)
        {
            Console.WriteLine($"Temperature: {e.Temperature:F1}°C");
        }
    }
}

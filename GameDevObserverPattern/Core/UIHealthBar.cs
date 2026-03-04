namespace GameDevObserverPattern.Core
{
    internal class UIHealthBar
    {
        public void OnHealthChanged(object? sender, HealthEventArgs e)
        {
            Console.WriteLine($"[UI] Current health: {e.Health} HP.");
        }
    }
}

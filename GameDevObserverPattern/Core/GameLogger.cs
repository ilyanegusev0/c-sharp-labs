namespace GameDevObserverPattern.Core
{
    internal class GameLogger
    {
        public void OnPlayerChanged(object? sender, HealthEventArgs e)
        {
            Console.WriteLine($"[GAME LOGGER] Player health changed. Current HP: {e.Health}.");
        }
    }
}

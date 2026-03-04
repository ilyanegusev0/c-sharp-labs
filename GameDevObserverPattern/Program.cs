using GameDevObserverPattern.Core;

namespace GameDevObserverPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(100);

            UIHealthBar ui = new UIHealthBar();
            SoundSystem soundSystem = new SoundSystem();
            AchievementSystem achievementSystem = new AchievementSystem();
            GameLogger gameLogger = new GameLogger();

            player.HealthChanged += ui.OnHealthChanged;
            player.HealthChanged += soundSystem.OnHealthChanged;
            player.HealthChanged += achievementSystem.OnHealthChanged;
            player.HealthChanged += gameLogger.OnPlayerChanged;

            player.TakeDamage(1000);
            Console.WriteLine();

            player.Heal(75);
        }
    }
}

namespace GameDevObserverPattern.Core
{
    internal class AchievementSystem
    {
        public void OnHealthChanged(object? sender, HealthEventArgs e)
        {
            if (e.Health <= 50)
                Console.WriteLine("[ACHIEVEMENT SYSTEM] Unlocked new achievement: Half Health!");

            if (e.Health <= 0)
                Console.WriteLine("[ACHIEVEMENT SYSTEM] Unlocked new achivement: First Death!");
        }
    }
}

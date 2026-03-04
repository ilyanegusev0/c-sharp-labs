namespace GameDevObserverPattern.Core
{
    internal class SoundSystem
    {
        public void OnHealthChanged(object? sender, HealthEventArgs e)
        {
            if (e.Health < 20)
                Console.WriteLine("[SOUND SYSTEM] *Critical health sound plays*");
            else
                Console.WriteLine("[SOUND SYSTEM] *Damage sound plays*");
        }
    }
}

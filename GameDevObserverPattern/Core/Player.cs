using static System.Net.Mime.MediaTypeNames;

namespace GameDevObserverPattern.Core
{
    internal class Player
    {
        private readonly int _maxHealth;
        private int _health;

        public event EventHandler<HealthEventArgs>? HealthChanged;

        public Player(int maxHealth = 100)
        {
            _maxHealth = maxHealth;
        }

        public void TakeDamage(int damage)
        {
            _health = Math.Max(0, _health - damage);
            Console.WriteLine($"[PLAYER] Player took {damage} DP.");
            HealthChanged?.Invoke(this, new HealthEventArgs(_health));
        }
        public void Heal(int amount)
        {
            _health = Math.Min(_maxHealth, _health + amount);
            Console.WriteLine($"[PLAYER] Player healed {amount} HP.");
            HealthChanged?.Invoke(this, new HealthEventArgs(_health));
        }
    }
}

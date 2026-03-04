namespace GameDevObserverPattern.Core
{
    internal class HealthEventArgs : EventArgs
    {
        private int _health;

        public int Health => _health;

        public HealthEventArgs(int health)
        {
            _health = health;
        }
    }
}

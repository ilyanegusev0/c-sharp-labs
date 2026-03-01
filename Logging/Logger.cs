namespace Logging
{
    internal class Logger
    {
        public Action<string> LogHandler;

        public void Log(string message)
        {
            LogHandler?.Invoke(message);
        }
    }
}

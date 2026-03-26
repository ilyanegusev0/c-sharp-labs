namespace Task2
{
    internal class MessagePublisher
    {
        public event EventHandler<MessageEventArgs> MessageSent;

        public void Send(string sender, string message)
        {
            MessageSent?.Invoke(this, new MessageEventArgs(sender, message));
        }
    }
}

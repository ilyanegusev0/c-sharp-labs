namespace Task2
{
    internal class MessageEventArgs : EventArgs
    {
        public string Sender { get; }
        public string Text { get; }
        public DateTime Date { get; }

        public MessageEventArgs(string sender, string text)
        {
            Sender = sender;
            Text = text;
            Date = DateTime.Now;
        }
    }
}

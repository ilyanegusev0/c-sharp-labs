namespace TaskTracker
{
    internal class Task
    {
        private static int _index = 1;

        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }

        public Task(string title)
        {
            Id = _index++;
            Title = title;
            IsCompleted = false;
        }

        public override string ToString()
        {
            return $" - Task #{Id}. {Title} ({IsCompleted})";
        }

        public void Complete()
        {
            IsCompleted = true;
        }
    }
}

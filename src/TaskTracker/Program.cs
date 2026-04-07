namespace TaskTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string SAVE_FILE = "tasks.json";

            TaskManager? taskManager = TaskManager.Load(SAVE_FILE) ?? new TaskManager();

            taskManager.ShowTasks();

            Task task1 = new Task("Bug Fixing");
            Task task2 = new Task("Feature Development");

            taskManager.AddTask(task1, task2);

            task2.Complete();

            taskManager.Save(SAVE_FILE);
        }
    }
}

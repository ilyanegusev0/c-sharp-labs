using System.Text.Json;

namespace TaskTracker
{
    internal class TaskManager
    {
        public List<Task> Tasks { get; set; }

        public TaskManager()
        {
            Tasks = new List<Task>();
        }

        public void AddTask(params Task[] tasks)
        {
            Tasks.AddRange(tasks);

            foreach (var task in tasks)
                Console.WriteLine($"Task #{task.Id} added.");
        }

        public void ShowTasks()
        {
            Console.WriteLine($"TASKS ({Tasks.Count}):\n" +
                $"{new string('-', 50)}");
            foreach (var task in Tasks)
                Console.WriteLine(task);
            Console.WriteLine();
        }

        public void Save(string path)
        {
            string json = JsonSerializer.Serialize(this);
            File.WriteAllText(path, json);
            Console.WriteLine($"\nSaved {Tasks.Count} tasks.");
        }

        public static TaskManager? Load(string path)
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                TaskManager? taskManager = JsonSerializer.Deserialize<TaskManager>(json);
                Console.WriteLine($"Loaded {taskManager?.Tasks.Count} tasks.\n");
                return taskManager;
            }
            else
            {
                return null;
            }
        }
    }
}

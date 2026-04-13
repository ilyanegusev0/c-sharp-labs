using System.Text.Json;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string OUTPUT_FILE = "students.json";

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            List<Student> serializedStudents = new List<Student>();

            serializedStudents.Add(new Student("Alex", 17));
            serializedStudents.Add(new Student("Jhon", 15));
            serializedStudents.Add(new Student("Alice", 16));
            serializedStudents.Add(new Student("Harry", 13));
            serializedStudents.Add(new Student("Mary", 14));

            string json = JsonSerializer.Serialize(serializedStudents, options);
            File.WriteAllText(OUTPUT_FILE, json);

            List<Student>? deserializedStudent = new List<Student>();

            json = File.ReadAllText(OUTPUT_FILE);
            deserializedStudent = JsonSerializer.Deserialize<List<Student>>(json, options) ?? new List<Student>();

            Console.WriteLine($"STUDENTS ({deserializedStudent.Count}):");
            foreach (var student in deserializedStudent)
                Console.WriteLine($" - {student.Name} | AGE: {student.Age} | AVG: {student.AverageScore}");
        }
    }
}

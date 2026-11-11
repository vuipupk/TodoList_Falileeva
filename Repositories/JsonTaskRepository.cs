using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using TodoListWPF.Models;

namespace TodoListWPF.Repositories
{
    public class JsonTaskRepository : ITaskRepository
    {
        private readonly string _filePath = "tasks.json";

        public List<TodoModel> LoadTasks()
        {
            if (!File.Exists(_filePath)) return new List<TodoModel>();
            string json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<TodoModel>>(json) ?? new List<TodoModel>();
        }

        public void SaveTasks(IEnumerable<TodoModel> tasks)
        {
            string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}







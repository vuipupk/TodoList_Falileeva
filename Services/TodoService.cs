using System.Collections.ObjectModel;
using TodoListApp.Models;
using TodoListApp.Repositories;

namespace TodoListApp.Services
{
    public class TodoService
    {
        private readonly ITaskRepository _repository;
        public ObservableCollection<TodoModel> Tasks { get; set; }

        public TodoService(ITaskRepository repository)
        {
            _repository = repository;
            Tasks = new ObservableCollection<TodoModel>(_repository.LoadTasks());
        }

        public void AddTask(TodoModel task) => Tasks.Add(task);

        public void DeleteTask(TodoModel task) => Tasks.Remove(task);

        public void Save() => _repository.SaveTasks(Tasks);

        public void Load()
        {
            var loadedTasks = _repository.LoadTasks();
            Tasks.Clear();
            foreach (var task in loadedTasks) Tasks.Add(task);
        }
    }
}





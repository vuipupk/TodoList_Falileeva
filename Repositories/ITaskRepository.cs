using System.Collections.Generic;
using TodoListApp.Models;

namespace TodoListApp.Repositories
{
    public interface ITaskRepository
    {
        List<TodoModel> LoadTasks();
        void SaveTasks(IEnumerable<TodoModel> tasks);
    }
}

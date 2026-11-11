using System.Collections.Generic;
using TodoListWPF.Models;

namespace TodoListWPF.Repositories
{
    public interface ITaskRepository
    {
        List<TodoModel> LoadTasks();
        void SaveTasks(IEnumerable<TodoModel> tasks);
    }
}

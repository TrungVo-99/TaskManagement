using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TaskManagement.Models;

namespace TaskManagement.Repositories.Interfaces
{
    public interface ITaskRepository : IRepository<Task>
    {
        IEnumerable<Task> GetAllTask();

        bool CreateTask(Task task);

        bool DeleteTask(Task task);

        bool EditTask(string taskId,Task task);
    }
}

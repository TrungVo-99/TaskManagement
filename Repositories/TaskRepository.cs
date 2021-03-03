using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TaskManagement.Models;
using TaskManagement.Repositories.Interfaces;

namespace TaskManagement.Repositories
{
    public class TaskRepository : Repository<Task>, ITaskRepository
    {
        public TaskRepository(DbContext context) : base(context) { }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;

        public bool CreateTask(Task task)
        {
            _appContext.Add(task);
            _appContext.SaveChanges();
            return true;
        }

        public bool DeleteTask(Task task)
        {
            _appContext.Tasks.Remove(task);
            _appContext.SaveChanges();

            return true;
        }

        public bool EditTask(string taskId ,Task task)
        {

            // var tempTask = _appContext.Tasks.FirstOrDefault(t => t.TaskId == task.TaskId);
            /* var exist = _appContext.Tasks.FirstOrDefault(task => task.TaskId == task.TaskId);
             if (exist ! == null)
             {
                 exist.TaskStatus = 2;

             }
 */

            task.TaskStatus = 2;
            _appContext.Tasks.Update(task);
            _appContext.SaveChanges();

            return true;
        }

        public IEnumerable<Task> GetAllTask()
        {
           /* Task ta = new Task()
            {
                TaskName = "test",
                TaskStatus = 1,
                CreatedAt =DateTime.Now
            };

            _appContext.Tasks.Add(ta);
            _appContext.SaveChanges();*/
            var result = _appContext.Tasks.ToList();

            return result;
        }
    }

}

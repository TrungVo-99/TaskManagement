using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Repositories;
using TaskManagement.Repositories.Interfaces;

namespace TaskManagement
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContext _context;

        ITaskRepository _task;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public ITaskRepository Task
        {
            get
            {
                if (_task == null )
                {
                    _task = new TaskRepository(_context);
                }

                return _task;
            }
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }


    }
}

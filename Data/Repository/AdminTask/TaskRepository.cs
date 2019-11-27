using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Data.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext context;
        public TaskRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Delete(AdminTask adminTask)
        {
            context.AdminTasks.Remove(adminTask);
        }

        public IQueryable<AdminTask> GetAll()
        {
            return context.AdminTasks;
        }

        public AdminTask GetById(long Id)
        {
            return context.AdminTasks.Find(Id);
        }

        public IQueryable<AdminTask> GetTodaysTasks()
        {
            return context.AdminTasks.Where(t => t.Date == DateTime.Now.Date).Include(t => t.Location);
        }

        public void Insert(AdminTask adminTask)
        {
            context.AdminTasks.Add(adminTask);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(AdminTask adminTask)
        {
            context.AdminTasks.Attach(adminTask);
            context.Entry(adminTask).State = EntityState.Modified;
        }
    }
}
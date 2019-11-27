using SchoolManagementSystem.Models;
using System.Linq;
namespace SchoolManagementSystem.Data.Repository
{
    public interface ITaskRepository
    {
        IQueryable<AdminTask> GetAll();
        void Insert(AdminTask adminTask);
        void Update(AdminTask adminTask);
        void Delete(AdminTask adminTask);
        void Save();
        IQueryable<AdminTask> GetTodaysTasks();
    }
}
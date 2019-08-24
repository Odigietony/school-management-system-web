using System.Collections.Generic;
using System.Linq;

namespace SchoolManagementSystem.Data.Repository
{
    public interface IEntityRepository<TEntity> where TEntity: class
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(object Id);
        void Insert(TEntity data);
        void Update(TEntity data);
        void Delete(object Id);
        void Save();
    }
}
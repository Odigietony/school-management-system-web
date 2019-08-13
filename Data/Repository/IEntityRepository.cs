using System.Collections.Generic;

namespace SchoolManagementSystem.Data.Repository
{
    public interface IEntityRepository<TEntity> where TEntity: class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(object Id);
        void Insert(TEntity data);
        void Update(TEntity data);
        void Delete(object Id);
        void Save();
    }
}
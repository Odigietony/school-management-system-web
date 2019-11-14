using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Data.Repository
{
    public class EntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;

        private DbSet<TEntity> entity;

        public EntityRepository(AppDbContext context)
        {
            _context = context;
            entity = _context.Set<TEntity>();
        }
        public void Delete(object Id)
        {
           TEntity data = entity.Find(Id);
           _context.Remove(data); 
        }

        public IQueryable<TEntity> GetAll()
        {
            return entity;
        }

        public Admin GetByUserId(string Id)
        {
            Admin admin = _context.Admins.FirstOrDefault(x => x.IdentityUserId == Id);
            return admin;
        }

        public TEntity GetById(object Id)
        {
            return entity.Find(Id);
        }

        public void Insert(TEntity data)
        {
            _context.Add(data);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(TEntity data)
        {
            entity.Attach(data);
            _context.Entry(data).State = EntityState.Modified;
        }
    }
}
using PlannerPlus.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PlannerPlus.Database;

namespace PlannerPlus.Repositories
{
    public class GeneralRepository<T> : IRepository<T>
        where T : EntityBase
    {
        private readonly PlannerContext _context;
        private readonly DbSet<T> _dbSet;
        public GeneralRepository(PlannerContext context)
        {
            _context = context; 
            _dbSet = context.Set<T>();
        }
        public void Create(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
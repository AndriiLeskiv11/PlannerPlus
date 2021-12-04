using System;
using System.Collections.Generic;
using PlannerPlus.Models;

namespace PlannerPlus.Repositories
{
    public interface IRepository<T> 
        where T : EntityBase
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
        T Get(int id);
        IEnumerable<T> GetAll();
    }
}
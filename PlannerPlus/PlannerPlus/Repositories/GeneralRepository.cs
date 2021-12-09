using PlannerPlus.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PlannerPlus.Database;
using Ardalis.Specification.EntityFrameworkCore;

namespace PlannerPlus.Repositories
{
    public class GeneralRepository<T> : RepositoryBase<T> where T : class
    {
        public GeneralRepository(PlannerContext context) : base(context)
        {
            
        }
        
    }
}
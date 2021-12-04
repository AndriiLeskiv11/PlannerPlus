using PlannerPlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlannerPlus.Repositories;

namespace PlannerPlus.BusinessLogic
{
    public class MastersService : IMastersService
    {
        private readonly IRepository<Master> _repository;
        public MastersService(IRepository<Master> repository)
        {
            _repository = repository;
        }
        public void Add(Master master)
        {
            if (string.IsNullOrEmpty(master.Name))
            {
                throw new Exception("Wrong name of Master");
            }

            _repository.Create(master);
            _repository.Save();
        }

        public IEnumerable<Master> GetAll()
        {
            return _repository.GetAll();
        }
    }
}

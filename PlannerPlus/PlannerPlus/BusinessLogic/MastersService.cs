using PlannerPlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlannerPlus.Repositories;
using Ardalis.Specification;

namespace PlannerPlus.BusinessLogic
{
    public class MastersService : IMastersService
    {
        private readonly IRepositoryBase<Master> _repository;
        public MastersService(IRepositoryBase<Master> repository)
        {
            _repository = repository;
        }
        public async Task AddAsync(Master master)
        {
            if (string.IsNullOrEmpty(master.Name))
            {
                throw new Exception("Wrong name of Master");
            }

            await _repository.AddAsync(master);
            await _repository.SaveChangesAsync();
        }

        public Task<List<Master>> GetAllAsync()
        {
            return _repository.ListAsync();
        }

        public async Task DeleteAsync(int masterId)
        {
            var master = new Master()
            {
                Id = masterId
            };
            await _repository.DeleteAsync(master);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Master master)
        {
            await _repository.UpdateAsync(master);
            await _repository.SaveChangesAsync();
        }
    }
}

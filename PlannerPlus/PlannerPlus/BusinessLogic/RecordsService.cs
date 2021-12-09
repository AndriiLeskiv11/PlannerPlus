using Ardalis.Specification;
using PlannerPlus.Models;
using PlannerPlus.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerPlus.BusinessLogic
{
    public class RecordsService : IRecordsService
    {
        private readonly IRepositoryBase<Record> _repository;
        public RecordsService (IRepositoryBase<Record> repository)
        {
            _repository = repository;
        }
        public async Task AddAsync(Record record)
        {
            if (record.SeviceTime< DateTime.Now)
            {
                throw new Exception("Exception of Record");
            }
            await _repository.AddAsync(record);
            await _repository.SaveChangesAsync();
        }

        public Task<List<Record>> GetAllRecordsAsync()
        {
            return _repository.ListAsync();
        }
    }
}

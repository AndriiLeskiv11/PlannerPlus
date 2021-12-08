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
        private readonly IRepository<Record> _repository;
        public RecordsService (IRepository<Record> repository)
        {
            _repository = repository;
        }
        public void Add(Record record)
        {
            if (record.SeviceTime< DateTime.Now)
            {
                throw new Exception("Exception of Record");
            }
            _repository.Create(record);
            _repository.Save();
        }

        public IEnumerable<Record> GetAllRecords()
        {
            return _repository.GetAll();
        }
    }
}

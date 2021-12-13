using Ardalis.Specification;
using PlannerPlus.Models;
using PlannerPlus.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using PlannerPlus.Specifications.Master;
using PlannerPlus.Specifications.Record;
using PlannerPlus.Specifications.WorkDay;

namespace PlannerPlus.BusinessLogic
{
    public class RecordsService : IRecordsService
    {
        private readonly IRepositoryBase<Record> _repository;
        private readonly IRepositoryBase<WorkDay> _workDayRepository;
        private readonly IRepositoryBase<Master> _masterRepository;

        public RecordsService (IRepositoryBase<Record> repository,IRepositoryBase<WorkDay> workDayRepository,IRepositoryBase<Master> masterRepository)
        {
            _repository = repository;
            _workDayRepository = workDayRepository;
            _masterRepository = masterRepository;
        }
        public async Task AddAsync(Record record)
        {
            if (record.StartTime < DateTime.Now)
            {
                throw new Exception("Exception of Record");
            }

            var workDaySpec = new WorkDayByMasterIncludingRangeSpec(record.StartTime, record.EndTime, record.MasterId);
            int workDayCount = await _workDayRepository.CountAsync(workDaySpec);
            if (workDayCount == 0)
            {
                throw new Exception("Is not a work day");
            }
            var recordSpec = new OverlappingRecordsByMater(record.StartTime, record.EndTime, record.MasterId);
            int recordCount = await _repository.CountAsync(recordSpec);
            if (recordCount > 0)
            {
                throw new Exception("There's existing record for that date");
            }

            var masterWithServiceSpec = new MasterWithServicesSpec(record.MasterId);
            var master = await _masterRepository.GetBySpecAsync(masterWithServiceSpec);

            if (master == null)
            {
                throw new Exception("This master doesn't exist");
            }

            if (master.Services.All(s => s.Id != record.ServiceId))
            {
                throw new Exception("This master doesn't provide such a service");
            }

            await _repository.AddAsync(record);
            await _repository.SaveChangesAsync();
        }

        public Task<List<Record>> GetAllRecordsAsync()
        {
            return _repository.ListAsync();
        }

        public Task<List<Record>> GetRecordsByDateAndMasterAsync(DateTime date, int masterId)
        {
            var spec = new RecordByDateAndMasterSpec(date, masterId);

            return _repository.ListAsync(spec);
        }
    }
}

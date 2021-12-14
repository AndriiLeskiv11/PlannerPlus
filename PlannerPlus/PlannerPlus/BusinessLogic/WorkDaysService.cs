using PlannerPlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.Specification;
using PlannerPlus.Specifications.WorkDay;

namespace PlannerPlus.BusinessLogic
{
    public class WorkDaysService : IWorkDaysService
    {
        private readonly IRepositoryBase<WorkDay> _repository;

        public WorkDaysService(IRepositoryBase<WorkDay> repository)
        {
            _repository = repository;
        }
        public async Task AddWorkDaysAsync(List<WorkDay> workDays)
        {
            foreach (var workDay in workDays)
            {
                if (workDay.StartTime >= workDay.FinishTime)
                {
                    throw new Exception("Not valid work day");
                }
                await _repository.AddAsync(workDay);
            }
            await _repository.SaveChangesAsync();
        }

        public  Task<List<WorkDay>> GetMasterWorkDaysAsync(int masterId, DateTime startDate, DateTime endDate)
        {
            var spec = new WorkDaysByMasterAndRangeSpec(masterId,startDate,endDate);
            return _repository.ListAsync(spec);
        }

        public async Task DeleteWorkDayAsync(List<int> ids)
        {
            await _repository.DeleteRangeAsync(
                ids.Select(id=>
                    new WorkDay
                    {
                        Id=id
                    }));
            await _repository.SaveChangesAsync();
        }

        public Task UpdateWorkDayAsync(WorkDay workday)
        {
            return _repository.UpdateAsync(workday);
        }
    }
}

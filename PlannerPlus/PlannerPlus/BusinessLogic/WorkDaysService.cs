using PlannerPlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.Specification;

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
                await _repository.AddAsync(workDay);
            }
            await _repository.SaveChangesAsync();
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
    }
}

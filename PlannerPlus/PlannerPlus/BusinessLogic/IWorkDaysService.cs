using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlannerPlus.Models;

namespace PlannerPlus.BusinessLogic
{
    public interface IWorkDaysService
    {
        Task AddWorkDaysAsync(List<WorkDay> workDays);
        Task DeleteWorkDayAsync(List<int> ides);

    }
}

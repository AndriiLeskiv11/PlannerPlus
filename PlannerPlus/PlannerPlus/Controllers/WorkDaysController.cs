using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using PlannerPlus.BusinessLogic;
using PlannerPlus.Dto;
using PlannerPlus.Models;

namespace PlannerPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WorkDaysController : ControllerBase
    {
        private readonly IWorkDaysService _daysService;

        public WorkDaysController(IWorkDaysService daysService)
        {
            _daysService = daysService;
        }

        [HttpPost]
        public Task AddWorkDayAsync(List<WorkDay> workDay)
        {
            return _daysService.AddWorkDaysAsync(workDay);
        }

        [HttpDelete]
        public Task DeleteWorkDaysAsync(List<int> ids)
        {
            return _daysService.DeleteWorkDayAsync(ids);
        }

        [HttpPut]
        public Task UpdateWorkDayAsync(WorkDay workday)
        {
            return _daysService.UpdateWorkDayAsync(workday);
        }

        [HttpPost("get-master-schedule")]
        public Task<List<WorkDay>> GetMasterWorkDaysAsync(GetWorkDayDto getWorkDayDto)
        {
            return _daysService.GetMasterWorkDaysAsync(getWorkDayDto.MasterId, getWorkDayDto.StartDate,
                getWorkDayDto.EndDate);
        }

    }
}

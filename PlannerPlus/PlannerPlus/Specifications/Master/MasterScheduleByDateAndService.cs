using System;
using System.Collections.Generic;
using System.Linq;
using Ardalis.Specification;
using PlannerPlus.Dto;

namespace PlannerPlus.Specifications.Master
{
    public class MasterScheduleByDateAndService : Specification<Models.Service,List<MasterScheduleDto>>
    {
        public MasterScheduleByDateAndService(int serviceId, DateTime date)
        {
            var currentDate = date.Date;
            var nextDate = currentDate.AddDays(1);

            Query.Where(s => s.Id == serviceId)
                .Include(s => s.Masters)
                .ThenInclude(m => m.Records);
        } 
    }
}

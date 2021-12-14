using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace PlannerPlus.Specifications.WorkDay
{
    public class WorkDaysByMasterAndRangeSpec:Specification<Models.WorkDay>
    {
        public WorkDaysByMasterAndRangeSpec(int masterId, DateTime startDate, DateTime endDate)
        {
            Query.Where(w => w.MasterId == masterId && w.StartTime >= startDate && w.FinishTime <= endDate);
        }
    }
}

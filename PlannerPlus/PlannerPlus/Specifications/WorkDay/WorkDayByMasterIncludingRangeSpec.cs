using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace PlannerPlus.Specifications.WorkDay
{
    public class WorkDayByMasterIncludingRangeSpec : Specification<Models.WorkDay>
    {
        public WorkDayByMasterIncludingRangeSpec(DateTime startTime, DateTime endTime, int masterId)
        {
            Query.Where(w => w.MasterId == masterId && w.StartTime <= startTime && w.FinishTime >= endTime);
        }
    }
}

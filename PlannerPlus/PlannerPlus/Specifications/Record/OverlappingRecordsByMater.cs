using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PlannerPlus.Specifications.Record
{
    public class OverlappingRecordsByMater  :Specification<Models.Record>
    {
        public OverlappingRecordsByMater(DateTime startTime,DateTime endTime,int masterId)
        {
            Query.Where(r => r.MasterId == masterId &&
                            (r.StartTime > startTime ? r.StartTime : startTime) <
                            (r.EndTime < endTime ? r.EndTime : endTime ));
        }
    }
}

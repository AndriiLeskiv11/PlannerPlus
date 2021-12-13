using System;
using Ardalis.Specification;

namespace PlannerPlus.Specifications.Record
{
    public class RecordByDateAndMasterSpec : Specification<Models.Record>
    {
        public RecordByDateAndMasterSpec(DateTime date, int masterId)
        {
            var currentDate = date.Date;
            var nextDate = currentDate.AddDays(1);

            Query.Where(r => r.MasterId == masterId && r.StartTime >= currentDate && r.StartTime < nextDate)
                .Include(r => r.Master)
                .Include(r => r.Client)
                .Include(r => r.Service);
        }
    }
}

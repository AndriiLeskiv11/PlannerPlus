using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace PlannerPlus.Specifications.Master
{
    public class MasterWithServicesSpec : Specification<Models.Master>, ISingleResultSpecification
    {
        public MasterWithServicesSpec(int masterId)
        {
            Query.Where(m => m.Id == masterId)
                .Include(m => m.Services);
        }
    }
}

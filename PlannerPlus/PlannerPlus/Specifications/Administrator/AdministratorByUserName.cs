using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace PlannerPlus.Specifications.Administrator
{
    public class AdministratorByUserName:Specification<Models.Administrator>, ISingleResultSpecification
    {
        public AdministratorByUserName(string username)
        {
            Query.Where(a => a.UserName == username);
        }
    }
}

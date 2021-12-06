using PlannerPlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerPlus.BusinessLogic
{
    public interface IServicesService
    {
        void Add(Service service);
        IEnumerable<Service> GetAllServices();


    }
}

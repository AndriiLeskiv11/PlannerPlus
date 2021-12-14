using PlannerPlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerPlus.BusinessLogic
{
    public interface IServicesService
    {
        Task AddAsync(Service service);
        Task<List<Service>> GetAllServicesAsync();
        Task DeleteServiceAsync(int serviceId);
        Task UpdateServiceAsync(Service service);

    }
}

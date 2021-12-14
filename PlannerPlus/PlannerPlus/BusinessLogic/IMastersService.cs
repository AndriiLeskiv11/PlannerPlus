using PlannerPlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerPlus.BusinessLogic
{
    public interface IMastersService
    {
        Task AddAsync(Master master);
        Task<List<Master>> GetAllAsync();
        Task DeleteAsync(int masterId);
        Task UpdateAsync(Master master);
        Task AddMasterServiceAsync(int masterId, int serviceId);
    }
}

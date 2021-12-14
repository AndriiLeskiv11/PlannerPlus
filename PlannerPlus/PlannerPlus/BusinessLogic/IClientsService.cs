using PlannerPlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerPlus.BusinessLogic
{
    public interface IClientsService
    {
        Task AddAsync(Client client);
        Task<List<Client>> GetAllClientsAsync();

        Task DeleteClientAsync(int clientId);
        Task UpdateClientAsync(Client client);
    }
}

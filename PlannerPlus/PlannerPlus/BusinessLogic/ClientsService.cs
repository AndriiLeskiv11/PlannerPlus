using Ardalis.Specification;
using PlannerPlus.Models;
using PlannerPlus.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerPlus.BusinessLogic
{
    public class ClientsService : IClientsService
    {
        private readonly IRepositoryBase<Client> _repsitory;
        public ClientsService (IRepositoryBase<Client> repository)
        {
            _repsitory = repository;
        } 
        public async Task AddAsync(Client client)
        {
            if (string.IsNullOrEmpty(client.Name))
            {
                throw new Exception("Wrong name of client");
            }
            await _repsitory.AddAsync(client);
            await _repsitory.SaveChangesAsync();
        }

        public Task<List<Client>> GetAllClientsAsync()
        {
           return _repsitory.ListAsync();
        }
    }
}

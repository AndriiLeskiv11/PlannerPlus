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
        private readonly IRepository<Client> _repsitory;
        public ClientsService (IRepository<Client> repository)
        {
            _repsitory = repository;
        } 
        public void Add(Client client)
        {
            if (string.IsNullOrEmpty(client.Name))
            {
                throw new Exception("Wrong name of client");
            }
            _repsitory.Create(client);
            _repsitory.Save();
        }

        public IEnumerable<Client> GetAllClients()
        {
           return _repsitory.GetAll();
        }
    }
}

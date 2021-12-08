using PlannerPlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerPlus.BusinessLogic
{
    public interface IClientsService
    {
        void Add(Client client);
        IEnumerable<Client> GetAllClients();

    }
}

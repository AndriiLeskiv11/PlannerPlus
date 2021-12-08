using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlannerPlus.BusinessLogic;
using PlannerPlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsService _clientsServices;
        public ClientsController(IClientsService clientsService)
        {
            _clientsServices = clientsService;
        }

        [HttpPost]
        public void Create(Client client)
        {
            _clientsServices.Add(client);
        }

        [HttpGet]
        public List<Client> GetAllClients()
        {
            return _clientsServices.GetAllClients().ToList();
        }
    }
}

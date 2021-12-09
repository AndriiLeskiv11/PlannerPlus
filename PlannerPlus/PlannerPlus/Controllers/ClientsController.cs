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
        public Task Create(Client client)
        {
            return _clientsServices.AddAsync(client);
        }

        [HttpGet]
        public Task<List<Client>> GetAllClientsAsync()
        {
            return _clientsServices.GetAllClientsAsync();
        }
    }
}

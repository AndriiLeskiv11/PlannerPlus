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
    public class ServicesController : ControllerBase
    {
        private readonly IServicesService _servicesService;

        public ServicesController(IServicesService servicesService)
        {
            _servicesService = servicesService;
        }

        [HttpPost]
        public void Create(Service service)
        {
            _servicesService.Add(service);
        }

        [HttpGet]

        public List<Service> GetAllServices()
        {
            return _servicesService.GetAllServices().ToList();
        }
    }
}

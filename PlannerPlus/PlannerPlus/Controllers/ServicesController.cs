﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlannerPlus.BusinessLogic;
using PlannerPlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace PlannerPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ServicesController : ControllerBase
    {
        private readonly IServicesService _servicesService;

        public ServicesController(IServicesService servicesService)
        {
            _servicesService = servicesService;
        }

        [HttpPost]
        public Task CreateAsync(Service service)
        {
            return _servicesService.AddAsync(service);
        }

        [HttpGet]
        public Task<List<Service>> GetAllServicesAsync()
        {
            return _servicesService.GetAllServicesAsync();
        }

        [HttpDelete]
        public Task DeleteServiceAsync(int serviceId)
        {
            return _servicesService.DeleteServiceAsync(serviceId);
        }

        [HttpPut]
        public Task UpdateServiceAsync(Service service)
        {
            return _servicesService.UpdateServiceAsync(service);
        }
    }
}

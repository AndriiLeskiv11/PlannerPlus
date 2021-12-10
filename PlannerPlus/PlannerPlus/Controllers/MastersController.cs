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
    public class MastersController : ControllerBase
    {
        private readonly IMastersService _mastersService;

        public MastersController(IMastersService mastersservise)
        {
            _mastersService = mastersservise;
        }

        [HttpPost]
        public  Task Create(Master master)
        {
           return _mastersService.AddAsync(master);
        }

        [HttpGet]
        public Task<List<Master>> GetAll()
        {
           return _mastersService.GetAllAsync();

        }

        [HttpDelete]
        public Task DeleteAsync(int masterId)
        {
            return _mastersService.DeleteAsync(masterId);
        }

        [HttpPut]
        public Task UpdateAsync(Master master)
        {
            return _mastersService.UpdateAsync(master);
        }
    }
}

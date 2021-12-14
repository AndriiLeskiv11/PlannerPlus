using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlannerPlus.BusinessLogic;
using PlannerPlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using PlannerPlus.Dto;

namespace PlannerPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MastersController : ControllerBase
    {
        private readonly IMastersService _mastersService;

        public MastersController(IMastersService mastersservise)
        {
            _mastersService = mastersservise;
        }

        [HttpPost]
        public  Task CreateAsync(Master master)
        {
           return _mastersService.AddAsync(master);
        }

        [HttpGet]
        public Task<List<Master>> GetAllAsync()
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

        [HttpPost("add-master-service")]
        public Task AddMasterServiceAsync(MasterServiceDto masterServiceDto)
        {
            return _mastersService.AddMasterServiceAsync(masterServiceDto.MasterId,masterServiceDto.ServiceId);
        }



    }
}

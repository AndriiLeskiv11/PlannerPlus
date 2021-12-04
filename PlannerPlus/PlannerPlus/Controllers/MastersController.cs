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
        public  void Create(Master master)
        {
            _mastersService.Add(master);
        }

        [HttpGet]
        public List<Master> GetAll()
        {
           return _mastersService.GetAll().ToList();

        } 
    }
}

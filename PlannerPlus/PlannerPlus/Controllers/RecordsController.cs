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
    public class RecordsController : ControllerBase
    {
        private readonly IRecordsService _recordsService;
        public RecordsController(IRecordsService recordsService)
        {
            _recordsService = recordsService;
        }

        [HttpPost]
        public void Create(Record record)
        {
            _recordsService.Add(record);
        }

        [HttpGet]

        public List<Record> GetAllRecords() 
        {
            return _recordsService.GetAllRecords().ToList();
        }
    }
}

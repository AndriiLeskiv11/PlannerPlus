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
        public Task CreateAsync(Record record)
        {
           return _recordsService.AddAsync(record);
        }

        [HttpGet]

        public Task<List<Record>> GetAllRecordsAsync() 
        {
            return _recordsService.GetAllRecordsAsync();
        }

        [HttpGet("by-date-and-master")]
        public Task<List<Record>> GetRecordsByDateAndMasterAsync(DateTime date, int masterId)
        {
            return _recordsService.GetRecordsByDateAndMasterAsync(date,masterId);
        }
    }
}

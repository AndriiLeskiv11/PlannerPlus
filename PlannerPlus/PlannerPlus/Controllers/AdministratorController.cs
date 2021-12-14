using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlannerPlus.BusinessLogic;
using PlannerPlus.Dto;
using PlannerPlus.Models;

namespace PlannerPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        private readonly IAdministratorService _administratorService;

        public AdministratorController(IAdministratorService administratorService)
        {
            _administratorService = administratorService;
        }

        [HttpPost("register")]
        public Task RegisterAsync(Administrator administrator)
        {
            return _administratorService.RegisterAsync(administrator);
        }

        [HttpPost("login")]
        public Task<LoginResultDto> LoginAsync(LoginDto loginDto)
        {
            return _administratorService.LoginAsync(loginDto.UserName,loginDto.Password);
        }
    }
}

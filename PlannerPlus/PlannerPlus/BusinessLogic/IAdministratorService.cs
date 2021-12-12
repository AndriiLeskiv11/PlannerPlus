using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlannerPlus.Dto;
using PlannerPlus.Models;

namespace PlannerPlus.BusinessLogic
{
    public interface IAdministratorService
    {
        Task RegisterAsync(Administrator administrator);
        Task<LoginResultDto> LoginAsync(string username, string password);

    }
}

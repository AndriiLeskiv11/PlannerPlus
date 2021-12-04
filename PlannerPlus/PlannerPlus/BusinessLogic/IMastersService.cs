using PlannerPlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerPlus.BusinessLogic
{
    public interface IMastersService
    {
        void Add(Master master);
        IEnumerable<Master> GetAll();

    }
}

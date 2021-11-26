using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerPlus.Models
{
    public class Master : EntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public List<Service> Services { get; set; } = new List<Service>();
        public List<WorkDay> WorkDays { get; set; } = new List<WorkDay>();
        public List<Record> Records { get; set; } = new List<Record>();
    }
}

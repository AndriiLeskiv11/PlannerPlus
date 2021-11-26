using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerPlus.Models
{
    public class Service : EntityBase
    {
        public string Name { get; set; }
        public TimeSpan Time { get; set; }
        public decimal Price { get; set; }

        public List<Master> Masters { get; set; } = new List<Master>();
        public List<Record> Records { get; set; } = new List<Record>();

    }
}

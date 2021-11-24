using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerPlus.Models
{
    public class Service
    {
        public string Name { get; set; }
        public TimeSpan Time { get; set; }
        public decimal Price { get; set; }

    }
}

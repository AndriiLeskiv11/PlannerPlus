using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerPlus.Models
{
    public class WorkDay : EntityBase
    {
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public int MasterId { get; set; }
        public Master Master { get; set; }
    }
}

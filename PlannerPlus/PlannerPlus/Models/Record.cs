using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerPlus.Models
{
    public class Record : EntityBase
    {
        public DateTime SeviceTime { get; set; }
        public int MasterId { get; set; }
        public Master Master { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerPlus.Dto
{
    public class RecordDto
    {
        public string ServiceName { get; set; }
        public DateTime DateOfRecord { get; set; }
        public string ClientName { get; set; }
        public int ClientId { get; set; }
        public int ServiceId { get; set; }
    }
}

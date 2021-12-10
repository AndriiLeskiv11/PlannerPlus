using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerPlus.Dto
{
    public class MasterScheduleDto
    {
        public string MasterName { get; set; }
        public List<RecordDto>  Records { get; set; }
        public int MasterId { get; set; }
    }
}

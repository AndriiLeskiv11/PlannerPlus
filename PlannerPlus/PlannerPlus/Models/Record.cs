﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerPlus.Models
{
    public enum RecordStatus
    {
        Pending,
        Completed,
        Declined
    }

    public class Record : EntityBase
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int MasterId { get; set; }
        public Master Master { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public RecordStatus Status { get; set; }
    }
}

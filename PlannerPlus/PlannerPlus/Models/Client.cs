using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerPlus.Models
{
    public class Client : EntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirthd { get; set; }
        public string PhoneNumber { get; set; }
        public List<Record> Records { get; set; } = new List<Record>();
    }
}

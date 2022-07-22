using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PORTPROJECTWEBAPI.Models
{
    public class UserClass
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public int Cost { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string UserType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace TimeChecker.Domain.Models
{
    public class TimeEntry : DomainObject
    {
        public int Type { get; set; }

        public Account Account { get; set; }

        public DateTime DateTime { get; set; }

        public string Comment { get; set; }
        
    }
    
}

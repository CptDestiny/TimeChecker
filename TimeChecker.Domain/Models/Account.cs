using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeChecker.Domain.Models
{
    public class Account : DomainObject
    {

        public User AccountUser { get; set; }
        
        public bool isCheckedIn { get; set; }


    }
}

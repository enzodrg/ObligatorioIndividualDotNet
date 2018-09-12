using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    [DataContract]
    public class FullTimeEmployee : Employee
    {
        [DataMember(Name = "Salary")]
        public int Salary { get; set; }
    }
}

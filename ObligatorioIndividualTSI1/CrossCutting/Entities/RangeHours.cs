using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    [DataContract]
    public class RangeHours
    {
        [DataMember(Name = "Hours")]
        public int Hours;
        [DataMember(Name = "StartDate")]
        public DateTime StartDate;
        [DataMember(Name = "EmployeeId")]
        public int EmployeeId;

        public RangeHours( int eId, int h, DateTime sD) {
            Hours = h;
            StartDate = sD;
            EmployeeId = eId;
        }
    }
}

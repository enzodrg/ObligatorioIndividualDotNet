using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
     public class RangeHours
    {
        public int Hours;
        public DateTime StartDate;
        public int EmployeeId;

        public RangeHours( int eId, int h, DateTime sD) {
            Hours = h;
            StartDate = sD;
            EmployeeId = eId;
        }
    }
}

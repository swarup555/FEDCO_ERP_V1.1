using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSSINESS_ENTITIES
{
    public class EmployeeHobbiesEntity
    {
        public decimal ID { get; set; }
        public string HOBBIES { get; set; }
        public Nullable<decimal> EMPLOYEEID { get; set; }
    }
}

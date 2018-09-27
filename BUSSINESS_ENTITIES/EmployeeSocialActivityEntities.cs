using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSSINESS_ENTITIES
{
    public class EmployeeSocialActivityEntities
    {
        public decimal ID { get; set; }
        public Nullable<decimal> EMPLOYEEID { get; set; }
        public string ACTIVITYDATE { get; set; }
        public string ACTIVITYDETAILS { get; set; }
        public string COMMENTS { get; set; }
    }
}

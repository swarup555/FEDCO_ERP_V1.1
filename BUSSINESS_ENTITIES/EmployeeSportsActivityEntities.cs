using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSSINESS_ENTITIES
{
    public class EmployeeSportsActivityEntities
    {
        public decimal ID { get; set; }
        public Nullable<decimal> EMPLOYEEID { get; set; }
        public string PARTICIPATIONDATE { get; set; }
        public string SPORTSDETAIL { get; set; }
        public string OCCASION { get; set; }
        public string COMMENTS { get; set; }
    }
}

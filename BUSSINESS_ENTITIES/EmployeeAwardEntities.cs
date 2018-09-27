using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSSINESS_ENTITIES
{
    public class EmployeeAwardEntities
    {
        public decimal ID { get; set; }
        public Nullable<decimal> EMPLOYEEID { get; set; }
        public string ACHIEVEMENTDATE { get; set; }
        public string AWARDSDETAIL { get; set; }
        public string COMMENTS { get; set; }
    }
}

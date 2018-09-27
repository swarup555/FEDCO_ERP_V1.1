using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSSINESS_ENTITIES
{
    public class UserEntities
    {
        public decimal USERID { get; set; }
        public string USERNAME { get; set; }
        public string USERPASSWORD { get; set; }
        public string SECURITYQUESTION { get; set; }
        public string ANSWER { get; set; }
        public decimal GROUPID { get; set; }
        public Nullable<decimal> EMPID { get; set; }
    }
}

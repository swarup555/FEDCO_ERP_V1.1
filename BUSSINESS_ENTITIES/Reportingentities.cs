using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSSINESS_ENTITIES
{
    public class Reportingentities
    {
        public decimal ID { get; set; }
        public Nullable<decimal> DEPARTMENT_ID { get; set; }
        public Nullable<decimal> EMPLOYEE_ID { get; set; }
        public string REPORTING_PERSON_NAME { get; set; }
        public string CREATEDBY { get; set; }
        public string MODIFIEDBY { get; set; }
        public Nullable<System.DateTime> CREATEDDATETIME { get; set; }
        public Nullable<System.DateTime> MODIFIEDDATETIME { get; set; }
        public string ISDELETED { get; set; }
        public string DELETEDBY { get; set; }
        public Nullable<System.DateTime> DELETEDDATETIME { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSSINESS_ENTITIES
{
    public class EmploymentEntities
    {
        public decimal ID { get; set; }
        public Nullable<decimal> EMPLOYEE_ID { get; set; }
        public string ORGANISATION_NAME { get; set; }
        public Nullable<System.DateTime> JOINING_DATE { get; set; }
        public Nullable<System.DateTime> RELIEVING_DATE { get; set; }
        public string LAST_DESIGNATION { get; set; }
        public string JOINING_EMOLUMENTS { get; set; }
        public string LEAVING_EMOLUMENTS { get; set; }
        public string REASON_FOR_LEAVING { get; set; }
        public string CREATED_BY { get; set; }
        public string MODIFIED_BY { get; set; }
        public Nullable<System.DateTime> CREATED_DATETIME { get; set; }
        public Nullable<System.DateTime> MODIFIED_DATETIME { get; set; }
        public string ISDELETED { get; set; }
        public string DELETEDBY { get; set; }
        public Nullable<System.DateTime> DELETEDDATETIME { get; set; }
        public string JOININGDATE { get; set; }
        public string RELIEVINGDATE { get; set; }
    }
}

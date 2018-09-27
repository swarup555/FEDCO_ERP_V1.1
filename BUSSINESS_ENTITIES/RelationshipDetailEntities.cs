using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSSINESS_ENTITIES
{
    public class RelationshipDetailEntities
    {
        public decimal ID { get; set; }
        public Nullable<decimal> EMPLOYEE_ID { get; set; }
        public string RELATIONSHIP { get; set; }
        public string RELATIVE_NAME { get; set; }
        public Nullable<System.DateTime> DATE_OF_BIRTH { get; set; }
        public string OCCUPATION { get; set; }
        public string DEPENDENT { get; set; }
        public string CREATED_BY { get; set; }
        public string MODIFIED_BY { get; set; }
        public Nullable<System.DateTime> CREATED_DATETIME { get; set; }
        public Nullable<System.DateTime> MODIFIED_DATETIME { get; set; }
        public string ISDELETED { get; set; }
        public string DELETEDBY { get; set; }
        public Nullable<System.DateTime> DELETEDDATETIME { get; set; }
        public string DATEOFBIRTH { get; set; }
    }
}

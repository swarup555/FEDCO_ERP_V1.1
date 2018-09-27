using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSSINESS_ENTITIES
{
    public class TransferdetailsEntities
    {
        public decimal ID { get; set; }
        public Nullable<decimal> EMPLOYEE_ID { get; set; }
        public Nullable<decimal> DESIGNATION_ID { get; set; }
        public Nullable<System.DateTime> FROM_DATE { get; set; }
        public Nullable<System.DateTime> TO_DATE { get; set; }
        public string DIVISION { get; set; }
        public string SUB_DIVISION { get; set; }
        public string SECTION { get; set; }
        public string STATUS { get; set; }
        public string CREATED_BY { get; set; }
        public string MODIFIED_BY { get; set; }
        public Nullable<System.DateTime> CREATED_DATETIME { get; set; }
        public Nullable<System.DateTime> MODIFIED_DATETIME { get; set; }
        public string ISDELETED { get; set; }
        public string DELETEDBY { get; set; }
        public string DELETEDDATETIME { get; set; }
        public Nullable<decimal> REPORTING_PERSON { get; set; }
        public Nullable<decimal> DEPARTMENT { get; set; }
        public Nullable<decimal> WORK_LOCATION { get; set; }
        public string DIVISIONNAME { get; set; }
        public string SUB_DIVISIONNAME { get; set; }
        public string SECTIONNAME { get; set; }
        public string DESIGNATIONNAME { get; set; }
        public string DEPARTMENTNAME { get; set; }
        public string REPORTING_PERSONNAME { get; set; }
        public string SDATE { get; set; }
        public string EDATE { get; set; }
        public string WorkLocationname { get; set; }
    }
}

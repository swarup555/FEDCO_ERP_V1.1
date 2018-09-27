using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FEDCO_ERP_V1._1.Models
{
    public class Basicinfo
    {
        public decimal ID { get; set; }
        public string EMPLOYEE_CODE { get; set; }
        public Nullable<decimal> DESIGNATION { get; set; }
        public string EMPLOYEE_FIRSTNAME { get; set; }
        public string EMPLOYEE_MIDDLENAME { get; set; }
        public string EMPLOYEE_LASTNAME { get; set; }
        public Nullable<System.DateTime> DATE_OF_BIRTH { get; set; }
        public Nullable<decimal> AGE { get; set; }
        public string SEX { get; set; }
        public string DOMICILE_STATUS { get; set; }
        public string MATERIAL_STATUS { get; set; }
        public Nullable<System.DateTime> WEDDING_ANNIVERSARY { get; set; }
        public string REPORTING_TO { get; set; }
        public Nullable<decimal> GRADE { get; set; }
        public Nullable<decimal> BLOOD_GROUP { get; set; }
        public Nullable<decimal> HEIGHT { get; set; }
        public Nullable<decimal> WEIGHT { get; set; }
        public string MEDICLAIM_NUMBER { get; set; }
        public string ESIC_NO { get; set; }
        public string PF_UNID_NUMBER { get; set; }
        public string INDUCTION { get; set; }
        public string IDENTIFICATION_MARK { get; set; }
        public string LAST_MAJOR_ILLNESS_SURGERY { get; set; }
        public string ALLERGY_HISTORY { get; set; }
        public string PHYSICAL_DISABILITY { get; set; }
        public string HIRING_TYPE { get; set; }
        public string CV_TYPE { get; set; }
        public Nullable<decimal> YEAR_OF_EXPERIENCE { get; set; }
        public Nullable<System.DateTime> EXIT_DATE { get; set; }
        public Nullable<decimal> EXIT_TYPE { get; set; }
        public string REFERENCE { get; set; }
        public string FULL_N_FINAL_STATUS { get; set; }
        public string CREATED_BY { get; set; }
        public string MODIFIED_BY { get; set; }
        public Nullable<System.DateTime> CREATED_DATETIME { get; set; }
        public Nullable<System.DateTime> MODIFIED_DATETIME { get; set; }
        public string DIVISION { get; set; }
        public string SUBDIVISION { get; set; }
        public string SECTION { get; set; }
        public Nullable<decimal> DEPARTMENT { get; set; }
        public string EMPLOYEE_IMAGE { get; set; }
        public string ISDELETED { get; set; }
        public string DELETEDBY { get; set; }
        public Nullable<System.DateTime> DELETEDDATETIME { get; set; }
        public Nullable<System.DateTime> JOINING_DATE { get; set; }
    }
}
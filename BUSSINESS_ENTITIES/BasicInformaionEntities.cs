using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
namespace BUSSINESS_ENTITIES
{
    public class BasicInformaionEntities
    {
        public decimal ID { get; set; }
        public string EMPLOYEE_CODE { get; set; }
        public Nullable<decimal> DESIGNATION { get; set; }
        public string EMPLOYEE_FIRSTNAME { get; set; }
        public string EMPLOYEE_MIDDLENAME { get; set; }
        public string EMPLOYEE_LASTNAME { get; set; }
        public Nullable<System.DateTime> DATE_OF_BIRTH { get; set; }
        public string AGE { get; set; }
        public string SEX { get; set; }
        public string DOMICILE_STATUS { get; set; }
        public string MATERIAL_STATUS { get; set; }
        public Nullable<System.DateTime> WEDDING_ANNIVERSARY { get; set; }
        public string REPORTING_TO { get; set; }
        public Nullable<decimal> GRADE { get; set; }
        public Nullable<decimal> BLOOD_GROUP { get; set; }
        public string HEIGHT { get; set; }
        public string WEIGHT { get; set; }
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
        public string YEAR_OF_EXPERIENCE { get; set; }
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
        public string RELIGION { get; set; }
        public Nullable<decimal> WORKLOCATION { get; set; }
        public string MOTHERTOUNGE { get; set; }
        public string DIVISIONNAME { get; set; }
        public string SUB_DIVISIONNAME { get; set; }
        public string SECTIONNAME { get; set; }
        public string PHONE_NUMBER { get; set; }
        public string MOBILE_NUMBER { get; set; }
        public string EMERGENCY_CONTACT_NUMBER { get; set; }
        public string OFFICIAL_MOBILE_NUMBER { get; set; }
        public string OFFICIAL_EMAIL { get; set; }
        public string PERSONAL_EMAIL { get; set; }
        public string departmentname { get; set; }
        public string designationname { get; set; }
        public string EMPLOYEE_FULLNAME { get; set; }
        public string DOB { get; set; }
        public string WEDDING { get; set; }
        public string EXITDATE { get; set; }
        public string JOININGDATE { get; set; }
        public byte[] EMPIMG { get; set; }
        public string EMPIMAGE { get; set; }
        public Nullable<decimal> EXITCATAGORY { get; set; }
        public string STATUS { get; set; }
        public string gradename { get; set; }
        public string locationname { get; set; }
        public string Permanentaddress { get; set; }
        public string PERMANENT_ADDRESS { get; set; }
        public string MAILING_ADDRESS { get; set; }
        public string PERMANENT_ADDRESS_CITY { get; set; }
        public Nullable<decimal> PERMANENT_ADDRESS_STATE { get; set; }
        public Nullable<decimal> PERMANENT_ADDRESS_PIN { get; set; }
        public string MAILING_ADDRESS_CITY { get; set; }
        public Nullable<decimal> MAILING_ADDRESS_STATE { get; set; }
        public Nullable<decimal> MAILING_ADDRESS_PIN { get; set; }
        public string PASSPORT_NUMBER { get; set; }
        public Nullable<System.DateTime> PASSPORT_VALIDITY { get; set; }
        public string DRIVING_LICENCE_NUMBER { get; set; }
        public string PANCARD_NUMBER { get; set; }
        public string AADHAR_NUMBER { get; set; }
        public string RELATIONSHIP { get; set; }
        public string VALIDITY { get; set; }
        public string RESIGNATIONDATE { get; set; }
        public string LEAVEENCASHMENT { get; set; }
    }
}

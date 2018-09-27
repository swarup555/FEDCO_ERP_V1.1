using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSSINESS_ENTITIES
{
   public class CommunicationDetailsEntities
    {
        public decimal ID { get; set; }
        public Nullable<decimal> EMPLOYEE_ID { get; set; }
        public string PERMANENT_ADDRESS { get; set; }
        public string MAILING_ADDRESS { get; set; }
        public string PERMANENT_ADDRESS_CITY { get; set; }
        public Nullable<decimal> PERMANENT_ADDRESS_STATE { get; set; }
        public Nullable<decimal> PERMANENT_ADDRESS_PIN { get; set; }
        public string MAILING_ADDRESS_CITY { get; set; }
        public Nullable<decimal> MAILING_ADDRESS_STATE { get; set; }
        public Nullable<decimal> MAILING_ADDRESS_PIN { get; set; }
        public string PHONE_NUMBER { get; set; }
        public string MOBILE_NUMBER { get; set; }
        public string EMERGENCY_CONTACT_NUMBER { get; set; }
        public string PASSPORT_NUMBER { get; set; }
        public Nullable<System.DateTime> PASSPORT_VALIDITY { get; set; }
        public string DRIVING_LICENCE_NUMBER { get; set; }
        public string PANCARD_NUMBER { get; set; }
        public string AADHAR_NUMBER { get; set; }
        public string PERSONAL_EMAIL { get; set; }
        public string OFFICIAL_EMAIL { get; set; }
        public string OFFICIAL_MOBILE_NUMBER { get; set; }
        public string CREATED_BY { get; set; }
        public string MODIFIDE_BY { get; set; }
        public Nullable<System.DateTime> CREATED_DATETIME { get; set; }
        public Nullable<System.DateTime> MODIFIED_DATETIME { get; set; }
        public string ISDELETED { get; set; }
        public string DELETEDBY { get; set; }
        public Nullable<System.DateTime> DELETEDDATETIME { get; set; }
        public string RELATIONSHIP { get; set; }
        public string VALIDITY { get; set; }
       
    }
}

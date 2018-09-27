using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSSINESS_ENTITIES
{
    public class AssetDetailsEntities
    {
        public decimal ID { get; set; }
        public Nullable<decimal> EMPLOYEE_ID { get; set; }
        public string ASSET_NAME { get; set; }
        public string ASSET_CODE { get; set; }
        public Nullable<System.DateTime> ISSUED_DATE { get; set; }
        public Nullable<System.DateTime> RETURNED_DATE { get; set; }
        public string ISSUEDBY { get; set; }
        public string RETURNEDTO { get; set; }
        public string ASSET_STATUS { get; set; }
        public string CREATEDBY { get; set; }
        public Nullable<System.DateTime> CREATEDDATETIME { get; set; }
        public string MODIFIEDBY { get; set; }
        public Nullable<System.DateTime> MODIFIEDDATETIME { get; set; }
        public string ISDELETED { get; set; }
        public string ISSUEDDATE { get; set; }
        public string RETURNEDDATE { get; set; }
    }
}

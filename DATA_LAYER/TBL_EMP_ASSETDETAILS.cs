//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DATA_LAYER
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_EMP_ASSETDETAILS
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
    
        public virtual TBL_EMP_BASICINFO TBL_EMP_BASICINFO { get; set; }
    }
}

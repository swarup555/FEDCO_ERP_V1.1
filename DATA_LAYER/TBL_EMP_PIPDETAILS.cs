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
    
    public partial class TBL_EMP_PIPDETAILS
    {
        public decimal ID { get; set; }
        public Nullable<decimal> EMPLOYEE_ID { get; set; }
        public Nullable<System.DateTime> PIP_DATE { get; set; }
        public string REASON { get; set; }
        public Nullable<decimal> PERIOD { get; set; }
        public string PIPCREATEDBY { get; set; }
        public string PIPCLOSEDBY { get; set; }
        public Nullable<System.DateTime> PIPCLOSEDDATE { get; set; }
        public string REMARKS { get; set; }
        public string CREATEDBY { get; set; }
        public Nullable<System.DateTime> CREATEDDATETIME { get; set; }
        public string MODIFIEDBY { get; set; }
        public string MODIFIEDDATETIME { get; set; }
        public string ISDELETED { get; set; }
    
        public virtual TBL_EMP_BASICINFO TBL_EMP_BASICINFO { get; set; }
    }
}

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
    
    public partial class TBL_EMP_TRAINING_DETAILS
    {
        public decimal ID { get; set; }
        public Nullable<decimal> EMPLOYEE_ID { get; set; }
        public string TRANING_DETAILS { get; set; }
        public string TRAINING_NAME { get; set; }
        public Nullable<System.DateTime> STARTING_DATE { get; set; }
        public Nullable<System.DateTime> COMPLETED_DATE { get; set; }
        public string GUIDEDBY { get; set; }
        public string REMARKS { get; set; }
        public string CREATEDBY { get; set; }
        public Nullable<System.DateTime> CRETEDDATETIME { get; set; }
        public string MODIFIEDBY { get; set; }
        public Nullable<System.DateTime> MODIFIEDDATETIME { get; set; }
    
        public virtual TBL_EMP_BASICINFO TBL_EMP_BASICINFO { get; set; }
    }
}

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
    
    public partial class TBL_HRMS_GRADE_MASTER
    {
        public TBL_HRMS_GRADE_MASTER()
        {
            this.TBL_EMP_BASICINFO = new HashSet<TBL_EMP_BASICINFO>();
            this.TBL_EMP_BASICINFO_HISTORY = new HashSet<TBL_EMP_BASICINFO_HISTORY>();
            this.TBL_EMP_TRANSFER_DETAILS = new HashSet<TBL_EMP_TRANSFER_DETAILS>();
        }
    
        public decimal ID { get; set; }
        public string GRADE_NAME { get; set; }
        public string CREATED_BY { get; set; }
        public string MODIFIED_BY { get; set; }
        public Nullable<System.DateTime> CREATED_DATETIME { get; set; }
        public Nullable<System.DateTime> MODIFIED_DATETIME { get; set; }
        public string ISDELETED { get; set; }
        public string DELETEDBY { get; set; }
        public Nullable<System.DateTime> DELETEDDATETIME { get; set; }
    
        public virtual ICollection<TBL_EMP_BASICINFO> TBL_EMP_BASICINFO { get; set; }
        public virtual ICollection<TBL_EMP_BASICINFO_HISTORY> TBL_EMP_BASICINFO_HISTORY { get; set; }
        public virtual ICollection<TBL_EMP_TRANSFER_DETAILS> TBL_EMP_TRANSFER_DETAILS { get; set; }
    }
}

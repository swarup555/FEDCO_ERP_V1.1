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
    
    public partial class TBL_HRMS_EXITTYPE_MASTER
    {
        public TBL_HRMS_EXITTYPE_MASTER()
        {
            this.TBL_EMP_BASICINFO = new HashSet<TBL_EMP_BASICINFO>();
            this.TBL_EMP_BASICINFO_HISTORY = new HashSet<TBL_EMP_BASICINFO_HISTORY>();
        }
    
        public decimal ID { get; set; }
        public string EXITTYPE_NAME { get; set; }
    
        public virtual ICollection<TBL_EMP_BASICINFO> TBL_EMP_BASICINFO { get; set; }
        public virtual ICollection<TBL_EMP_BASICINFO_HISTORY> TBL_EMP_BASICINFO_HISTORY { get; set; }
    }
}

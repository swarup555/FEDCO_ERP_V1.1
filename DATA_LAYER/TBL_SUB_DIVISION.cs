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
    
    public partial class TBL_SUB_DIVISION
    {
        public TBL_SUB_DIVISION()
        {
            this.TBL_SECTION = new HashSet<TBL_SECTION>();
        }
    
        public string DIVISION_CODE { get; set; }
        public string SUB_DIV_CODE { get; set; }
        public string SUB_DIV_NAME { get; set; }
        public string DISPLAY_CODE { get; set; }
        public string UTILITY_NAME { get; set; }
    
        public virtual TBL_DIVISION TBL_DIVISION { get; set; }
        public virtual ICollection<TBL_SECTION> TBL_SECTION { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSSINESS_ENTITIES
{
    public class PIPDeatilsEntities
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
        public string CREATEDATE { get; set; }
        public string CLOSEDATE { get; set; }
    }
}

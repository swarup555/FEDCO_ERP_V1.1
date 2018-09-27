using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSSINESS_ENTITIES
{
    public class ExtraCurricullarActivityEntity
    {
        public decimal ID { get; set; }
        public Nullable<decimal> EMPLOYEE_ID { get; set; }
        public string HOBBIES { get; set; }
        public string SPORTS { get; set; }
        public string CULTURAL { get; set; }
        public string CREATEDBY { get; set; }
        public Nullable<System.DateTime> CREATEDDATETIME { get; set; }
        public string MODIFIEDBY { get; set; }
        public Nullable<System.DateTime> MODIFIEDDATETIME { get; set; }
    }
}

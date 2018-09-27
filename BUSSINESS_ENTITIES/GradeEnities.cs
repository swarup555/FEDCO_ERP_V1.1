using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSSINESS_ENTITIES
{
    public class GradeEnities
    {
        public decimal ID { get; set; }
        public string GRADE_NAME { get; set; }
        public string CREATED_BY { get; set; }
        public string MODIFIED_BY { get; set; }
        public Nullable<System.DateTime> CREATED_DATETIME { get; set; }
        public Nullable<System.DateTime> MODIFIED_DATETIME { get; set; }
        public string ISDELETED { get; set; }
        public string DELETEDBY { get; set; }
        public Nullable<System.DateTime> DELETEDDATETIME { get; set; }
    }
}

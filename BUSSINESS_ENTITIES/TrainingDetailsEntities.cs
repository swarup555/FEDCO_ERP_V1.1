using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSSINESS_ENTITIES
{
    public class TrainingDetailsEntities
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
    }
}

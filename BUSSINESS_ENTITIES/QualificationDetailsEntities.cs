using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSSINESS_ENTITIES
{
    public class QualificationDetailsEntities
    {
        public decimal ID { get; set; }
        public Nullable<decimal> EMPLOYEE_ID { get; set; }
        public string TYPE { get; set; }
        public Nullable<System.DateTime> START_DATE { get; set; }
        public Nullable<System.DateTime> END_DATE { get; set; }
        public string SUBJECT { get; set; }
        public string TOTAL_MARKS { get; set; }
        public string MARKS_SECURED { get; set; }
        public string PERCENTAGE_OF_MARK_DIVISION { get; set; }
        public string CREATED_BY { get; set; }
        public string MODIFIED_BY { get; set; }
        public Nullable<System.DateTime> CREATED_DATETIME { get; set; }
        public Nullable<System.DateTime> MODIFIED_DATETIME { get; set; }
        public string ISDELETED { get; set; }
        public string DELETEDBY { get; set; }
        public Nullable<System.DateTime> DELETEDDATETIME { get; set; }
        public string EXAM_DEGREE_TYPE { get; set; }
        public string BOARD_UNIVERSITY_NAME { get; set; }
        public string SCHOOL_COLLEGE_NAME { get; set; }
        public string ENROLLEDDATE { get; set; }
        public string COMPLETEDDATE { get; set; }
    }
}

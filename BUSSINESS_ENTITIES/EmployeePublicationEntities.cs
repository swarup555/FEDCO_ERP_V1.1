using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSSINESS_ENTITIES
{
    public class EmployeePublicationEntities
    {
        public decimal ID { get; set; }
        public Nullable<decimal> EMPLOYEEID { get; set; }
        public string DATEOFPUBLICATION { get; set; }
        public string PUBLICATIONDETAILS { get; set; }
        public string COMMENTS { get; set; }
    }
}

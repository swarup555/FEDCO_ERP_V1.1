using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;

namespace BUSSINESS_SERVICE
{
    public interface IEmploymentDetails
    {
        IEnumerable<EmploymentEntities> GetEmploymentDetailsById(int EmploymentDetailsId); 
        IEnumerable<EmploymentEntities> GetAllEmploymentDetails();
        int CreateEmploymentDetails(EmploymentEntities EmploymentDetailsEntities);
        bool UpdateEmploymentDetails(int EmploymentDetailsId, EmploymentEntities EmploymentDetailsEntities);
        bool DeleteEmploymentDetails(int EmploymentDetailsId);
    }
}

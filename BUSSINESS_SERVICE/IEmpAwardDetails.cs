using BUSSINESS_ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSSINESS_SERVICE
{
    public interface IEmpAwardDetails
    {
        IEnumerable<EmployeeAwardEntities> GetEmployeeAwardById(int EmployeeAwardId);
        IEnumerable<EmployeeAwardEntities> GetAllEmployeeAwardDetails();
        int CreateEmployeeAwardDetails(EmployeeAwardEntities EmployeeAwardEntities);
        bool UpdateEmployeeAwardDetails(int EmployeeAwardId, EmployeeAwardEntities EmployeeAwardEntities);
        bool DeleteEmployeeAwardDetails(int EmployeeAwardId);
    }
}

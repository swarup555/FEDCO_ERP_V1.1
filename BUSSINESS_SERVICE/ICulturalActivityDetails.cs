using BUSSINESS_ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSSINESS_SERVICE
{
    public interface ICulturalActivityDetails
    {
        IEnumerable<EmployeeCulturalActivityEntities> GetEmployeeCulturalActivityById(int CulturalActivityId);
        IEnumerable<EmployeeCulturalActivityEntities> GetAllEmployeeCulturalActivityDetails();
        int CreateEmployeeCulturalActivityDetails(EmployeeCulturalActivityEntities CulturalActivityEntities);
        bool UpdateEmployeeCulturalActivityDetails(int CulturalActivityId, EmployeeCulturalActivityEntities CulturalActivityEntities);
        bool DeleteEmployeeCulturalActivityDetails(int CulturalActivityId);  
    }
}

using BUSSINESS_ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BUSSINESS_SERVICE
{
    public interface IEmpHobby
    {
        IEnumerable<EmployeeHobbiesEntity> GetEmployeeHobbiesById(int EmployeeHobbiesId);
        IEnumerable<EmployeeHobbiesEntity> GetAllEmployeeHobbiesDetails();
        int CreateEmployeeHobbiesDetails(EmployeeHobbiesEntity EmployeeHobbiesEntities);
        bool UpdateEmployeeHobbiesDetails(int EmployeeHobbiesId, EmployeeHobbiesEntity EmployeeHobbiesEntities);
        bool DeleteEmployeeHobbiesDetails(int EmployeeHobbiesId); 
    }
}

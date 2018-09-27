using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;

namespace BUSSINESS_SERVICE
{
    public interface IDepartment
    {
        IEnumerable<DepartmentEntities> GetDepartmentById(int DepartmentId);
        IEnumerable<DepartmentEntities> GetAllDepartment();
        int CreateDepartment(DepartmentEntities DepartmentEntities);
        bool UpdateDepartment(int DepartmentId, DepartmentEntities DepartmentEntities);
        bool DeleteDepartment(int DepartmentId);
    }
}

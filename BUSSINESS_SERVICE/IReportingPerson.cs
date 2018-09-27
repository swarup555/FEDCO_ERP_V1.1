using BUSSINESS_ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSSINESS_SERVICE
{
    public interface IReportingPerson
    {
        IEnumerable<Reportingentities> GetReportingPersonById(int ReportingPersonId);
        IEnumerable<Reportingentities> GetAllDepartment();
        int CreateReportingPerson(Reportingentities DepartmentEntities);
        bool UpdateReportingPerson(int DepartmentId, Reportingentities DepartmentEntities);
        bool DeleteReportingPerson(int DepartmentId); 
    }
}

using BUSSINESS_ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSSINESS_ENTITIES
{
    public interface Iempsportsdetails
    {
        IEnumerable<EmployeeSportsActivityEntities> GetSportsActivityById(int SportsActivityId);
        IEnumerable<EmployeeSportsActivityEntities> GetAllSportsActivityDetails();
        int CreateSportsActivityDetails(EmployeeSportsActivityEntities SportsActivityEntities);
        bool UpdateSportsActivityDetails(int SportsActivityId, EmployeeSportsActivityEntities SportsActivityEntities);
        bool DeleteSportsActivityDetails(int SportsActivityId); 
    }
}

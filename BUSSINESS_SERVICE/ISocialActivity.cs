using BUSSINESS_ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSSINESS_SERVICE
{
    public interface ISocialActivity
    {
        IEnumerable<EmployeeSocialActivityEntities> GetEmployeeSocialActivityById(int SocialActivityId);
        IEnumerable<EmployeeSocialActivityEntities> GetAllEmployeeSocialActivityDetails();
        int CreateEmployeeSocialActivityDetails(EmployeeSocialActivityEntities SocialActivityEntities);
        bool UpdateEmployeeSocialActivityDetails(int SocialActivityId, EmployeeSocialActivityEntities SocialActivityEntities);
        bool DeleteEmployeeSocialActivityDetails(int SocialActivityId);   
    }
}

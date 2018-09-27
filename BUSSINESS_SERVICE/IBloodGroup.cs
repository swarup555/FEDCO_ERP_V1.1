using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;
namespace BUSSINESS_SERVICE
{
   public  interface IBloodGroup
    {
       IEnumerable<BloodGroupEntities> GetBloodGroupById(int BasicinfoId);
       IEnumerable<BloodGroupEntities> GetAllBloodGroup();
       int CreateBloodGroup(BloodGroupEntities BloodGroupEntities);
       bool UpdateBloodGroup(int BasicinfoId, BloodGroupEntities BloodGroupEntities);
        bool DeleteEmployeebasicinfo(int BasicinfoId);
    }
}

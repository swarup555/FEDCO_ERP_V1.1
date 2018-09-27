using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;

namespace BUSSINESS_SERVICE
{
    public interface IBasicinformationEmployee
    {
        IEnumerable<BasicInformaionEntities> GetEmployeebasicinfoById(int BasicinfoId);
        IEnumerable<BasicInformaionEntities> GetAllEmployeeBasicinfo();
        int CreateEmployeebasicinfo(BasicInformaionEntities BasicinfoEntities);
        bool UpdateEmployeebasicinfo(int BasicinfoId, BasicInformaionEntities BasicinfoEntities);
        bool DeleteEmployeebasicinfo(int BasicinfoId);
    }
}

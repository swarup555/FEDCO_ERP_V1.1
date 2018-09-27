using BUSSINESS_ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSSINESS_SERVICE
{
    public interface IindivisualEmployee
    {
        IEnumerable<IndivisualEmployeeEntities> GetEmployeeById(int AssetDetailsId);
        IEnumerable<IndivisualEmployeeEntities> GetAllEmployeeDetails();
    }
}

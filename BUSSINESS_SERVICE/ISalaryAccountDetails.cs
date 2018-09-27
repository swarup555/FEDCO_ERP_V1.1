using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;

namespace BUSSINESS_SERVICE
{
    public interface ISalaryAccountDetails
    {
        IEnumerable<EmpAcountEntity> GetSalaryAccountDetailsById(int SalaryAccountDetailsId);
        IEnumerable<EmpAcountEntity> GetAllSalaryAccountDetails();
        int CreateSalaryAccountDetails(EmpAcountEntity SalaryAccountDetailsEntities);
        bool UpdateSalaryAccountDetails(int SalaryAccountDetailsId, EmpAcountEntity SalaryAccountDetailsEntities);
        bool DeleteSalaryAccountDetails(int SalaryAccountDetailsId);
    }
}

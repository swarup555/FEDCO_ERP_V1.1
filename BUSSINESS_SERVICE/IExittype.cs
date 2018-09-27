using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;

namespace BUSSINESS_SERVICE
{
    public interface IExittype
    {
        IEnumerable<ExitTypeEntities> GetExittypeById(int ExittypeId);
        IEnumerable<ExitTypeEntities> GetAllExittype();
        int CreateExittype(ExitTypeEntities ExittypeEntities);
        bool UpdateExittype(int ExittypeId, ExitTypeEntities ExittypeEntities);
        bool DeleteExittype(int ExittypeId); 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;

namespace BUSSINESS_SERVICE 
{
    public interface Idivision
    {
        IEnumerable<DIVISION> GetDIVISIONById(int DIVISIONId);
        IEnumerable<DIVISION> GetAllDIVISION();
        int CreateDIVISION(DIVISION DIVISIONEntities);
        bool UpdateDIVISION(int DIVISIONId, DIVISION DIVISIONEntities);
        bool DeleteDIVISION(int DIVISIONId); 
    }
}

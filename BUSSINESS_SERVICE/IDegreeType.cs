using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;

namespace BUSSINESS_SERVICE
{
    public interface IDegreeType
    {
        IEnumerable<DegreeTypeEntities> GetDegreeTypeById(int DegreeTypeId);
        IEnumerable<DegreeTypeEntities> GetAllDegreeType();
        int CreateDegreeType(DegreeTypeEntities DegreeTypeEntities);
        bool UpdateDegreeType(int DegreeTypeId, DegreeTypeEntities DegreeTypeEntities);
        bool DeleteDegreeType(int DegreeTypeId);
    }
}

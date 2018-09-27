using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;

namespace BUSSINESS_SERVICE
{
    public interface IGrade
    {
        IEnumerable<GradeEnities> GetGradeById(int GradeId);
        IEnumerable<GradeEnities> GetAllGrade();
        int CreateGrade(GradeEnities GradeEntities);
        bool UpdateGrade(int GradeId, GradeEnities GradeEntities);
        bool DeleteGrade(int GradeId); 
    }
}

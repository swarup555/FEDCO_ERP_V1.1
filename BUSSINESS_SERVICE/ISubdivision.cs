using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;

namespace BUSSINESS_SERVICE
{
    public interface ISubdivision
    {
        IEnumerable<SubDivisionEntities> GetSubDivisionById(string SubDivisionId);
        IEnumerable<SubDivisionEntities> GetAllSubDivision();
        int CreateSubDivision(SubDivisionEntities SubDivisionEntities);
        bool UpdateSubDivision(int SubDivisionId, SubDivisionEntities SubDivisionEntities); 
        bool DeleteSubDivision(int SubDivisionId);
    }
}

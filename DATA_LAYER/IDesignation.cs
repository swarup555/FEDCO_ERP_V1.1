using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;

namespace DATA_LAYER
{
    public interface IDesignation
    {
        IEnumerable<DesignationEntities> GetDesignationById(int DesignationId);
        IEnumerable<DesignationEntities> GetAllDesignation();
        int CreateDesignation(DesignationEntities DesignationEntities);
        bool UpdateDesignation(int DesignationId, DesignationEntities DesignationEntities);
        bool DeleteDesignation(int DesignationId); 
    }
}

using BUSSINESS_ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSSINESS_SERVICE
{
    public interface ILocation
    {
        IEnumerable<LocationEntities> GetLocationById(int LocationId);
        IEnumerable<LocationEntities> GetAllLocationDetails();
        int CreateLocation(LocationEntities LocationEntities);
        bool UpdateLocation(int LocationId, LocationEntities LocationEntities);
        bool DeleteLocation(int LocationId);
    }
}

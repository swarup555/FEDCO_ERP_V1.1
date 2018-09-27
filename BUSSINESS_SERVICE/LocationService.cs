using DATA_LAYER.HRMSOUW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;

namespace BUSSINESS_SERVICE
{
    public class LocationService:ILocation
    {
        private readonly UOW _UOW;

        public LocationService()
        {
            _UOW = new UOW();
        }
        public IEnumerable<LocationEntities> GetLocationById(int LocationId)
        {
            var Locationdata = (from loc in _UOW.LOCATIONMASTERRepository.GetAll()
                                where loc.ID==LocationId
                                select new LocationEntities
                                {
                                    ID = loc.ID,
                                    LOCATION_NAME = loc.LOCATION_NAME
                                }).ToList();
            return Locationdata;
        }

        public IEnumerable<LocationEntities> GetAllLocationDetails()
        {
            var Locationdata = (from loc in _UOW.LOCATIONMASTERRepository.GetAll()
                                select new LocationEntities
                                {
                                    ID = loc.ID,
                                    LOCATION_NAME = loc.LOCATION_NAME
                                }).ToList();
            return Locationdata;
        }

        public int CreateLocation(LocationEntities LocationEntities)
        {
            throw new NotImplementedException();
        }

        public bool UpdateLocation(int LocationId, LocationEntities LocationEntities)
        {
            throw new NotImplementedException();
        }

        public bool DeleteLocation(int LocationId)
        {
            throw new NotImplementedException();
        }
    }
}

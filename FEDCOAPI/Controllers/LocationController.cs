using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BUSSINESS_SERVICE;
using BUSSINESS_ENTITIES;

namespace FEDCOAPI.Controllers
{
    public class LocationController : ApiController
    {
        private readonly ILocation _LocationDetails;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
        public LocationController()
        {
            _LocationDetails = new LocationService();
        }
        #endregion
        // GET api/location
        public HttpResponseMessage Get()
        {
            var LocationDetails = _LocationDetails.GetAllLocationDetails();
            if (LocationDetails != null)
            {
                var LocationDetailsEntities = LocationDetails as List<LocationEntities> ?? LocationDetails.ToList();
                if (LocationDetailsEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, LocationDetailsEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "LocationDetails not found");
        }
        // GET api/location/5
        public HttpResponseMessage Get(int id)
        {
            var LocationDetails = _LocationDetails.GetLocationById(id);
            if (LocationDetails != null)
                return Request.CreateResponse(HttpStatusCode.OK, LocationDetails);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No LocationDetails found for this id");
        }

        // POST api/location
        public void Post([FromBody]string value)
        {
        }

        // PUT api/location/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/location/5
        public void Delete(int id)
        {
        }
    }
}

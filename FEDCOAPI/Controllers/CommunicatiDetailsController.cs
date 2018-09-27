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
    public class CommunicatiDetailsController : ApiController
    {
        private readonly ICommunicationDetails _CommunicationDetails;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
        public CommunicatiDetailsController()
        {
            _CommunicationDetails = new Communication_DetailsService();
        }
        #endregion
        // GET api/communicatidetails
        public HttpResponseMessage Get()
        {
            var CommunicationDetails = _CommunicationDetails.GetAllCommunicationDetails();
            if (CommunicationDetails != null)
            {
                var CommunicationDetailsEntities = CommunicationDetails as List<CommunicationDetailsEntities> ?? CommunicationDetails.ToList();
                if (CommunicationDetailsEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, CommunicationDetailsEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "CommunicationDetails not found");
        }

        // GET api/communicatidetails/5
        public HttpResponseMessage Get(int id)
        {
            var CommunicationDetails = _CommunicationDetails.GetCommunicationDetailsById(id);
            if (CommunicationDetails != null)
                return Request.CreateResponse(HttpStatusCode.OK, CommunicationDetails);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No CommunicationDetails found for this id");
        }

        // POST api/communicatidetails
        public int Post([FromBody] CommunicationDetailsEntities item)
        {
            return _CommunicationDetails.CreateCommunicationDetails(item);
        }

        // PUT api/communicatidetails/5
        public bool Put(int id, [FromBody]CommunicationDetailsEntities item)
        {
            if (id > 0)
            {
                return _CommunicationDetails.UpdateCommunicationDetails(id, item);
            }
            return false;
        }

        // DELETE api/communicatidetails/5
        public void Delete(int id)
        {
        }
    }
}

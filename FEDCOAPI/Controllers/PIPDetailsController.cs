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
    public class PIPDetailsController : ApiController
    {
        private readonly IPIPDetails _PIPDetails;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
        public PIPDetailsController()
        {
            _PIPDetails = new PIPDetailsService();
        }
        #endregion
        // GET api/pipdetails
        public HttpResponseMessage Get()
        {
            var PIPDetails = _PIPDetails.GetAllPIPDetails();
            if (PIPDetails != null)
            {
                var PIPDetailsEntities = PIPDetails as List<PIPDeatilsEntities> ?? PIPDetails.ToList();
                if (PIPDetailsEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, PIPDetailsEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "PIPDetails not found");
        }

        // GET api/pipdetails/5
        public HttpResponseMessage Get(int id)
        {
            var PIPDetails = _PIPDetails.GetPIPDetailsById(id);
            if (PIPDetails != null)
                return Request.CreateResponse(HttpStatusCode.OK, PIPDetails);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No PIPDetails found for this id");
        }

        // POST api/pipdetails
        public int Post([FromBody] PIPDeatilsEntities item)
        {
            return _PIPDetails.CreatePIPDetails(item);
        }

        // PUT api/pipdetails/5
        public bool Put(int id, [FromBody]PIPDeatilsEntities item)
        {
            if (id > 0)
            {
                return _PIPDetails.UpdatePIPDetails(id, item);
            }
            return false;
        }

        // DELETE api/pipdetails/5
        public void Delete(int id)
        {
        }
    }
}

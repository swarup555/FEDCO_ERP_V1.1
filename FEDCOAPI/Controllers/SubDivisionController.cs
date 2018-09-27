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
    public class SubDivisionController : ApiController
    {
         private readonly ISubdivision _subdivision; 

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
         public SubDivisionController()
        {
            _subdivision = new SubDivisionService();
        }
        #endregion
        // GET api/subdivision
         public HttpResponseMessage Get()
         {
             var subdivision = _subdivision.GetAllSubDivision();
             if (subdivision != null)
             {
                 var subdivisionEntities = subdivision as List<SubDivisionEntities> ?? subdivision.ToList();
                 if (subdivisionEntities.Any())
                     return Request.CreateResponse(HttpStatusCode.OK, subdivisionEntities);
             }
             return Request.CreateErrorResponse(HttpStatusCode.NotFound, "subdivision not found");
         }

        // GET api/subdivision/5
         public HttpResponseMessage Get(string id)
         {
             var subdivision = _subdivision.GetSubDivisionById(id);
             if (subdivision != null)
                 return Request.CreateResponse(HttpStatusCode.OK, subdivision);
             return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No subdivision found for this id");
         }


        // POST api/subdivision
        public void Post([FromBody]string value)
        {
        }

        // PUT api/subdivision/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/subdivision/5
        public void Delete(int id)
        {
        }
    }
}

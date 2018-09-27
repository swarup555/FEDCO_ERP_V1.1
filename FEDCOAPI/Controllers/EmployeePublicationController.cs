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
    public class EmployeePublicationController : ApiController
    {
        private readonly Iemppublicationdetails _publicationdetails;

      
        public EmployeePublicationController()
        {
            _publicationdetails = new EmployeePublicationService();
        }
        // GET api/employeepublication
        public HttpResponseMessage Get()
        {
            var publicationdetails = _publicationdetails.GetAllpublicationdetailsDetails();
            if (publicationdetails != null)
            {
                var EmployeePublicationEntities = publicationdetails as List<EmployeePublicationEntities> ?? publicationdetails.ToList();
                if (EmployeePublicationEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, EmployeePublicationEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "publicationdetails not found");
        }

        // GET api/employeepublication/5
        public HttpResponseMessage Get(int id)
        {
            var publicationdetails = _publicationdetails.GetpublicationdetailsById(id);
            if (publicationdetails != null)
                return Request.CreateResponse(HttpStatusCode.OK, publicationdetails);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No publicationdetails found for this id");
        }

        // POST api/employeepublication
        public int Post([FromBody] EmployeePublicationEntities item)
        {
            return _publicationdetails.CreatepublicationdetailsDetails(item);
        }
        // PUT api/employeepublication/5
        public bool Put(int id, [FromBody]EmployeePublicationEntities item)
        {
            if (id > 0)
            {
                return _publicationdetails.UpdatepublicationdetailsDetails(id, item);
            }
            return false;
        }

        // DELETE api/employeepublication/5
        public void Delete(int id)
        {
        }
    }
}

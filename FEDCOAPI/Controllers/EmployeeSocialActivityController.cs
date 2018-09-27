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
    public class EmployeeSocialActivityController : ApiController
    {
        private readonly ISocialActivity _SocialActivityDetails;


        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
        public EmployeeSocialActivityController()
        {
            _SocialActivityDetails = new EmployeeSocialActivityService();
        }
        // GET api/employeesocialactivity
        public HttpResponseMessage Get()
        {
            var SocialActivityDetails = _SocialActivityDetails.GetAllEmployeeSocialActivityDetails();
            if (SocialActivityDetails != null)
            {
                var EmployeeSocialActivityEntities = SocialActivityDetails as List<EmployeeSocialActivityEntities> ?? SocialActivityDetails.ToList();
                if (EmployeeSocialActivityEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, EmployeeSocialActivityEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "SocialActivityDetails not found");
        }

        // GET api/employeesocialactivity/5
        public HttpResponseMessage Get(int id)
        {
            var SocialActivityDetails = _SocialActivityDetails.GetEmployeeSocialActivityById(id);
            if (SocialActivityDetails != null)
                return Request.CreateResponse(HttpStatusCode.OK, SocialActivityDetails);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No SocialActivityDetails found for this id");
        }

        // POST api/employeesocialactivity
        public int Post([FromBody] EmployeeSocialActivityEntities item)
        {
            return _SocialActivityDetails.CreateEmployeeSocialActivityDetails(item);
        }

        // PUT api/employeesocialactivity/5
        public bool Put(int id, [FromBody] EmployeeSocialActivityEntities item)
        {
            if (id > 0)
            {
                return _SocialActivityDetails.UpdateEmployeeSocialActivityDetails(id, item);
            }
            return false;
        }

        // DELETE api/employeesocialactivity/5
        public void Delete(int id)
        {
        }
    }
}

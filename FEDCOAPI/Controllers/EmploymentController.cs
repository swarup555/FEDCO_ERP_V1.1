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
    public class EmploymentController : ApiController
    {
        private readonly IEmploymentDetails _EmploymentDetails;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
        public EmploymentController()
        {
            _EmploymentDetails = new EmploymentService();
        }
        #endregion
        // GET api/employment
        public HttpResponseMessage Get()
        {
            var EmploymentDetails = _EmploymentDetails.GetAllEmploymentDetails();
            if (EmploymentDetails != null)
            {
                var EmploymentDetailsEntities = EmploymentDetails as List<EmploymentEntities> ?? EmploymentDetails.ToList();
                if (EmploymentDetailsEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, EmploymentDetailsEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employment Details not found");
        }

        // GET api/employment/5
        public HttpResponseMessage Get(int id)
        {
            var EmploymentDetails = _EmploymentDetails.GetEmploymentDetailsById(id);
            if (EmploymentDetails != null)
                return Request.CreateResponse(HttpStatusCode.OK, EmploymentDetails);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Employment Details found for this id");
        }

        // POST api/employment
        public int Post([FromBody] EmploymentEntities item)
        {
            return _EmploymentDetails.CreateEmploymentDetails(item);
        }

        // PUT api/employment/5
        public bool Put(int id, [FromBody]EmploymentEntities item)
        {
            if (id > 0)
            {
                return _EmploymentDetails.UpdateEmploymentDetails(id, item);
            }
            return false;
        }

        // DELETE api/employment/5
        public void Delete(int id)
        {
        }
    }
}

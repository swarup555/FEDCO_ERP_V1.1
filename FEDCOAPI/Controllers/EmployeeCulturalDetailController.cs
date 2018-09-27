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
    public class EmployeeCulturalDetailController : ApiController
    {
        private readonly ICulturalActivityDetails _CulturalActivityDetails;

      
        public EmployeeCulturalDetailController()
        {
            _CulturalActivityDetails = new EmployeeCulturalActivityService();
        }
        // GET api/employeeculturaldetail
        public HttpResponseMessage Get()
        {
            var CulturalActivityDetails = _CulturalActivityDetails.GetAllEmployeeCulturalActivityDetails();
            if (CulturalActivityDetails != null)
            {
                var EmployeeCulturalActivityEntities = CulturalActivityDetails as List<EmployeeCulturalActivityEntities> ?? CulturalActivityDetails.ToList();
                if (EmployeeCulturalActivityEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, EmployeeCulturalActivityEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "CulturalActivityDetails not found");
        }

        // GET api/employeeculturaldetail/5
        public HttpResponseMessage Get(int id)
        {
            var CulturalActivityDetails = _CulturalActivityDetails.GetEmployeeCulturalActivityById(id);
            if (CulturalActivityDetails != null)
                return Request.CreateResponse(HttpStatusCode.OK, CulturalActivityDetails);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No CulturalActivityDetails found for this id");
        }

        // POST api/employeeculturaldetail
        public int Post([FromBody] EmployeeCulturalActivityEntities item)
        {
            return _CulturalActivityDetails.CreateEmployeeCulturalActivityDetails(item);
        }

        // PUT api/employeeculturaldetail/5
        public bool Put(int id, [FromBody] EmployeeCulturalActivityEntities item)
        {
            if (id > 0)
            {
                return _CulturalActivityDetails.UpdateEmployeeCulturalActivityDetails(id, item);
            }
            return false;
        }

        // DELETE api/employeeculturaldetail/5
        public void Delete(int id)
        {
        }
    }
}

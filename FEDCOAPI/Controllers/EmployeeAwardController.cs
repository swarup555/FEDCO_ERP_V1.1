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
    public class EmployeeAwardController : ApiController
    {
        private readonly IEmpAwardDetails _EmpAwardDetails;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
        public EmployeeAwardController()
        {
            _EmpAwardDetails = new EmployeeAwardDetailsService();
        }
        #endregion
        // GET api/employeeaward
        public HttpResponseMessage Get()
        {
            var AwardDetails = _EmpAwardDetails.GetAllEmployeeAwardDetails();
            if (AwardDetails != null)
            {
                var EmployeeAwardEntities = AwardDetails as List<EmployeeAwardEntities> ?? AwardDetails.ToList();
                if (EmployeeAwardEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, EmployeeAwardEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "AwardDetails not found");
        }

        // GET api/employeeaward/5
        public HttpResponseMessage Get(int id)
        {
            var AwardDetails = _EmpAwardDetails.GetEmployeeAwardById(id);
            if (AwardDetails != null)
                return Request.CreateResponse(HttpStatusCode.OK, AwardDetails);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No AwardDetails found for this id");
        }


        // POST api/employeeaward
        public int Post([FromBody] EmployeeAwardEntities item)
        {
            return _EmpAwardDetails.CreateEmployeeAwardDetails(item);
        }

        // PUT api/employeeaward/5
        public bool Put(int id, [FromBody]EmployeeAwardEntities item)
        {
            if (id > 0)
            {
                return _EmpAwardDetails.UpdateEmployeeAwardDetails(id, item);
            }
            return false;
        }

        // DELETE api/employeeaward/5
        public void Delete(int id)
        {
        }
    }
}

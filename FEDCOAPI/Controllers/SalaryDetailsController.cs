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
    public class SalaryDetailsController : ApiController
    {
        private readonly ISalaryAccountDetails _SalaryAccountDetails;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
        public SalaryDetailsController()
        {
            _SalaryAccountDetails = new SalaryAccountDetailService();
        }
        #endregion
        // GET api/salarydetails
        public HttpResponseMessage Get()
        {
            var salaryinfo = _SalaryAccountDetails.GetAllSalaryAccountDetails();
            if (salaryinfo != null)
            {
                var salaryinfoEntities = salaryinfo as List<EmpAcountEntity> ?? salaryinfo.ToList();
                if (salaryinfoEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, salaryinfoEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "salaryinfo not found");
        }

        // GET api/salarydetails/5
        public HttpResponseMessage Get(int id)
        {
            var salaryinfo = _SalaryAccountDetails.GetSalaryAccountDetailsById(id);
            if (salaryinfo != null)
                return Request.CreateResponse(HttpStatusCode.OK, salaryinfo);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No salaryinfo found for this id");
        }

        // POST api/salarydetails
        public int Post([FromBody] EmpAcountEntity item)
        {
            return _SalaryAccountDetails.CreateSalaryAccountDetails(item);
        }

        // PUT api/salarydetails/5
        public bool Put(int id, [FromBody]EmpAcountEntity item)
        {
            if (id > 0)
            {
                return _SalaryAccountDetails.UpdateSalaryAccountDetails(id, item);
            }
            return false;
        }

        // DELETE api/salarydetails/5
        public void Delete(int id)
        {
        }
    }
}

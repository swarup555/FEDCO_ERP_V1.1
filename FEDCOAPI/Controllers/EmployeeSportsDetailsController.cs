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
    public class EmployeeSportsDetailsController : ApiController
    {
        private readonly Iempsportsdetails _sportsdetails;

      
        public EmployeeSportsDetailsController()
        {
            _sportsdetails = new EmployeeSportsDetailService();
        }
        // GET api/employeesportsdetails
        public HttpResponseMessage Get()
        {
            var sportsdetails = _sportsdetails.GetAllSportsActivityDetails();
            if (sportsdetails != null)
            {
                var EmployeeSportsActivityEntities = sportsdetails as List<EmployeeSportsActivityEntities> ?? sportsdetails.ToList();
                if (EmployeeSportsActivityEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, EmployeeSportsActivityEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "sportsdetails not found");
        }

        // GET api/employeesportsdetails/5
        public HttpResponseMessage Get(int id)
        {
            var sportsdetails = _sportsdetails.GetSportsActivityById(id);
            if (sportsdetails != null)
                return Request.CreateResponse(HttpStatusCode.OK, sportsdetails);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No sportsdetails found for this id");
        }

        // POST api/employeesportsdetails
        public int Post([FromBody] EmployeeSportsActivityEntities item)
        {
            return _sportsdetails.CreateSportsActivityDetails(item);
        }

        // PUT api/employeesportsdetails/5
        public bool Put(int id, [FromBody] EmployeeSportsActivityEntities item)
        {
            if (id > 0)
            {
                return _sportsdetails.UpdateSportsActivityDetails(id, item);
            }
            return false;
        }

        // DELETE api/employeesportsdetails/5
        public void Delete(int id)
        {
        }
    }
}

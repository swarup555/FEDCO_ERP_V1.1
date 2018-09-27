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
    public class EmployeeHobbyController : ApiController
    {
         private readonly IEmpHobby _Hobbydetails;

        public EmployeeHobbyController()
        {
            _Hobbydetails = new EmployeeHobbyService();
        }
        // GET api/employeehobby
        public HttpResponseMessage Get()
        {
            var Hobbydetails = _Hobbydetails.GetAllEmployeeHobbiesDetails();
            if (Hobbydetails != null)
            {
                var EmployeeHobbiesEntity = Hobbydetails as List<EmployeeHobbiesEntity> ?? Hobbydetails.ToList();
                if (EmployeeHobbiesEntity.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, EmployeeHobbiesEntity);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Hobbydetails not found");
        }

        // GET api/employeehobby/5
        public HttpResponseMessage Get(int id)
        {
            var Hobbydetails = _Hobbydetails.GetEmployeeHobbiesById(id);
            if (Hobbydetails != null)
                return Request.CreateResponse(HttpStatusCode.OK, Hobbydetails);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No publicationdetails found for this id");
        }

        // POST api/employeehobby
        public int Post([FromBody] EmployeeHobbiesEntity item)
        {
            return _Hobbydetails.CreateEmployeeHobbiesDetails(item);
        }

        // PUT api/employeehobby/5
        public bool Put(int id, [FromBody] EmployeeHobbiesEntity item)
        {
            if (id > 0)
            {
                return _Hobbydetails.UpdateEmployeeHobbiesDetails(id, item);
            }
            return false;
        }

        // DELETE api/employeehobby/5
        public void Delete(int id)
        {
        }
    }
}

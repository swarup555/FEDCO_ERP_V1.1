using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BUSSINESS_SERVICE;
using BUSSINESS_ENTITIES;
using System.IO;

namespace FEDCOAPI.Controllers
{
    public class IndivisualController : ApiController
    {
        private readonly IindivisualEmployee _indivisualEmployee;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
        public IndivisualController()
        {
            _indivisualEmployee = new IndivisualEmployeeSevice();
        }
        #endregion
        // GET api/indivisual
        public HttpResponseMessage Get()
        {
            var Basicinfo = _indivisualEmployee.GetAllEmployeeDetails();
            if (Basicinfo != null)
            {
                var BasicinfoEntities = Basicinfo as List<IndivisualEmployeeEntities> ?? Basicinfo.ToList();
                if (BasicinfoEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, BasicinfoEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Basicinfo not found");
        }

        // GET api/indivisual/5
        public HttpResponseMessage Get(int id)
        {
            var Basicinfo = _indivisualEmployee.GetEmployeeById(id);
            if (Basicinfo != null)
                return Request.CreateResponse(HttpStatusCode.OK, Basicinfo);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Basicinfo found for this id");
        }

        // POST api/indivisual
        public void Post([FromBody]string value)
        {
        }

        // PUT api/indivisual/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/indivisual/5
        public void Delete(int id)
        {
        }
    }
}

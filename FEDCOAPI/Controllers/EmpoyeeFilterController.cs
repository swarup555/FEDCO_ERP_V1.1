using BUSSINESS_ENTITIES;
using BUSSINESS_SERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FEDCOAPI.Controllers
{
    public class EmpoyeeFilterController : ApiController
    {
         // GET api/empbasicinfo
        private readonly IBasicinformationEmployee _Basicinfo;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
         public EmpoyeeFilterController()
        {
            _Basicinfo = new EmployeeBasicInfoService();
        }
        #endregion
        // GET api/empoyeefilter
         public HttpResponseMessage Get()
         {
             var Basicinfo = _Basicinfo.GetAllEmployeeBasicinfo();
             if (Basicinfo != null)
             {
                 var BasicinfoEntities = Basicinfo as List<BasicInformaionEntities> ?? Basicinfo.ToList();
                 if (BasicinfoEntities.Any())
                     return Request.CreateResponse(HttpStatusCode.OK, BasicinfoEntities);
             }
             return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Basicinfo not found");
         }

        // GET api/empoyeefilter/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/empoyeefilter
        public void Post([FromBody]string value)
        {
        }

        // PUT api/empoyeefilter/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/empoyeefilter/5
        public void Delete(int id)
        {
        }
    }
}

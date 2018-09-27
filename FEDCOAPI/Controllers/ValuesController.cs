using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BUSSINESS_SERVICE;
using BUSSINESS_ENTITIES;
namespace WebApplication1.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly Idivision _divisionServices;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize Hierarchy service instance
        /// </summary>
        public ValuesController()
        {
            _divisionServices = new DIVISIONSERVICE();
        }

        #endregion
        // GET api/values
        public HttpResponseMessage Get()
        {
            var hierarchys = _divisionServices.GetAllDIVISION();
            if (hierarchys != null)
            {
                var hierarchyEntities = hierarchys as List<DIVISION> ?? hierarchys.ToList();
                if (hierarchyEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, hierarchyEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Hierarchies not found");
        }
        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

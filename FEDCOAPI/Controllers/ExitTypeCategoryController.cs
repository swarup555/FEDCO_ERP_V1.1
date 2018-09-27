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
    public class ExitTypeCategoryController : ApiController
    {
        private readonly IExittypeCategory _ExittypeCategory;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
        public ExitTypeCategoryController()
        {
            _ExittypeCategory = new ExitTypeCategoryService();
        }
        #endregion
        // GET api/exittypecategory
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/exittypecategory/5
        public HttpResponseMessage Get(int id)
        {
            var catinfo = _ExittypeCategory.GetExittypeCategoryById(id);
            if (catinfo != null)
                return Request.CreateResponse(HttpStatusCode.OK, catinfo);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No catinfo found for this id");
        }

        // POST api/exittypecategory
        public void Post([FromBody]string value)
        {
        }

        // PUT api/exittypecategory/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/exittypecategory/5
        public void Delete(int id)
        {
        }
    }
}

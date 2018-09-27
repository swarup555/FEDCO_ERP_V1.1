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
    public class ExitTypeController : ApiController
    {
         private readonly IExittype _Exittype;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
         public ExitTypeController()
        {
            _Exittype = new ExitTypeService();
        }
        #endregion
        // GET api/exittype
         public HttpResponseMessage Get()
         {
             var Exittype = _Exittype.GetAllExittype();
             if (Exittype != null)
             {
                 var ExittypeEntities = Exittype as List<ExitTypeEntities> ?? Exittype.ToList();
                 if (ExittypeEntities.Any())
                     return Request.CreateResponse(HttpStatusCode.OK, ExittypeEntities);
             }
             return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Exittype not found");
         }

        // GET api/exittype/5
         public HttpResponseMessage Get(int id)
         {
             var Exittype = _Exittype.GetExittypeById(id);
             if (Exittype != null)
                 return Request.CreateResponse(HttpStatusCode.OK, Exittype);
             return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Exittype found for this id");
         }

        // POST api/exittype
        public void Post([FromBody]string value)
        {
        }

        // PUT api/exittype/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/exittype/5
        public void Delete(int id)
        {
        }
    }
}

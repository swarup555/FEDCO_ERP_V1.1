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
    public class DesignationController : ApiController
    {
        private readonly IDesignation _Designation;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
         public DesignationController()
        {
            _Designation = new DesignationService();
        }
        #endregion
        // GET api/designation
         public HttpResponseMessage Get()
         {
             var Designation = _Designation.GetAllDesignation();
             if (Designation != null)
             {
                 var DesignationEntities = Designation as List<DesignationEntities> ?? Designation.ToList();
                 if (DesignationEntities.Any())
                     return Request.CreateResponse(HttpStatusCode.OK, DesignationEntities);
             }
             return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Designation not found");
         }
        // GET api/designation/5
         public HttpResponseMessage Get(int id)
         {
             var Designation = _Designation.GetDesignationById(id);
             if (Designation != null)
                 return Request.CreateResponse(HttpStatusCode.OK, Designation);
             return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No grDesignationade found for this id");
         }

        // POST api/designation
         public int Post([FromBody] DesignationEntities Designation)
         {
             return _Designation.CreateDesignation(Designation);
         }

        // PUT api/designation/5
         public bool Put(int id, [FromBody]DesignationEntities Designation)
         {
             if (id > 0)
             {
                 return _Designation.UpdateDesignationt(id, Designation);
             }
             return false;
         }

        // DELETE api/designation/5
         public bool Delete(int id)
         {
             if (id > 0)
                 return _Designation.DeleteDesignation(id);
             return false;
         }
    }
}

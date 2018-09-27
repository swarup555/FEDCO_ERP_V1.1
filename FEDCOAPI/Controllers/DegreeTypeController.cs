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
    public class DegreeTypeController : ApiController
    {
         private readonly IDegreeType _DegreeType;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
         public DegreeTypeController()
        {
            _DegreeType = new DegreTypeService();
        }
        #endregion
        // GET api/degreetype
         public HttpResponseMessage Get()
         {
             var DegreeType = _DegreeType.GetAllDegreeType();
             if (DegreeType != null)
             {
                 var DegreeTypeEntities = DegreeType as List<DegreeTypeEntities> ?? DegreeType.ToList();
                 if (DegreeTypeEntities.Any())
                     return Request.CreateResponse(HttpStatusCode.OK, DegreeTypeEntities);
             }
             return Request.CreateErrorResponse(HttpStatusCode.NotFound, "DegreeType not found");
         }

        // GET api/degreetype/5
         public HttpResponseMessage Get(int id)
         {
             var DegreeType = _DegreeType.GetDegreeTypeById(id);
             if (DegreeType != null)
                 return Request.CreateResponse(HttpStatusCode.OK, DegreeType);
             return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No DegreeType found for this id");
         }

        // POST api/degreetype
        public void Post([FromBody]string value)
        {
        }

        // PUT api/degreetype/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/degreetype/5
        public void Delete(int id)
        {
        }
    }
}

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
    public class SectionController : ApiController
    {
         private readonly ISection _Section;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
         public SectionController()
        {
            _Section = new SectionService();
        }
        #endregion
        // GET api/section
         public HttpResponseMessage Get()
         {
             var Section = _Section.GetAllSection();
             if (Section != null)
             {
                 var SectionEntities = Section as List<SectionEntities> ?? Section.ToList();
                 if (SectionEntities.Any())
                     return Request.CreateResponse(HttpStatusCode.OK, SectionEntities);
             }
             return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Section not found");
         }

        // GET api/section/5
         public HttpResponseMessage Get(string id)
         {
             var Section = _Section.GetSectionById(id);
             if (Section != null)
                 return Request.CreateResponse(HttpStatusCode.OK, Section);
             return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Section found for this id");
         }

        // POST api/section
        public void Post([FromBody]string value)
        {
        }

        // PUT api/section/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/section/5
        public void Delete(int id)
        {
        }
    }
}

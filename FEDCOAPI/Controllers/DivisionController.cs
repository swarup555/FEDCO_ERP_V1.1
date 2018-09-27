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
    public class DivisionController : ApiController
    {
          private readonly Idivision _division;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
          public DivisionController()
        {
            _division = new DIVISIONSERVICE();
        }
        #endregion
        // GET api/division
          public HttpResponseMessage Get()
          {
              var division = _division.GetAllDIVISION();
              if (division != null)
              {
                  var divisionEntities = division as List<DIVISION> ?? division.ToList();
                  if (divisionEntities.Any())
                      return Request.CreateResponse(HttpStatusCode.OK, divisionEntities);
              }
              return Request.CreateErrorResponse(HttpStatusCode.NotFound, "division not found");
          }

        // GET api/division/5
          public HttpResponseMessage Get(int id)
          {
              var division = _division.GetDIVISIONById(id);
              if (division != null)
                  return Request.CreateResponse(HttpStatusCode.OK, division);
              return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No division found for this id");
          }

        // POST api/division
        public void Post([FromBody]string value)
        {

        }

        // PUT api/division/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/division/5
        public void Delete(int id)
        {
        }
    }
}

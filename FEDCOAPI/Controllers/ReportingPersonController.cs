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
    public class ReportingPersonController : ApiController
    {
         private readonly IReportingPerson _ReportingPerson;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
         public ReportingPersonController()
        {
            _ReportingPerson = new ReportingService();
        }
        #endregion
        // GET api/reportingperson
         public HttpResponseMessage Get()
         {
             var ReportingPerson = _ReportingPerson.GetAllDepartment();
             if (ReportingPerson != null)
             {
                 var ReportingPersonEntities = ReportingPerson as List<Reportingentities> ?? ReportingPerson.ToList();
                 if (ReportingPersonEntities.Any())
                     return Request.CreateResponse(HttpStatusCode.OK, ReportingPersonEntities);
             }
             return Request.CreateErrorResponse(HttpStatusCode.NotFound, "ReportingPerson not found");
         }

        // GET api/reportingperson/5
         public HttpResponseMessage Get(int id)
         {
             var ReportingPerson = _ReportingPerson.GetReportingPersonById(id);
             if (ReportingPerson != null)
                 return Request.CreateResponse(HttpStatusCode.OK, ReportingPerson);
             return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No ReportingPerson found for this id");
         }

        // POST api/reportingperson
        public void Post([FromBody]string value)
        {
        }

        // PUT api/reportingperson/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/reportingperson/5
        public void Delete(int id)
        {
        }
    }
}

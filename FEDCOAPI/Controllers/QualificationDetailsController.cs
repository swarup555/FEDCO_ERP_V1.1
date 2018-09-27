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
    public class QualificationDetailsController : ApiController
    {
        private readonly IQualificationDetails _QualificationDetails;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
        public QualificationDetailsController()
        {
            _QualificationDetails = new QualificationDetailsService();
        }
        #endregion
        // GET api/qualificationdetails
         public HttpResponseMessage Get()
         {
             var QualificationDetails = _QualificationDetails.GetAllQualificationDetails();
             if (QualificationDetails != null)
             {
                 var QualificationDetailsEntities = QualificationDetails as List<QualificationDetailsEntities> ?? QualificationDetails.ToList();
                 if (QualificationDetailsEntities.Any())
                     return Request.CreateResponse(HttpStatusCode.OK, QualificationDetailsEntities);
             }
             return Request.CreateErrorResponse(HttpStatusCode.NotFound, "QualificationDetails not found");
         }

        // GET api/qualificationdetails/5
         public HttpResponseMessage Get(int id)
         {
             var QualificationDetails = _QualificationDetails.GetQualificationDetailseById(id);
             if (QualificationDetails != null)
                 return Request.CreateResponse(HttpStatusCode.OK, QualificationDetails);
             return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No CommunicationDetails found for this id");
         }
        // POST api/qualificationdetails
         public int Post([FromBody] QualificationDetailsEntities item)
         {
             return _QualificationDetails.CreateQualificationDetails(item);
         }

        // PUT api/qualificationdetails/5
         public bool Put(int id, [FromBody]QualificationDetailsEntities item)
         {
             if (id > 0)
             {
                 return _QualificationDetails.UpdateQualificationDetails(id, item);
             }
             return false;
         }

        // DELETE api/qualificationdetails/5
        public void Delete(int id)
        {
        }
    }
}

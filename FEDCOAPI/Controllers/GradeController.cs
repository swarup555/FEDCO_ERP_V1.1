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
    public class GradeController : ApiController
    {
          private readonly IGrade _Grade;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
          public GradeController()
        {
            _Grade = new GradeService();
        }
        #endregion
        // GET api/grade
          public HttpResponseMessage Get()
          {
              var grade = _Grade.GetAllGrade();
              if (grade != null)
              {
                  var gradeEntities = grade as List<GradeEnities> ?? grade.ToList();
                  if (gradeEntities.Any())
                      return Request.CreateResponse(HttpStatusCode.OK, gradeEntities);
              }
              return Request.CreateErrorResponse(HttpStatusCode.NotFound, "grade not found");
          }

        // GET api/grade/5
          public HttpResponseMessage Get(int id)
          {
              var grade = _Grade.GetGradeById(id);
              if (grade != null)
                  return Request.CreateResponse(HttpStatusCode.OK, grade);
              return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No grade found for this id");
          }
        // POST api/grade
          public int Post([FromBody] GradeEnities Grade)
          {
              return _Grade.CreateGrade(Grade);
          }

        // PUT api/grade/5
          public bool Put(int id, [FromBody]GradeEnities Grade)
          {
              if (id > 0)
              {
                  return _Grade.UpdateGrade(id, Grade);
              }
              return false;
          }

        // DELETE api/grade/5
          public bool Delete(int id)
          {
              if (id > 0)
                  return _Grade.DeleteGrade(id);
              return false;
          }
    }
}

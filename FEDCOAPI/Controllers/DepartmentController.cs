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
    public class DepartmentController : ApiController
    {
        private readonly IDepartment _Department;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
        public DepartmentController()
        {
            _Department = new DepartmentService();
        }
        #endregion
        // GET api/department
        public HttpResponseMessage Get()
        {
            var Department = _Department.GetAllDepartment();
            if (Department != null)
            {
                var DepartmentEntities = Department as List<DepartmentEntities> ?? Department.ToList();
                if (DepartmentEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, DepartmentEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Department not found");
        }

        // GET api/department/5
        public HttpResponseMessage Get(int id)
        {
            var Department = _Department.GetDepartmentById(id);
            if (Department != null)
                return Request.CreateResponse(HttpStatusCode.OK, Department);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Department found for this id");
        }

        // POST api/department
        public int Post([FromBody] DepartmentEntities Department)
        {
            return _Department.CreateDepartment(Department);
        }

        // PUT api/department/5
        public bool Put(int id, [FromBody]DepartmentEntities Department)
        {
            if (id > 0)
            {
                return _Department.UpdateDepartment(id, Department);
            }
            return false;
        }

        // DELETE api/department/5
        public bool Delete(int id)
        {
            if (id > 0)
                return _Department.DeleteDepartment(id);
            return false;
        }
    }
}

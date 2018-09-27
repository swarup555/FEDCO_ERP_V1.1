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
    public class BloodGroupController : ApiController
    {

        private readonly IBloodGroup _BloodGroup;
           #region Public Constructor

        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
        public BloodGroupController()
        {
            _BloodGroup = new BloodGroupService();
        }
        #endregion
        // GET api/bloodgroup
        public HttpResponseMessage Get()
        {
            var BloodGroups = _BloodGroup.GetAllBloodGroup();
            if (BloodGroups != null)
            {
                var BloodGroupEntity = BloodGroups as List<BloodGroupEntities> ?? BloodGroups.ToList();
                if (BloodGroupEntity.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, BloodGroupEntity);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "BloodGroup not found");
        }

        // GET api/bloodgroup/5
        public HttpResponseMessage Get(int id)
        {
            var BloodGroups = _BloodGroup.GetBloodGroupById(id);
            if (BloodGroups != null)
                return Request.CreateResponse(HttpStatusCode.OK, BloodGroups);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No BloodGroup found for this id");
        }

        // POST api/bloodgroup
        public int Post([FromBody] BloodGroupEntities bldgrp)
        {
            return _BloodGroup.CreateBloodGroup(bldgrp);
        }

        // PUT api/bloodgroup/5
        public bool Put(int id, [FromBody]BloodGroupEntities bldgrp)
        {
            if (id > 0)
            {
                return _BloodGroup.UpdateBloodGroup(id, bldgrp);
            }
            return false;
        }

        // DELETE api/bloodgroup/5
        public bool Delete(int id)
        {
            if (id > 0)
                return _BloodGroup.DeleteEmployeebasicinfo(id);
            return false;
        }
    }
}

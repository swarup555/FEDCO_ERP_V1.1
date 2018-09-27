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
    public class RelationshipController : ApiController
    {
        private readonly IRelationshipdetails _Relationshipdetails;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
        public RelationshipController()
        {
            _Relationshipdetails = new RelationshipDetailsService();
        }
        #endregion
        // GET api/relationship
        public HttpResponseMessage Get()
        {
            var Relationshipdetails = _Relationshipdetails.GetAllRelationshipdetails();
            if (Relationshipdetails != null)
            {
                var RelationshipdetailsEntities = Relationshipdetails as List<RelationshipDetailEntities> ?? Relationshipdetails.ToList();
                if (RelationshipdetailsEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, RelationshipdetailsEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Relationshipdetails not found");
        }

        // GET api/relationship/5
        public HttpResponseMessage Get(int id)
        {
            var Relationshipdetails = _Relationshipdetails.GetRelationshipdetailsById(id);
            if (Relationshipdetails != null)
                return Request.CreateResponse(HttpStatusCode.OK, Relationshipdetails);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Relationshipdetails found for this id");
        }

        // POST api/relationship
        public int Post([FromBody] RelationshipDetailEntities item)
        {
            return _Relationshipdetails.CreateRelationshipdetails(item);
        }

        // PUT api/relationship/5
        public bool Put(int id, [FromBody]RelationshipDetailEntities item)
        {
            if (id > 0)
            {
                return _Relationshipdetails.UpdateRelationshipdetails(id, item);
            }
            return false;
        }

        // DELETE api/relationship/5
        public void Delete(int id)
        {
        }
    }
}

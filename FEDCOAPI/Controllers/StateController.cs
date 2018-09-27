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
    public class StateController : ApiController
    {
         private readonly IState _State;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
        public StateController()
        {
            _State = new StateService();
        }
        #endregion
        // GET api/state
        public HttpResponseMessage Get()
        {
            var state = _State.GetAllState();
            if (state != null)
            {
                var stateEntities = state as List<StateEntities> ?? state.ToList();
                if (stateEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, stateEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "state not found");
        }

        // GET api/state/5
        public HttpResponseMessage Get(int id)
        {
            var state = _State.GetStateById(id);
            if (state != null)
                return Request.CreateResponse(HttpStatusCode.OK, state);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No division found for this id");
        }

        // POST api/state
        public void Post([FromBody]string value)
        {
        }

        // PUT api/state/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/state/5
        public void Delete(int id)
        {
        }
    }
}

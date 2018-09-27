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
    public class loginController : ApiController
    {
         private readonly Iuser _user;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
         public loginController()
        {
            _user = new UserService();
        }
        #endregion
        // GET api/login
         public HttpResponseMessage Get()
         {
             var user = _user.GetAllUserDetails();
             if (user != null)
             {
                 var userEntities = user as List<UserEntities> ?? user.ToList();
                 if (userEntities.Any())
                     return Request.CreateResponse(HttpStatusCode.OK, userEntities);
             }
             return Request.CreateErrorResponse(HttpStatusCode.NotFound, "division not found");
         }

        // GET api/login/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/login
        public void Post([FromBody]string value)
        {
        }

        // PUT api/login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/login/5
        public void Delete(int id)
        {
        }
    }
}

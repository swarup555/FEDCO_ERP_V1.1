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
    public class EmpbasicinfoController : ApiController
    {
        // GET api/empbasicinfo
         private readonly IBasicinfo _Basicinfo;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
         public EmpbasicinfoController()
        {
            _Basicinfo = new BasicInformationService();
        }
        #endregion
      
         public HttpResponseMessage Get()
         {
             var Basicinfo = _Basicinfo.GetAllEmployeeBasicinfo();
             if (Basicinfo != null)
             {
                 var BasicinfoEntities = Basicinfo as List<BasicInformaionEntities> ?? Basicinfo.ToList();
                 if (BasicinfoEntities.Any())
                     return Request.CreateResponse(HttpStatusCode.OK, BasicinfoEntities);
             }
             return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Basicinfo not found");
         }
    
         public HttpResponseMessage Get(int id)
         {
             var Basicinfo = _Basicinfo.GetEmployeebasicinfoById(id);
             if (Basicinfo != null)
                 return Request.CreateResponse(HttpStatusCode.OK, Basicinfo);
             return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Basicinfo found for this id");
         }
      
 
         public int Post([FromBody] BasicInformaionEntities item)
         {
             return _Basicinfo.CreateEmployeebasicinfo(item);
         }
     
         public bool Put(int id, [FromBody]BasicInformaionEntities item)
         {
             if (id > 0)
             {
                 return _Basicinfo.UpdateEmployeebasicinfo(id, item);
             }
             return false;
         }

        // DELETE api/empbasicinfo/5
        public void Delete(int id)
        {
        }
    }
}

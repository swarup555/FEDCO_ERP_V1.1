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
    public class CountryController : ApiController
    {
        private readonly ICountry _Country;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
         public CountryController()
        {
            _Country = new CountryService();
        }
        #endregion
        // GET api/country
         public HttpResponseMessage Get()
         {
             var country = _Country.GetAllCountry();
             if (country != null)
             {
                 var countryEntities = country as List<CountryEntities> ?? country.ToList();
                 if (countryEntities.Any())
                     return Request.CreateResponse(HttpStatusCode.OK, countryEntities);
             }
             return Request.CreateErrorResponse(HttpStatusCode.NotFound, "country not found");
         }

        // GET api/country/5
         public HttpResponseMessage Get(int id)
         {
             var country = _Country.GetCountryById(id);
             if (country != null)
                 return Request.CreateResponse(HttpStatusCode.OK, country);
             return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No country found for this id");
         }

        // POST api/country
        public void Post([FromBody]string value)
        {
        }

        // PUT api/country/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/country/5
        public void Delete(int id)
        {
        }
    }
}

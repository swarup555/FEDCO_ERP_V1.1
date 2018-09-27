using BUSSINESS_ENTITIES;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FEDCO_ERP_V1._1.Controllers
{
    public class EmployeelistController : Controller
    {
        //
        // GET: /Employeelist/
          HttpClient client;
        //The URL of the WEB API Service
        string url = System.Configuration.ConfigurationManager.AppSettings["APIUrl"];
        #region Public Constructor
        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
        public EmployeelistController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage responseMessagedesignation = await client.GetAsync(url + "basicinformation");
            if (responseMessagedesignation.IsSuccessStatusCode)
            {
                var responseData = responseMessagedesignation.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<BasicInformaionEntities>>(responseData);

                return View(result.ToList());
            }

            return View();
        }
	}
}
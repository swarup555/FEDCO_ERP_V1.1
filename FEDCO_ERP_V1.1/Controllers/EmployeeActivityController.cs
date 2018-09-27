using BUSSINESS_ENTITIES;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Caching;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FEDCO_ERP_V1._1.Controllers
{
    public class EmployeeActivityController : Controller
    {
         HttpClient client;
        //The URL of the WEB API Service
        //string url = "http://localhost:8086/webapi/api/";
        //string url = "http://localhost:56783/api/";
        //string url = "http://172.18.0.21:8087/api/";
        string url = System.Configuration.ConfigurationManager.AppSettings["APIUrl"];
        #region Public Constructor
        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
        public EmployeeActivityController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion
        // GET: /EmployeeActivity/
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> GetAwards(string id) 
        {

            HttpResponseMessage responseMessagesubdivision = await client.GetAsync(url + "employeeaward/" + id);

            if (responseMessagesubdivision.IsSuccessStatusCode)
            {
                var responseData = responseMessagesubdivision.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<EmployeeAwardEntities>>(responseData);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return View();
        }
        public async Task<ActionResult> GetPublications(string id)
        {

            HttpResponseMessage responseMessagesubdivision = await client.GetAsync(url + "employeepublication/" + id);

            if (responseMessagesubdivision.IsSuccessStatusCode)
            {
                var responseData = responseMessagesubdivision.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<EmployeePublicationEntities>>(responseData);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return View();
        }
        public async Task<ActionResult> GetHobbies(string id)
        {

            HttpResponseMessage responseMessagesubdivision = await client.GetAsync(url + "employeehobby/" + id);

            if (responseMessagesubdivision.IsSuccessStatusCode)
            {
                var responseData = responseMessagesubdivision.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<EmployeeHobbiesEntity>>(responseData);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return View();
        }
        public async Task<ActionResult> GetSports(string id)
        {

            HttpResponseMessage responseMessagesubdivision = await client.GetAsync(url + "employeesportsdetails/" + id);

            if (responseMessagesubdivision.IsSuccessStatusCode)
            {
                var responseData = responseMessagesubdivision.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<EmployeeSportsActivityEntities>>(responseData);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return View();
        }
        public async Task<ActionResult> GetCulturalActivity(string id)
        {

            HttpResponseMessage responseMessagesubdivision = await client.GetAsync(url + "employeeculturaldetail/" + id);

            if (responseMessagesubdivision.IsSuccessStatusCode)
            {
                var responseData = responseMessagesubdivision.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<EmployeeCulturalActivityEntities>>(responseData);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return View();
        }
        public async Task<ActionResult> GetSocialActivity(string id)
        {
            HttpResponseMessage responseMessagesubdivision = await client.GetAsync(url + "employeesocialactivity/" + id);

            if (responseMessagesubdivision.IsSuccessStatusCode)
            {
                var responseData = responseMessagesubdivision.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<EmployeeSocialActivityEntities>>(responseData);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return View();
        }

        public async Task<ActionResult> InsertAwardDetails(EmployeeAwardEntities award)
        {

            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url + "employeeaward", award);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Json(new { success = true, responseText = "data saved successfuly !" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false, responseText = "data saved unsuccessfuly !" }, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> InsertPublicationDetails(EmployeePublicationEntities publication) 
        {

            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url + "employeepublication", publication);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Json(new { success = true, responseText = "data saved successfuly !" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false, responseText = "data saved unsuccessfuly !" }, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> InsertHobbiesDetails(EmployeeHobbiesEntity employeehobby)
        {

            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url + "employeehobby", employeehobby);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Json(new { success = true, responseText = "data saved successfuly !" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false, responseText = "data saved unsuccessfuly !" }, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> InsertSportsDetails(EmployeeSportsActivityEntities sports)
        {

            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url + "employeesportsdetails", sports);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Json(new { success = true, responseText = "data saved successfuly !" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false, responseText = "data saved unsuccessfuly !" }, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> InsertCulturalActivityDetails(EmployeeCulturalActivityEntities Cultural)
        {

            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url + "employeeculturaldetail", Cultural);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Json(new { success = true, responseText = "data saved successfuly !" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false, responseText = "data saved unsuccessfuly !" }, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> InsertSocialActivityDetails(EmployeeSocialActivityEntities SocialActivity)
        {

            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url + "employeesocialactivity", SocialActivity);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Json(new { success = true, responseText = "data saved successfuly !" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false, responseText = "data saved unsuccessfuly !" }, JsonRequestBehavior.AllowGet);
        } 
	}
}
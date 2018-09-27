using BUSSINESS_ENTITIES;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Caching;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FEDCO_ERP_V1._1.Controllers
{
    public class ReportController : Controller
    {
        private const string CacheKey = "rerp";
        ObjectCache cache = MemoryCache.Default;
        //string urlid = null;
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
        public ReportController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion
        // GET: /Report/
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> GetEmployeeReport(string WORKLOCATIONs, string divisions, string subdivisions, string sections, string departments, string designation, string grade, string bloodgroup)
        {
            if (cache.Contains(CacheKey))
            {
                IEnumerable<BasicInformaionEntities> results;
                results = (IEnumerable<BasicInformaionEntities>)cache.Get(CacheKey);
                results = results.Where(x => x.STATUS == "Active").ToList();
                if (divisions != "0")
                {

                }
                else if (subdivisions != "0")
                {

                }
                else if (sections != "0")
                {

                }
                else if (WORKLOCATIONs != "0")
                {
                    results = results.ToList().Where(x => x.WORKLOCATION == Convert.ToDecimal(WORKLOCATIONs));
                }
                if (divisions != "0")
                {
                    results = results.ToList().Where(x => x.DIVISION == divisions);
                }
                if (subdivisions != "0")
                {
                    results = results.ToList().Where(x => x.SUBDIVISION == subdivisions);
                }
                if (sections != "0")
                {
                    results = results.ToList().Where(x => x.SECTION == sections);
                }
                if (departments != "0")
                {
                    results = results.ToList().Where(x => x.DEPARTMENT == Convert.ToDecimal(departments));
                }
                if (designation != "0")
                {
                    results = results.ToList().Where(x => x.DESIGNATION == Convert.ToDecimal(designation));
                }
                if (grade != "0")
                {
                    results = results.ToList().Where(x => x.GRADE == Convert.ToDecimal(grade));
                }
                if (bloodgroup != "0")
                {
                    results = results.ToList().Where(x => x.BLOOD_GROUP == Convert.ToDecimal(bloodgroup));
                }
                var jsonResult = Json(results, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            else
            {
                HttpResponseMessage responseMessagedesignation = await client.GetAsync(url + "empoyeefilter");
                if (responseMessagedesignation.IsSuccessStatusCode)
                {
                    var responseData = responseMessagedesignation.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<List<BasicInformaionEntities>>(responseData);
                    CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
                    cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddDays(1.0);
                    cache.Add(CacheKey, result, cacheItemPolicy);
                    IEnumerable<BasicInformaionEntities> results;
                    results = result.Where(x => x.STATUS == "Active").ToList();
                    if (divisions != "0")
                    {

                    }
                    else if (subdivisions != "0")
                    {

                    }
                    else if (sections != "0")
                    {

                    }
                    else if (WORKLOCATIONs != "0")
                    {
                        results = results.ToList().Where(x => x.WORKLOCATION == Convert.ToDecimal(WORKLOCATIONs));
                    }
                    if (divisions != "0")
                    {
                        results = results.ToList().Where(x => x.DIVISION == divisions);
                    }
                    if (subdivisions != "0")
                    {
                        results = results.ToList().Where(x => x.SUBDIVISION == subdivisions);
                    }
                    if (sections != "0")
                    {
                        results = results.ToList().Where(x => x.SECTION == sections);
                    }
                    if (departments != "0")
                    {
                        results = results.ToList().Where(x => x.DEPARTMENT == Convert.ToDecimal(departments));
                    }
                    if (designation != "0")
                    {
                        results = results.ToList().Where(x => x.DESIGNATION == Convert.ToDecimal(designation));
                    }
                    if (grade != "0")
                    {
                        results = results.ToList().Where(x => x.GRADE == Convert.ToDecimal(grade));
                    }
                    if (bloodgroup != "0")
                    {
                        results = results.ToList().Where(x => x.BLOOD_GROUP == Convert.ToDecimal(bloodgroup));
                    }
                    var jsonResult = Json(results, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                return null;
            }

        }
    }
}
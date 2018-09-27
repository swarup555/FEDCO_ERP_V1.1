using BUSSINESS_ENTITIES;
using FEDCO_ERP_V1._1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Utilities;

namespace FEDCO_ERP_V1._1.Controllers
{
    public class UtilityController : Controller
    {
        HttpClient client;
        //string url = "http://localhost:56783/api/";
        //string url = "http://172.18.0.21:8087/api/";
        string url = System.Configuration.ConfigurationManager.AppSettings["APIUrl"];
        //
        // GET: /Utility/
        public ActionResult Index()
        {
            return View();
        }
         //url: " @Url.Action("GetEmployeeInfo", "Utility")",

           #region Public Constructor
        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
        public UtilityController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion
               
        public async Task<ActionResult> GetEmployeeInfo(string WORKLOCATION,string division,string subdivision,string section,string department)
        {
            HttpResponseMessage responseMessagedesignation = await client.GetAsync(url + "basicinformation");
            if (responseMessagedesignation.IsSuccessStatusCode)
            {
                IEnumerable<BasicInformaionEntities> results;
                var responseData = responseMessagedesignation.Content.ReadAsStringAsync().Result;
                results = JsonConvert.DeserializeObject<List<BasicInformaionEntities>>(responseData);
                results = results.Where(x => x.STATUS == "Active").ToList();
                if (division != "0")
                {

                }
                else if (subdivision != "0")
                {

                }
                else if (section != "0")
                {

                }
                else if (WORKLOCATION != "0")
                {
                    results = results.ToList().Where(x => x.WORKLOCATION == Convert.ToDecimal(WORKLOCATION));
                }
                if (division != "0"  )
                {
                    results = results.ToList().Where(x => x.DIVISION == division);
                }
                if (subdivision != "0")
                {
                    results = results.ToList().Where(x => x.SUBDIVISION == subdivision);
                }
                if (section != "0")
                {
                    results = results.ToList().Where(x => x.SECTION == section);
                }
                if (department != "0")
                {
                    results = results.ToList().Where(x => x.DEPARTMENT == Convert.ToDecimal(department));
                }
                var jsonResult = Json(results, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }

            return View();
        }

        public ActionResult Sendsms(messagedata msg)
        {
            Utilities.CSMS objutility = new Utilities.CSMS();
            string[] RECEIPANT = msg.receipants.ToString().Split(',');
            StringBuilder sb = new StringBuilder();
            foreach(string str in RECEIPANT)
            {
                sb.Clear();
                sb.Append(msg.message);
                objutility.SendSingleSMS(str, sb.ToString());
            }
            
            return null;
        }
	}
}
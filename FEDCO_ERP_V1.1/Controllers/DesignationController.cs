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
    public class DesignationController : Controller
    {
        HttpClient client;
        string url = System.Configuration.ConfigurationManager.AppSettings["APIUrl"];
        #region Public Constructor
        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
        public DesignationController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion
        //
        // GET: /Designation/
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Designationdtls()
        {

            HttpResponseMessage responseMessagecomdtls = await client.GetAsync(url + "designation");
            if (responseMessagecomdtls.IsSuccessStatusCode)
            {
                var responseData = responseMessagecomdtls.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<DesignationEntities>>(responseData);

                //var comdtls = result.ToList().FirstOrDefault();

                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return View();
        }
        public async Task<ActionResult> DesignationCreate(DesignationEntities dept)
        {


            //if (ModelState.IsValid)
            //{

            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url + "designation", dept);

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["sucsmsg"] = "saved";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> DesignationEdit(DesignationEntities dept, FormCollection fc)
        {

            int id = Convert.ToInt32(fc["rowid3"]);
            //if (ModelState.IsValid)
            //{

            HttpResponseMessage responseMessage = await client.PutAsJsonAsync(url + "designation/" + id, dept);

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["sucmsgupdate"] = "saved";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> DesignationDelete(FormCollection fc)
        {
            int id = Convert.ToInt32(fc["rowid4"]);
            HttpResponseMessage responseMessage = await client.DeleteAsync(url + "designation/" + +id);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["sucmsgdel"] = "saved";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
	}
}
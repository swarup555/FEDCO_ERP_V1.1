using BUSSINESS_ENTITIES;
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
    public class AssttypeAdminController : Controller
    {
         HttpClient client;
        string url = System.Configuration.ConfigurationManager.AppSettings["APIUrl"];
        #region Public Constructor
        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
        public AssttypeAdminController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion
        // GET: /AssttypeAdmin/
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> AdminAssettypeCreate(AssetTypeEntities dept)
        {


            //if (ModelState.IsValid)
            //{

            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url + "assettype", dept);

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["sucsmsg"] = "saved";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> AdminAssettypeEdit(AssetTypeEntities dept, FormCollection fc)
        {

            int id = Convert.ToInt32(fc["rowid3"]);
            //if (ModelState.IsValid)
            //{

            HttpResponseMessage responseMessage = await client.PutAsJsonAsync(url + "assettype/" + id, dept);

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["sucmsgupdate"] = "saved";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> AdminAssettypeDelete(FormCollection fc)
        {
            int id = Convert.ToInt32(fc["rowid4"]);
            HttpResponseMessage responseMessage = await client.DeleteAsync(url + "assettype/" + +id);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["sucmsgdel"] = "saved";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
	}
}
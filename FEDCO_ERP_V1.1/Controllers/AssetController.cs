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
    public class AssetController : Controller
    {
          HttpClient client;
        string url = System.Configuration.ConfigurationManager.AppSettings["APIUrl"];
        #region Public Constructor
        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
        public AssetController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion
        //
        // GET: /Asset/
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Assettypedtls()
        {

            HttpResponseMessage responseMessagecomdtls = await client.GetAsync(url + "assettype");
            if (responseMessagecomdtls.IsSuccessStatusCode)
            {
                var responseData = responseMessagecomdtls.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<AssetTypeEntities>>(responseData);

                //var comdtls = result.ToList().FirstOrDefault();

                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return View();
        }
        public async Task<ActionResult> Assetdtls()
        {

            HttpResponseMessage responseMessagecomdtls = await client.GetAsync(url + "assetmaster");
            if (responseMessagecomdtls.IsSuccessStatusCode)
            {
                var responseData = responseMessagecomdtls.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<AssetmasterEntities>>(responseData);

                //var comdtls = result.ToList().FirstOrDefault();

                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return View();
        }
        public async Task<ActionResult> AssetCreate(AssetmasterEntities dept)
        {


            //if (ModelState.IsValid)
            //{

            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url + "assetmaster", dept);

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["sucsmsg"] = "saved";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> AssetEdit(AssetmasterEntities dept, FormCollection fc)
        {

            int id = Convert.ToInt32(fc["rowid3"]);
            //if (ModelState.IsValid)
            //{

            HttpResponseMessage responseMessage = await client.PutAsJsonAsync(url + "assetmaster/" + id, dept);

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["sucmsgupdate"] = "saved";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> AssetDelete(FormCollection fc)
        {
            int id = Convert.ToInt32(fc["rowid4"]);
            HttpResponseMessage responseMessage = await client.DeleteAsync(url + "assetmaster/" + +id);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["sucmsgdel"] = "saved";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
	}
}
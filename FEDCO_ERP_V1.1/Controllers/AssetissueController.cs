using BUSSINESS_ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Web.Script.Serialization;
using System.Web.Configuration;
using System.Runtime.Caching;
using System.Web.Routing;

namespace FEDCO_ERP_V1._1.Controllers
{
    public class AssetissueController : Controller
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
        public AssetissueController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion
        //
        // GET: /Assetissue/
        public ActionResult Index(string id = null)
        {
            Session["urladid"] = null;
            Session.Remove("urladid");
            Session["urladid"] = id;
            return View();
        }
        public async Task<ActionResult> Assetdetails()
        {

            HttpResponseMessage responseMessageAssetdtls = await client.GetAsync(url + "assetdetails/" + Convert.ToInt32(Session["urladid"]));
            if (responseMessageAssetdtls.IsSuccessStatusCode)
            {
                var responseData = responseMessageAssetdtls.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<AssetDetailsEntities>>(responseData);

                //var comdtls = result.ToList().FirstOrDefault();

                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return View();
        }

        public async Task<ActionResult> Assetname(string id)
        {

            HttpResponseMessage responseMessagecomdtls = await client.GetAsync(url + "assetmaster");
            if (responseMessagecomdtls.IsSuccessStatusCode)
            {
                var responseData = responseMessagecomdtls.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<AssetmasterEntities>>(responseData);
                var asset = result.Where(x=>x.ASSETTYPE_ID==Convert.ToDecimal(id));

                //var comdtls = result.ToList().FirstOrDefault();

                return Json(asset, JsonRequestBehavior.AllowGet);
            }

            return View();
        }
        public async Task<ActionResult> Assetdtlscreate(AssetDetailsEntities bie)
        {
            bie.EMPLOYEE_ID = Convert.ToInt32(Session["urladid"]);
            //if (ModelState.IsValid)
            //{

            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url + "assetdetails", bie);

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["sucsmsg"] = "saved";
                //return RedirectToAction("Index");
                return RedirectToAction("Index", new RouteValueDictionary(
                new { controller = "Assetissue", action = "Index", id = Convert.ToInt32(Session["urladid"]) }));
            }
            return Json("_Asset");
        }
        public async Task<ActionResult> Assetdtlsedit(int id, AssetDetailsEntities bie)
        {

            HttpResponseMessage responseMessageemploymentdetails = await client.PutAsJsonAsync(url + "assetdetails/" + id, bie);
            if (responseMessageemploymentdetails.IsSuccessStatusCode)
            {
                TempData["sucmsgupdate"] = "saved";
                return RedirectToAction("Index", new RouteValueDictionary(
                new { controller = "Assetissue", action = "Index", id = Convert.ToInt32(Session["urladid"]) }));
            }
            return Json("_Asset");
        }
	}
}
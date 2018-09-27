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
    public class DepartmentController : Controller
    {
        HttpClient client;
        //string url = "http://localhost:56783/api/";
        //string url = "http://172.18.0.21:8087/api/";
        string url = System.Configuration.ConfigurationManager.AppSettings["APIUrl"];
          #region Public Constructor
        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
        public DepartmentController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion
        //
        // GET: /Department/
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Departmentdtls()
        {

            HttpResponseMessage responseMessagecomdtls = await client.GetAsync(url + "department");
            if (responseMessagecomdtls.IsSuccessStatusCode)
            {
                var responseData = responseMessagecomdtls.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<DepartmentEntities>>(responseData);

                //var comdtls = result.ToList().FirstOrDefault();

                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return View();
        }
        public async Task<ActionResult> DepartmentCreate(DepartmentEntities dept)
        {


            //if (ModelState.IsValid)
            //{

            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url + "department", dept);

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["sucsmsg"] = "saved";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> DepartmentEdit(DepartmentEntities dept,FormCollection fc)
        {

            int id = Convert.ToInt32(fc["rowid3"]);
            //if (ModelState.IsValid)
            //{

            HttpResponseMessage responseMessage = await client.PutAsJsonAsync(url + "department/" + id, dept);

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["sucmsgupdate"] = "saved";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Delete( FormCollection fc)
        {
            int id = Convert.ToInt32(fc["rowid4"]);
            HttpResponseMessage responseMessage = await client.DeleteAsync(url + "department/" + +id);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["sucmsgdel"] = "saved";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
	}
}
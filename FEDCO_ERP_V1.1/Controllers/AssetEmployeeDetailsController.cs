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
using System.Web.Security;

namespace FEDCO_ERP_V1._1.Controllers
{
    public class AssetEmployeeDetailsController : Controller
    {
        HttpClient client;
        // GET: /AssetEmployeeDetails/
        string url = System.Configuration.ConfigurationManager.AppSettings["APIUrl"];
        //public List<BasicInformaionEntities> basicinfodata=new List<BasicInformaionEntities>();
        //public List<List<BasicInformaionEntities>> bas = new List<List<BasicInformaionEntities>>();
        //ArrayList data = new ArrayList();
        #region Public Constructor
        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
        public AssetEmployeeDetailsController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion
        public async Task<ActionResult> Index()
        {
            decimal? empid = null;
            var userid = HttpContext.Request.QueryString["id"];
            if (userid != null)
            {
                HttpResponseMessage responseMessageuser = await client.GetAsync(url + "login");

                var responseData1 = responseMessageuser.Content.ReadAsStringAsync().Result;
                //var result = (BasicInformaionEntities)null;
                //if(responseData!=null)
                //{
                //    result = JsonConvert.DeserializeObject<BasicInformaionEntities>(responseData);
                //}
                var result1 = JsonConvert.DeserializeObject<List<UserEntities>>(responseData1);
                var jsonResult1 = Json(result1, JsonRequestBehavior.AllowGet);
                jsonResult1.MaxJsonLength = int.MaxValue;
                var user = result1.ToList().Where(x => x.USERID == Convert.ToDecimal(userid) && x.GROUPID == 125);
                if (user.ToList().Count > 0)
                {
                    empid = user.Where(x => x.EMPID != null).FirstOrDefault().EMPID;
                }
                else if (userid == "284")
                {
                    empid = null;
                }
                else
                {
                    FormsAuthentication.SignOut();
                    Session.Abandon(); // it will clear the session at the end of request



                    HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
                    HttpContext.Response.Cache.SetValidUntilExpires(false);
                    HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
                    HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    HttpContext.Response.Cache.SetNoStore();

                    //base.OnResultExecuting(this.ActionInvoker);


                    return Redirect("http://172.18.0.21/");
                }

                HttpResponseMessage responseMessagedesignation = await client.GetAsync(url + "basicinformation");

                var responseData = responseMessagedesignation.Content.ReadAsStringAsync().Result;
                //var result = (BasicInformaionEntities)null;
                //if(responseData!=null)
                //{
                //    result = JsonConvert.DeserializeObject<BasicInformaionEntities>(responseData);
                //}
                var result = JsonConvert.DeserializeObject<List<BasicInformaionEntities>>(responseData);
                var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                if (userid != null)
                {
                    if (userid == "284")
                    {
                        Session["usernameasset"] = "Super User";
                        Session["userimgasset"] = null;
                    }
                    else
                    {
                        if (empid != null)
                        {
                            Session["usernameasset"] = result.ToList().Where(x => x.ID == Convert.ToDecimal(empid)).FirstOrDefault().EMPLOYEE_FIRSTNAME;
                            Session["userimgasset"] = result.ToList().Where(x => x.ID == Convert.ToDecimal(empid)).FirstOrDefault().EMPIMAGE;
                        }

                    }
                }

            }
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            HttpContext.Response.Cache.SetValidUntilExpires(false);
            HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Response.Cache.SetNoStore();
            return Redirect("http://172.18.0.21/");
        }
	}
}
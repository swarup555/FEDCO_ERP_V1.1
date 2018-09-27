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
using System.Data;
using ExportToExcel;
using System.Collections;
using System.Runtime.Caching;
using System.Web.Security;

namespace FEDCO_ERP_V1._1.Controllers
{
    public class DashboardController : Controller
    {
        HttpClient client;
        private const string CacheKey = "activeemployee";
        ObjectCache cache = MemoryCache.Default;
        string url = System.Configuration.ConfigurationManager.AppSettings["APIUrl"];
        #region Public Constructor
        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
        public DashboardController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion
        //
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
        // GET: /Dashboard/
        public async Task<ActionResult> Index()
        {
            decimal? empid=null;
            var userid = HttpContext.Request.QueryString["id"];
            if (userid != null)
            {
                HttpResponseMessage responseMessageuser = await client.GetAsync(url + "login");
                var responseData1 = responseMessageuser.Content.ReadAsStringAsync().Result;
                var result1 = JsonConvert.DeserializeObject<List<UserEntities>>(responseData1);
                var jsonResult1 = Json(result1, JsonRequestBehavior.AllowGet);
                jsonResult1.MaxJsonLength = int.MaxValue;
                var user = result1.ToList().Where(x => x.USERID == Convert.ToDecimal(userid)&&x.GROUPID==366);
               if(user.ToList().Count>0)
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
                   return Redirect("http://172.18.0.21/");
               }

               
                
            }
                HttpResponseMessage responseMessagedesignation = await client.GetAsync(url + "basicinformation");
                var responseData = responseMessagedesignation.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<List<BasicInformaionEntities>>(responseData);
                var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                if (userid != null)
                {
                    if (userid == "284")
                    {
                        Session["username"] = "Super User";
                        Session["userimg"] = null;
                    }
                    else
                    {
                        if(empid!=null)
                        {
                            Session["username"] = result.ToList().Where(x => x.ID == Convert.ToDecimal(empid)).FirstOrDefault().EMPLOYEE_FIRSTNAME;
                            Session["userimg"] = result.ToList().Where(x => x.ID == Convert.ToDecimal(empid)).FirstOrDefault().EMPIMAGE;
                        }
                       
                    }
                }
             
                if (cache.Contains(CacheKey))
                {
                    cache.Remove(CacheKey);
                    CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
                    cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddDays(1.0);
                    cache.Add(CacheKey, result, cacheItemPolicy);
                }
                else
                {
                    CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
                    cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddDays(1.0);
                    cache.Add(CacheKey, result, cacheItemPolicy);
                }
                var bithdaydata = result.Where(x => x.STATUS == "Active").Where(x => x.DATE_OF_BIRTH.HasValue).ToList().Where(y => y.DATE_OF_BIRTH.Value.Day == System.DateTime.Now.Day && y.DATE_OF_BIRTH.Value.Month == System.DateTime.Now.Month).ToList();
                TempData["bithdaydata"] = bithdaydata;
                TempData["birthday"] = result.Where(x => x.STATUS == "Active").Where(x => x.DATE_OF_BIRTH.HasValue).ToList().Where(y => y.DATE_OF_BIRTH.Value.Day == System.DateTime.Now.Day && y.DATE_OF_BIRTH.Value.Month == System.DateTime.Now.Month).ToList().Count;
                ViewBag.activeemployees = result.Where(x => x.STATUS == "Active").ToList().Where(x => x.STATUS == "Active").ToList().Count;
                ViewBag.fieldemployees = result.Where(x => x.STATUS == "Active").Where(x => x.WORKLOCATION != 1).ToList().Count;
                ViewBag.monthrec = result.Where(x => x.JOINING_DATE.HasValue).ToList().Count(y => y.JOINING_DATE.Value.Month == System.DateTime.Now.Month && y.JOINING_DATE.Value.Year == System.DateTime.Now.Year);
                ViewBag.yearrec = result.Where(x => x.JOINING_DATE.HasValue).ToList().Count(y => y.JOINING_DATE.Value.Year == System.DateTime.Now.Year);
                ViewBag.monsep = result.Where(x => x.EXIT_DATE.HasValue).ToList().Count(y => y.EXIT_DATE.Value.Month == System.DateTime.Now.Month && y.EXIT_DATE.Value.Year == System.DateTime.Now.Year);
                ViewBag.yearsep = result.Where(x => x.EXIT_DATE.HasValue).ToList().Count(y => y.EXIT_DATE.Value.Year == System.DateTime.Now.Year);
                ViewBag.khordha1 = result.Where(x => x.STATUS == "Active").Where(x => x.DIVISION == "000001" && x.WORKLOCATION != 1).ToList().Count;
                ViewBag.nayagarh = result.Where(x => x.STATUS == "Active").Where(x => x.DIVISION == "000002" && x.WORKLOCATION != 1).ToList().Count;
                ViewBag.balungan = result.Where(x => x.STATUS == "Active").Where(x => x.DIVISION == "000003" && x.WORKLOCATION != 1).ToList().Count;
                ViewBag.puriurban = result.Where(x => x.STATUS == "Active").Where(x => x.DIVISION == "000004" && x.WORKLOCATION != 1).ToList().Count;
                ViewBag.purirural = result.Where(x => x.STATUS == "Active").Where(x => x.DIVISION == "000006" && x.WORKLOCATION != 1).ToList().Count;
                ViewBag.khordha2 = result.Where(x => x.STATUS == "Active").Where(x => x.DIVISION == "000007" && x.WORKLOCATION != 1).ToList().Count;
                ViewBag.male = result.Where(x => x.STATUS == "Active").Where(x => x.SEX == "Male").ToList().Count;
                ViewBag.female = result.Where(x => x.STATUS == "Active").Where(x => x.SEX == "Female").ToList().Count;
                ViewBag.corporate = result.Where(x => x.STATUS == "Active").Where(x => x.WORKLOCATION == 1).ToList().Count;
                var today = DateTime.Today;
                // Calculate the age.
                //var agedata = result.Where(x => x.STATUS == "Active");
                //int i = 0;
                //int j = 0;
                //int k = 0;
                //int m = 0;
                //foreach (var item in agedata)
                //{
                //    if (item.DATE_OF_BIRTH != null)
                //    {
                //        var age = today.Year - item.DATE_OF_BIRTH.Value.Year;
                //        if(age>=20&&age<30)
                //        {
                //            i++;
                //        }
                //        if (age >= 30 && age <40)
                //        {
                //            j++;
                //        }
                //        if (age >= 40 && age <50)
                //        {
                //            k++;
                //        }
                //        if (age >= 50 && age <60)
                //        {
                //            m++;
                //        }
                //    }
                   
                //}
                //ViewBag.twenty = i;
                //ViewBag.thirty = j;
                //ViewBag.forty = k;
                //ViewBag.fifty = m;
                var emprec =
                  (from month in Enumerable.Range(0, 12)
                   let key = new { Year = DateTime.Now.Year, Month = DateTime.Now.AddMonths(-month).Month }
                   join revision in result.Where(x => x.JOINING_DATE.HasValue) on key
                equals new
                {
                    revision.JOINING_DATE.Value.Year,
                    revision.JOINING_DATE.Value.Month
                } into g
                   select new { month = key.Month, Count = g.Count() }).ToList().OrderBy(y => y.month);
                ViewBag.jan = emprec.ToList()[0].Count;
                ViewBag.feb = emprec.ToList()[1].Count;
                ViewBag.mar = emprec.ToList()[2].Count;
                ViewBag.apr = emprec.ToList()[3].Count;
                ViewBag.may = emprec.ToList()[4].Count;
                ViewBag.jun = emprec.ToList()[5].Count;
                ViewBag.jul = emprec.ToList()[6].Count;
                ViewBag.aug = emprec.ToList()[7].Count;
                ViewBag.sep = emprec.ToList()[8].Count;
                ViewBag.oct = emprec.ToList()[9].Count;
                ViewBag.nov = emprec.ToList()[10].Count;
                ViewBag.dec = emprec.ToList()[11].Count;
                var empsep =
                 (from month in Enumerable.Range(0, 12)
                  let key = new { Year = DateTime.Now.Year, Month = DateTime.Now.AddMonths(-month).Month }
                  join revision in result.Where(x => x.EXIT_DATE.HasValue) on key
                equals new
                {
                    revision.EXIT_DATE.Value.Year,
                    revision.EXIT_DATE.Value.Month
                } into g
                  select new { month = key.Month, Count = g.Count() }).ToList().OrderBy(y => y.month);
                ViewBag.jansep = empsep.ToList()[0].Count;
                ViewBag.febsep = empsep.ToList()[1].Count;
                ViewBag.marsep = empsep.ToList()[2].Count;
                ViewBag.aprsep = empsep.ToList()[3].Count;
                ViewBag.maysep = empsep.ToList()[4].Count;
                ViewBag.junsep = empsep.ToList()[5].Count;
                ViewBag.julsep = empsep.ToList()[6].Count;
                ViewBag.augsep = empsep.ToList()[7].Count;
                ViewBag.sepsep = empsep.ToList()[8].Count;
                ViewBag.octsep = empsep.ToList()[9].Count;
                ViewBag.novsep = empsep.ToList()[10].Count;
                ViewBag.decsep = empsep.ToList()[11].Count;
                ViewBag.aneg = result.Where(x => x.STATUS == "Active").Where(x => x.BLOOD_GROUP == 4).ToList().Count;
                ViewBag.bneg = result.Where(x => x.STATUS == "Active").Where(x => x.BLOOD_GROUP == 5).ToList().Count;
                ViewBag.apos = result.Where(x => x.STATUS == "Active").Where(x => x.BLOOD_GROUP == 2).ToList().Count;
                ViewBag.bpos = result.Where(x => x.STATUS == "Active").Where(x => x.BLOOD_GROUP == 3).ToList().Count;
                ViewBag.Oneg = result.Where(x => x.STATUS == "Active").Where(x => x.BLOOD_GROUP == 7).ToList().Count;
                ViewBag.opos = result.Where(x => x.STATUS == "Active").Where(x => x.BLOOD_GROUP == 6).ToList().Count;
                //var test = result.Where(x => x.STATUS == "Active").Where(x => x.GRADE == 9).ToList();
                ViewBag.abpos = result.Where(x => x.STATUS == "Active").Where(x => x.BLOOD_GROUP == 8).ToList().Count;
                ViewBag.abneg = result.Where(x => x.STATUS == "Active").Where(x => x.BLOOD_GROUP == 9).ToList().Count;
                ViewBag.oneb = result.Where(x => x.STATUS == "Active").Where(x => x.GRADE == 1).ToList().Count;
                ViewBag.twoa = result.Where(x => x.STATUS == "Active").Where(x => x.GRADE == 2).ToList().Count;
                ViewBag.twob = result.Where(x => x.STATUS == "Active").Where(x => x.GRADE == 3).ToList().Count;
                ViewBag.twoc = result.Where(x => x.STATUS == "Active").Where(x => x.GRADE == 8).ToList().Count;
                ViewBag.thra = result.Where(x => x.STATUS == "Active").Where(x => x.GRADE == 9).ToList().Count;
                ViewBag.fora = result.Where(x => x.STATUS == "Active").Where(x => x.GRADE == 10).ToList().Count;
                ViewBag.forb = result.Where(x => x.STATUS == "Active").Where(x => x.GRADE == 11).ToList().Count;
                ViewBag.fiva = result.Where(x => x.STATUS == "Active").Where(x => x.GRADE == 12).ToList().Count;
                ViewBag.fivb = result.Where(x => x.STATUS == "Active").Where(x => x.GRADE == 13).ToList().Count;
                ViewBag.sixa = result.Where(x => x.STATUS == "Active").Where(x => x.GRADE == 14).ToList().Count;
                ViewBag.sixc = result.Where(x => x.STATUS == "Active").Where(x => x.GRADE == 15).ToList().Count;
                return View(bithdaydata.ToList());
           
           
        }
        public ActionResult BasicInfoactiveemployee()
        {
            var result = (IEnumerable<BasicInformaionEntities>)cache.Get(CacheKey);
            var basicinfo = result.Where(x => x.STATUS == "Active").ToList();
            //var data1 = cache.Get(CacheKey);
            var jsonResult = Json(basicinfo, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            //var result = TempData["fieldemployees"];
            return jsonResult;
        }
        public ActionResult monthlyrecuirtment()
        {
            var result = (IEnumerable<BasicInformaionEntities>)cache.Get(CacheKey);
            //var data1 = cache2.Get(CacheKey2);
            var data1 =result.Where(x => x.JOINING_DATE.HasValue).ToList().Where(y => y.JOINING_DATE.Value.Month == System.DateTime.Now.Month && y.JOINING_DATE.Value.Year == System.DateTime.Now.Year).ToList();
            var jsonResult = Json(data1, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            //var result = TempData["fieldemployees"];
            return jsonResult;
        }
        public ActionResult yearlyrecuirtment()
        {
            var result = (IEnumerable<BasicInformaionEntities>)cache.Get(CacheKey);
            //var data1 = cache3.Get(CacheKey3);
            var data1 = result.Where(x => x.JOINING_DATE.HasValue).ToList().Where(y => y.JOINING_DATE.Value.Year == System.DateTime.Now.Year).ToList();
            var jsonResult = Json(data1, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            //var result = TempData["fieldemployees"];
            return jsonResult;
        }
        public ActionResult monthlyseparation()
        {
            var result = (IEnumerable<BasicInformaionEntities>)cache.Get(CacheKey);
            //var data1 = cache4.Get(CacheKey4);
            var data1 = result.Where(x => x.EXIT_DATE.HasValue).ToList().Where(y => y.EXIT_DATE.Value.Month == System.DateTime.Now.Month && y.EXIT_DATE.Value.Year == System.DateTime.Now.Year).ToList();
            var jsonResult = Json(data1, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            //var result = TempData["fieldemployees"];
            return jsonResult;
        }

        public ActionResult yearlyseparation() 
        {
            var result = (IEnumerable<BasicInformaionEntities>)cache.Get(CacheKey);
            //var data1 = cache5.Get(CacheKey5);
            var data1 = result.Where(x => x.EXIT_DATE.HasValue).ToList().Where(y => y.EXIT_DATE.Value.Year == System.DateTime.Now.Year).ToList();
            var jsonResult = Json(data1, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            //var result = TempData["fieldemployees"];
            return jsonResult;
        }
        public ActionResult feildemployees() 
        {
            var result = (IEnumerable<BasicInformaionEntities>)cache.Get(CacheKey);
            //var data1=cache1.Get(CacheKey1);
            var data1 = result.Where(x => x.STATUS == "Active").Where(x => x.WORKLOCATION != 1).ToList();
            var jsonResult = Json(data1, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            //var result = TempData["fieldemployees"];
            return jsonResult;
        }
        public ActionResult khordha1()
        {
            var result = (IEnumerable<BasicInformaionEntities>)cache.Get(CacheKey);
            var data1 = result.Where(x => x.STATUS == "Active").Where(x => x.DIVISION == "000001" && x.WORKLOCATION != 1).ToList();
            //var data1 = cache6.Get(CacheKey6);
            var jsonResult = Json(data1, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            //var result = TempData["fieldemployees"];
            return jsonResult;
        }
        public ActionResult nayagarh()
        {
            var result = (IEnumerable<BasicInformaionEntities>)cache.Get(CacheKey);
            //var data1 = cache7.Get(CacheKey7);
            var data1 = result.Where(x => x.STATUS == "Active").Where(x => x.DIVISION == "000002" && x.WORKLOCATION != 1).ToList();
            var jsonResult = Json(data1, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            //var result = TempData["fieldemployees"];
            return jsonResult;
        }
        public ActionResult balungan()
        {
            var result = (IEnumerable<BasicInformaionEntities>)cache.Get(CacheKey);
            //var data1 = cache8.Get(CacheKey8);
            var data1 = result.Where(x => x.STATUS == "Active").Where(x => x.DIVISION == "000003" && x.WORKLOCATION != 1).ToList();
            var jsonResult = Json(data1, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            //var result = TempData["fieldemployees"];
            return jsonResult;
        }
        public ActionResult puriurban()
        {
            var result = (IEnumerable<BasicInformaionEntities>)cache.Get(CacheKey);
            //var data1 = cache9.Get(CacheKey9);
            var data1 = result.Where(x => x.STATUS == "Active").Where(x => x.DIVISION == "000004" && x.WORKLOCATION != 1).ToList();
            var jsonResult = Json(data1, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            //var result = TempData["fieldemployees"];
            return jsonResult;
        }
        public ActionResult purirural()
        {
            var result = (IEnumerable<BasicInformaionEntities>)cache.Get(CacheKey);
            //var data1 = cache10.Get(CacheKey10);
            var data1 = result.Where(x => x.STATUS == "Active").Where(x => x.DIVISION == "000006" && x.WORKLOCATION != 1).ToList();
            var jsonResult = Json(data1, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            //var result = TempData["fieldemployees"];
            return jsonResult;
        }
        public ActionResult khordha2()
        {
            var result = (IEnumerable<BasicInformaionEntities>)cache.Get(CacheKey);
            //var data1 = cache11.Get(CacheKey11);
            var data1 = result.Where(x => x.STATUS == "Active").Where(x => x.DIVISION == "000007" && x.WORKLOCATION != 1).ToList();
            var jsonResult = Json(data1, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            //var result = TempData["fieldemployees"];
            return jsonResult;
        }
        public ActionResult corporate()
        {
            var result = (IEnumerable<BasicInformaionEntities>)cache.Get(CacheKey);
            //var data1 = cache20.Get(CacheKey20);
            var data1 = result.Where(x => x.STATUS == "Active").Where(x => x.WORKLOCATION == 1).ToList();
            var jsonResult = Json(data1, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            //var result = TempData["fieldemployees"];
            return jsonResult;
        }
       
        public ActionResult aneg()
        {
            var result = (IEnumerable<BasicInformaionEntities>)cache.Get(CacheKey);
            //var data1 = cache12.Get(CacheKey12);
            var aneg = result.Where(x => x.STATUS == "Active").Where(x => x.BLOOD_GROUP == 4).ToList();
            var jsonResult = Json(aneg, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            //var result = TempData["fieldemployees"];
            return jsonResult;
        }
        public ActionResult bneg()
        {
            var result = (IEnumerable<BasicInformaionEntities>)cache.Get(CacheKey);
            //var data1 = cache13.Get(CacheKey13);
            var bneg = result.Where(x => x.STATUS == "Active").Where(x => x.BLOOD_GROUP == 5).ToList();
            var jsonResult = Json(bneg, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            //var result = TempData["fieldemployees"];
            return jsonResult;
        }
        public ActionResult apos()
        {
            var result = (IEnumerable<BasicInformaionEntities>)cache.Get(CacheKey);
            //var data1 = cache14.Get(CacheKey14);
            var apos = result.Where(x => x.STATUS == "Active").Where(x => x.BLOOD_GROUP == 2).ToList();
            var jsonResult = Json(apos, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            //var result = TempData["fieldemployees"];
            return jsonResult;
        }
        public ActionResult bpos()
        {
            var result = (IEnumerable<BasicInformaionEntities>)cache.Get(CacheKey);
            //var data1 = cache15.Get(CacheKey15);
            var bpos = result.Where(x => x.STATUS == "Active").Where(x => x.BLOOD_GROUP == 3).ToList();
            var jsonResult = Json(bpos, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            //var result = TempData["fieldemployees"];
            return jsonResult;
        }
        public ActionResult oneg()
        {
            var result = (IEnumerable<BasicInformaionEntities>)cache.Get(CacheKey);
            //var data1 = cache16.Get(CacheKey16);
            var oneg = result.Where(x => x.STATUS == "Active").Where(x => x.BLOOD_GROUP == 7).ToList();
            var jsonResult = Json(oneg, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            //var result = TempData["fieldemployees"];
            return jsonResult;
        }
        public ActionResult opos()
        {
            var result = (IEnumerable<BasicInformaionEntities>)cache.Get(CacheKey);
            //var data1 = cache17.Get(CacheKey17);
            var opos = result.Where(x => x.STATUS == "Active").Where(x => x.BLOOD_GROUP == 6).ToList();
            var jsonResult = Json(opos, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            //var result = TempData["fieldemployees"];
            return jsonResult;
        }
        public ActionResult abpos()
        {
            var result = (IEnumerable<BasicInformaionEntities>)cache.Get(CacheKey);
            //var data1 = cache18.Get(CacheKey18);
            var abpos = result.Where(x => x.STATUS == "Active").Where(x => x.BLOOD_GROUP == 8).ToList();
            var jsonResult = Json(abpos, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            //var result = TempData["fieldemployees"];
            return jsonResult;
        }
        public ActionResult abneg()
        {
            var result = (IEnumerable<BasicInformaionEntities>)cache.Get(CacheKey);
            var data1 = result.Where(x => x.STATUS == "Active").Where(x => x.BLOOD_GROUP == 9).ToList();
            //var data1 = cache19.Get(CacheKey19);
            var jsonResult = Json(data1, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            //var result = TempData["fieldemployees"];
            return jsonResult;
        }
        public ActionResult test(decimal id)
        {
            Session["depid"] = null;
            Session.Remove("depid");
            Session["depid"] = id;
            var result = (IEnumerable<BasicInformaionEntities>)cache.Get(CacheKey);
            var data1 = result.Where(x => x.STATUS == "Active").Where(x => x.DEPARTMENT ==id).ToList();
            var query = from r in data1
                        group r by new { r.designationname } into nameGroup
                        select new
                        {
                            Name = nameGroup.Key.designationname,
                            count = nameGroup.Count()
                        };
            //var data1 = cache19.Get(CacheKey19);
            var jsonResult = Json(query, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            //var result = TempData["fieldemployees"];
            return jsonResult;
        }
        public ActionResult test1(string id)
        {
            var result = (IEnumerable<BasicInformaionEntities>)cache.Get(CacheKey);
            var data1 = result.Where(x => x.STATUS == "Active").Where(x => x.designationname == id).Where(x => x.DEPARTMENT ==Convert.ToDecimal(Session["depid"].ToString())).ToList();
            //var data1 = cache19.Get(CacheKey19);
            var jsonResult = Json(data1, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            //var result = TempData["fieldemployees"];
            return jsonResult;
        }
        public ActionResult _notification()
        {
           
            var result = TempData["bithdaydata"];

            //var bithdaydata = result.Where(x => x.DATE_OF_BIRTH.HasValue).ToList().Where(y => y.DATE_OF_BIRTH.Value.Day == System.DateTime.Now.Day && y.DATE_OF_BIRTH.Value.Month == System.DateTime.Now.Month).ToList();
            return PartialView("_notification", result);
        }
        public ActionResult GetEmployeeInfofilter(string WORKLOCATIONs, string divisions, string subdivisions, string sections, string departments, string designation,string grade)
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
                if (divisions != "0" )
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
                var jsonResult = Json(results, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
        }

        public void ExportGridToExcel(HttpContext context)
        {
            string tabData = context.Request["excelData"];

            DataTable dt = ConvertCsvData(tabData);
            if (dt == null)
            {
                //  Add some error-catching here...
                return ;
            }

            string excelFilename = context.Request["filename"];

            if (System.IO.File.Exists(excelFilename))
                System.IO.File.Delete(excelFilename);

            CreateExcelFile.CreateExcelDocument(dt, excelFilename, context.Response);
           
        }
        private DataTable ConvertCsvData(string CSVdata)
        {
            //  Convert a tab-separated set of data into a DataTable, ready for our C# CreateExcelFile libraries
            //  to turn into an Excel file.
            //
            DataTable dt = new DataTable();
            try
            {
                System.Diagnostics.Trace.WriteLine(CSVdata);

                string[] Lines = CSVdata.Split(new char[] { '\r', '\n' });
                if (Lines == null)
                    return dt;
                if (Lines.GetLength(0) == 0)
                    return dt;

                string[] HeaderText = Lines[0].Split('\t');

                int numOfColumns = HeaderText.Count();


                foreach (string header in HeaderText)
                    dt.Columns.Add(header, typeof(string));

                DataRow Row;
                for (int i = 1; i < Lines.GetLength(0); i++)
                {
                    string[] Fields = Lines[i].Split('\t');
                    if (Fields.GetLength(0) == numOfColumns)
                    {
                        Row = dt.NewRow();
                        for (int f = 0; f < numOfColumns; f++)
                            Row[f] = Fields[f];
                        dt.Rows.Add(Row);
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("An exception occurred: " + ex.Message);
                return null;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        //public async Task<List<BasicInformaionEntities>> getdata()
        //{
        //    HttpResponseMessage responseMessagedesignation = await client.GetAsync(url + "basicinformation");

        //    var responseData = responseMessagedesignation.Content.ReadAsStringAsync().Result;
        //    var result = JsonConvert.DeserializeObject<List<BasicInformaionEntities>>(responseData);
        //    var bithdaydata = result.Where(x => x.DATE_OF_BIRTH.HasValue).ToList().Where(y => y.DATE_OF_BIRTH.Value.Day == System.DateTime.Now.Day && y.DATE_OF_BIRTH.Value.Month == System.DateTime.Now.Month).ToList();
        //    return result.ToList();
        //}
    }
}
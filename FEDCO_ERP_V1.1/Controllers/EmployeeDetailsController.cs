

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


namespace FEDCO_ERP_V1._1.Controllers
{
    public class EmployeeDetailsController : Controller
    {
        private const string CacheKey = "tra";
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
        public EmployeeDetailsController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion

       
        public async Task<ActionResult> basicinformation()
        {

            HttpResponseMessage responseMessagecomdtls = await client.GetAsync(url + "basicinformation/" + Convert.ToInt32(Session["urlid"]));
            if (responseMessagecomdtls.IsSuccessStatusCode)
            {
                var responseData = responseMessagecomdtls.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<BasicInformaionEntities>>(responseData);

                //var comdtls = result.ToList().FirstOrDefault();

                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return View();
        }
        public async Task<ActionResult> comunicationdtls()
        {

            HttpResponseMessage responseMessagecomdtls = await client.GetAsync(url + "communicatidetails/" + Convert.ToInt32(Session["urlid"]));
            if (responseMessagecomdtls.IsSuccessStatusCode)
            {
                var responseData = responseMessagecomdtls.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<CommunicationDetailsEntities>>(responseData);

                //var comdtls = result.ToList().FirstOrDefault();

                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return View();
        }
        public async Task<ActionResult> qualificationdtls()
        {

            HttpResponseMessage responseMessagequalificationdtls = await client.GetAsync(url + "qualificationdetails/" + Convert.ToInt32(Session["urlid"]));
            if (responseMessagequalificationdtls.IsSuccessStatusCode)
            {
                var responseData = responseMessagequalificationdtls.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<QualificationDetailsEntities>>(responseData);

                //var comdtls = result.ToList().FirstOrDefault();

                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return View();
        }
        public async Task<ActionResult> employmentdetails()
        {

            HttpResponseMessage responseMessageemploymentdetails = await client.GetAsync(url + "employment/" + Convert.ToInt32(Session["urlid"]));
            if (responseMessageemploymentdetails.IsSuccessStatusCode)
            {
                var responseData = responseMessageemploymentdetails.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<EmploymentEntities>>(responseData);

                //var comdtls = result.ToList().FirstOrDefault();

                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return View();
        }
        public async Task<ActionResult> relationshipdtls()
        {

            HttpResponseMessage responseMessagerelationshipdtls = await client.GetAsync(url + "relationship/" + Convert.ToInt32(Session["urlid"]));
            if (responseMessagerelationshipdtls.IsSuccessStatusCode)
            {
                var responseData = responseMessagerelationshipdtls.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<RelationshipDetailEntities>>(responseData);

                //var comdtls = result.ToList().FirstOrDefault();

                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return View();
        }
        public async Task<ActionResult> Assetdtls()
        {

            HttpResponseMessage responseMessageAssetdtls = await client.GetAsync(url + "assetdetails/" + Convert.ToInt32(Session["urlid"]));
            if (responseMessageAssetdtls.IsSuccessStatusCode)
            {
                var responseData = responseMessageAssetdtls.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<AssetDetailsEntities>>(responseData);

                //var comdtls = result.ToList().FirstOrDefault();

                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return View();
        }
        public async Task<ActionResult> PIPDtls()
        {

            HttpResponseMessage responseMessagePIPDtls = await client.GetAsync(url + "pipdetails/" + Convert.ToInt32(Session["urlid"]));
            if (responseMessagePIPDtls.IsSuccessStatusCode)
            {
                var responseData = responseMessagePIPDtls.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<PIPDeatilsEntities>>(responseData);

                //var comdtls = result.ToList().FirstOrDefault();

                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return View();
        }
        public async Task<ActionResult> AccountDetails()
        {

            HttpResponseMessage responseMessagePIPDtls = await client.GetAsync(url + "salarydetails/" + Convert.ToInt32(Session["urlid"]));
            if (responseMessagePIPDtls.IsSuccessStatusCode)
            {
                var responseData = responseMessagePIPDtls.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<EmpAcountEntity>>(responseData);

                //var comdtls = result.ToList().FirstOrDefault();

                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return View();
        }
        public async Task<ActionResult> TransferDetails()
        {

            HttpResponseMessage responseMessagePIPDtls = await client.GetAsync(url + "transferdetails/" + Convert.ToInt32(Session["urlid"]));
            if (responseMessagePIPDtls.IsSuccessStatusCode)
            {
                var responseData = responseMessagePIPDtls.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<TransferdetailsEntities>>(responseData);
                TempData["trdata"] = result;
                //var comdtls = result.ToList().FirstOrDefault();
                if (cache.Contains(CacheKey))
                {
                    cache.Remove(CacheKey);
                    CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
                    cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddHours(1.0);
                    cache.Add(CacheKey, result, cacheItemPolicy);
                }
                else
                {
                    CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
                    cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddHours(1.0);
                    cache.Add(CacheKey, result, cacheItemPolicy);
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return View();
        }
        public async Task<ActionResult> boardtype()
        {

            HttpResponseMessage responseMessageboardtype = await client.GetAsync(url + "boardtype");
            if (responseMessageboardtype.IsSuccessStatusCode)
            {
                var responseData = responseMessageboardtype.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<BoardEntities>>(responseData);

                //var comdtls = result.ToList().FirstOrDefault();

                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return View();
        }

        public async Task<ActionResult> degretype()
        {

            HttpResponseMessage responseMessagedegretype = await client.GetAsync(url + "degreetype");
            if (responseMessagedegretype.IsSuccessStatusCode)
            {
                var responseData = responseMessagedegretype.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<DegreeTypeEntities>>(responseData);

                //var comdtls = result.ToList().FirstOrDefault();

                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return View();
        }
        public async Task<ActionResult> BasicInfos()
        {

            HttpResponseMessage responseMessagedesignation = await client.GetAsync(url + "basicinformation");
            if (responseMessagedesignation.IsSuccessStatusCode)
            {
                var responseData = responseMessagedesignation.Content.ReadAsStringAsync().Result;
                //var serializer = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue, RecursionLimit = 100 };
                //Response.Write(new ScriptingJsonSerializationSection().MaxJsonLength);
                var result = JsonConvert.DeserializeObject<List<BasicInformaionEntities>>(responseData);
                //return new ContentResult()
                //{
                //    Content = serializer.Serialize(responseData),
                //    ContentType = "application/json",
                //};
                //result.MaxJsonLength = int.MaxValue;

                var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
                //JsonResult result = new JsonResult();
                //result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

                //result.Data = new
                //{
                //    total = 5,  //total number of pages in our grid
                //    page = 1,   //page to show in the grid,
                //    records = 500, //how many records we are dealing with
                //    rows = JsonConvert.SerializeObject(responseData) //our actual data
                //};
                //return result;
                //JavaScriptSerializer serializer = new JavaScriptSerializer();
                //serializer.MaxJsonLength = 2147483647;
                //object jsonData = serializer.DeserializeObject(responseData);
                //return jsonData;
                //return Json(jsonData, JsonRequestBehavior.AllowGet);
            }

            return View();
        }


        public async Task<ActionResult> BasicInfosearch(string id)
        {

            HttpResponseMessage responseMessagedesignation = await client.GetAsync(url + "basicinformation");
            if (responseMessagedesignation.IsSuccessStatusCode)
            {
                var responseData = responseMessagedesignation.Content.ReadAsStringAsync().Result;


                var result = JsonConvert.DeserializeObject<List<BasicInformaionEntities>>(responseData).Where(x=>x.EMPLOYEE_FIRSTNAME!=null&&x.EMPLOYEE_CODE!=null).ToList().Where(y=>y.EMPLOYEE_FIRSTNAME.Contains(id)||y.EMPLOYEE_CODE.Contains(id));


                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return View();
        }

        //async Actions Methods for get Grades dropdown
        public async Task<ActionResult> Grades()
        {

            HttpResponseMessage responseMessagedesignation = await client.GetAsync(url + "grade");
            if (responseMessagedesignation.IsSuccessStatusCode)
            {
                var responseData = responseMessagedesignation.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<GradeEnities>>(responseData);

                var ddldesignation = result.ToList().Select(c => new SelectListItem
                {
                    Text = c.GRADE_NAME,
                    Value = c.ID.ToString()

                }).ToList();

                ViewBag.designations = ddldesignation;
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return View();
        }

        public async Task<ActionResult> Transferlocation()
        {

            HttpResponseMessage responseMessagedesignation = await client.GetAsync(url + "location");
            if (responseMessagedesignation.IsSuccessStatusCode)
            {
                var responseData = responseMessagedesignation.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<LocationEntities>>(responseData);
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return View();
        }
        //async Actions Methods for get FnFStatus dropdown
        public ActionResult FnFStatus()
        {

            List<string> iList = new List<string>();
            iList.Add("CHECK");
            iList.Add("GIVEN");
            iList.Add("YES");
            iList.Add("NO");


            var result = iList.ToList().Select(c2 => new SelectListItem
            {
                Text = c2.ToString(),

                Value = c2.ToString(),

            }).ToList();



            return Json(iList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult period()
        {

            List<string> iList = new List<string>();
            iList.Add("1");
            iList.Add("2");
            iList.Add("3");

            var result = iList.ToList().Select(c2 => new SelectListItem
            {
                Text = c2.ToString(),

                Value = c2.ToString(),

            }).ToList();



            return Json(iList, JsonRequestBehavior.AllowGet);
        }
        public ActionResult trnsferstatus()
        {
            List<string> iList = new List<string>();
            iList.Add("ACTIVE");
            iList.Add("INACTIVE");
            var result = iList.ToList().Select(c2 => new SelectListItem
            {
                Text = c2.ToString(),
                Value = c2.ToString(),
            }).ToList();
            return Json(iList, JsonRequestBehavior.AllowGet);
        }
        //async Actions Methods for get ExitTypes dropdown
        public async Task<ActionResult> ExitTypes()
        {

            HttpResponseMessage responseMessageexittype = await client.GetAsync(url + "exittype");
            if (responseMessageexittype.IsSuccessStatusCode)
            {
                var responseData = responseMessageexittype.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<ExitTypeEntities>>(responseData);

                var ddlexittype = result.ToList().Select(c => new SelectListItem
                {
                    Text = c.EXITTYPE_NAME,
                    Value = c.ID.ToString()

                }).ToList();

                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return View();
        }
        //async Actions Methods for get Designations dropdown
        public async Task<ActionResult> Designations()
        {

            HttpResponseMessage responseMessagedesignation = await client.GetAsync(url + "designation");
            if (responseMessagedesignation.IsSuccessStatusCode)
            {
                var responseData = responseMessagedesignation.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<DesignationEntities>>(responseData);

                var ddldesignation = result.ToList().Select(c => new SelectListItem
                {
                    Text = c.DESIGNATION_NAME,
                    Value = c.ID.ToString()

                }).ToList();

                ViewBag.designations = ddldesignation;
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return View();
        }
        //async Actions Methods for get BloodGroups dropdown
        public async Task<ActionResult> BloodGroups()
        {

            HttpResponseMessage responseMessagebloodgroup = await client.GetAsync(url + "bloodgroup");
            if (responseMessagebloodgroup.IsSuccessStatusCode)
            {
                var responseData = responseMessagebloodgroup.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<BloodGroupEntities>>(responseData);

                var ddlbloodgroup = result.ToList().Select(c => new SelectListItem
                {
                    Text = c.BLOODGROUP_NAME,
                    Value = c.ID.ToString()

                }).ToList();

                ViewBag.bloodgroups = ddlbloodgroup;



                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return View();
        }
        public async Task<ActionResult> Country()
        {

            HttpResponseMessage responseMessagedivision = await client.GetAsync(url + "country");
            if (responseMessagedivision.IsSuccessStatusCode)
            {
                var responseData = responseMessagedivision.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<CountryEntities>>(responseData);

                var ddlCountry = result.ToList().Select(c => new SelectListItem
                {
                    Text = c.COUNTRY_NAME,
                    Value = c.ID.ToString()

                }).ToList();

                ViewBag.country = ddlCountry;



                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return View();
        }
        public async Task<ActionResult> state()
        {

            HttpResponseMessage responseMessagedivision = await client.GetAsync(url + "state");
            if (responseMessagedivision.IsSuccessStatusCode)
            {
                var responseData = responseMessagedivision.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<StateEntities>>(responseData);

                var ddlstate = result.ToList().Select(c => new SelectListItem
                {
                    Text = c.STATE_NAME,
                    Value = c.ID.ToString()

                }).ToList();

                ViewBag.country = ddlstate;



                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return View();
        }
        public ActionResult CVType()
        {
            List<string> iList = new List<string>();
            iList.Add("Desk");
            iList.Add("Fedco Career");
            iList.Add("Naukri");
            iList.Add("Employee Referral");
            iList.Add("Client Referral");
            iList.Add("Campus Recruitment");
            return Json(iList, JsonRequestBehavior.AllowGet);
        }
        public ActionResult HiringType()
        {
            List<string> iList = new List<string>();
            iList.Add("New");
            iList.Add("Replacement");
            return Json(iList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> PostMpFormData()
        {

            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    //WebImage img = new WebImage(file.InputStream);
                    //if (img.Width > 1000)
                    //{
                    //    img.Resize(200, 200);
                    //}

                    var fileName = Path.GetFileName(file.FileName);
                    Random r = new Random();
                    string code = r.Next().ToString();
                    var path = Path.Combine(Server.MapPath("/images/"), Session["urlid"].ToString() + "_" +code+fileName);
                    //var path = Path.Combine(Server.MapPath("~~/images/"),fileName);
                    //TempData["url"] = Server.MapPath(@"~\images") + "\\" + Path.GetFileName(file.FileName);
                    file.SaveAs(path);
                   
                    using (HttpClient client = new HttpClient())
                    {


                        //HttpResponseMessage result = new HttpResponseMessage();
                        using (var content = new MultipartFormDataContent())
                        {
                            var values = new[]
        {
            new KeyValuePair<string, string>("Foo", "Bar"),
            new KeyValuePair<string, string>("More", "Less"),
        };

                            foreach (var keyValuePair in values)
                            {
                                content.Add(new StringContent(keyValuePair.Value), keyValuePair.Key);
                            }

                            var fileContent = new ByteArrayContent(System.IO.File.ReadAllBytes(path));
                            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                            {
                                FileName = Session["urlid"].ToString() + "_" + file.FileName
                            };
                            content.Add(fileContent);

                            var requestUri = url + "mpformdata";
                            var result = client.PostAsync(requestUri, content).Result;
                        }
                    }
                }


                //DirectoryInfo dir = new DirectoryInfo(Server.MapPath(@"~\images"));
                //var files = dir.GetFiles().ToList();


                //HttpResponseMessage result = new HttpResponseMessage();
                //using (MultipartFormDataContent mpfdc = new MultipartFormDataContent())
                //{
                //    foreach (var file in files)
                //    {
                //        mpfdc.Add(new StreamContent(file.OpenRead()), "File", file.Name);
                //    }
                //    //HttpResponseMessage responseMessagedesignation = await client.GetAsync(url + "basicinformation");

                //    //  var requestUri = ConfigurationManager.AppSettings["DocumentConverterUrl"] + "/api/mpformdata";

                //    var requestUri = url + "mpformdata";
                //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("multipart/form-data"));
                //    result = client.PostAsync(requestUri, mpfdc).Result;
                //}

                //ViewBag.ResultStatusCode = result.StatusCode;
                //ViewBag.ContentLength = result.Content.Headers.ContentLength;

                //// Fiddler show that it returns multipartform content, but how do I use it?
                //var resultContent = result.Content;
                return RedirectToAction("Index", "EmployeeDetails", new { id = Session["urlid"].ToString() });
            }



            return RedirectToAction("Index", "EmployeeDetails", new { id = Session["urlid"].ToString() });

        }
        //async Actions Methods for get Departments dropdown
        public async Task<ActionResult> Departments()
        {

            HttpResponseMessage responseMessageDepartment = await client.GetAsync(url + "department");
            if (responseMessageDepartment.IsSuccessStatusCode)
            {
                var responseData = responseMessageDepartment.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<DepartmentEntities>>(responseData);

                var ddldepartment = result.ToList().Select(c => new SelectListItem
                {
                    Text = c.DEPARTMENT_NAME,
                    Value = c.ID.ToString()

                }).ToList();

                ViewBag.departments = ddldepartment;
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return View();
        }
        //async Actions Methods for get ReporingTo dropdown
        public async Task<ActionResult> ReporingTo(string id)
        {

            HttpResponseMessage responseMessageReportingPerson = await client.GetAsync(url + "reportingperson/" + id);
            if (responseMessageReportingPerson.IsSuccessStatusCode)
            {
                var responseData = responseMessageReportingPerson.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<Reportingentities>>(responseData);

                var ddlreportingperson = result.ToList().Select(c => new SelectListItem
                {
                    Text = c.REPORTING_PERSON_NAME,
                    Value = c.ID.ToString()

                }).ToList();

                ViewBag.reportingpersons = ddlreportingperson;

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return View();
        }
        //async Actions Methods for get Divisions dropdown
        public async Task<ActionResult> Divisions()
        {

            HttpResponseMessage responseMessagedivision = await client.GetAsync(url + "division");
            if (responseMessagedivision.IsSuccessStatusCode)
            {
                var responseData = responseMessagedivision.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<DIVISION>>(responseData);

                var ddldivision = result.ToList().Select(c => new SelectListItem
                {
                    Text = c.DIV_NAME,
                    Value = c.DIVISION_CODE.ToString()

                }).ToList();

                ViewBag.divisions = ddldivision;



                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return View();
        }
        //async Actions Methods for get SubDivisions dropdown
        public async Task<ActionResult> SubDivisions(string id)
        {

            HttpResponseMessage responseMessagesubdivision = await client.GetAsync(url + "subdivision/" + id);

            if (responseMessagesubdivision.IsSuccessStatusCode)
            {
                var responseData = responseMessagesubdivision.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<SubDivisionEntities>>(responseData);

                var ddlsubdivision = result.ToList().Select(c => new SelectListItem
                {
                    Text = c.SUB_DIV_NAME,
                    Value = c.SUB_DIV_CODE.ToString()

                }).ToList();

                ViewBag.subdivisions = ddlsubdivision;




                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return View();
        }
        //async Actions Methods for get Sections dropdown
        public async Task<ActionResult> Sections(string id)
        {

            HttpResponseMessage responseMessagesection = await client.GetAsync(url + "section/" + id);

            if (responseMessagesection.IsSuccessStatusCode)
            {
                var responseData = responseMessagesection.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<SectionEntities>>(responseData);

                var ddlsection = result.ToList().Select(c => new SelectListItem
                {
                    Text = c.SEC_NAME,
                    Value = c.SEC_CODE.ToString()

                }).ToList();

                ViewBag.sections = ddlsection;




                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return View();
        }
        public async Task<ActionResult> exitTypecategory(int id)
        {

            HttpResponseMessage responseMessagesection = await client.GetAsync(url + "exittypecategory/" + id);

            if (responseMessagesection.IsSuccessStatusCode)
            {
                var responseData = responseMessagesection.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<ExitcatagoryEntities>>(responseData);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return View();
        }
        //
        // GET: /EmployeeDetails/
        public async Task<ActionResult> Index(string id = null)
        {
            Session["urlid"] = null;
            Session.Remove("urlid");
            //Session["urlid"] = id;
            if (id != null)
            {
                Session["urlid"] = id;
                HttpResponseMessage responseMessagedesignation = await client.GetAsync(url + "basicinformation" + "/" + id);
                if (responseMessagedesignation.IsSuccessStatusCode)
                {
                    var responseData = responseMessagedesignation.Content.ReadAsStringAsync().Result;

                    var result = JsonConvert.DeserializeObject<List<BasicInformaionEntities>>(responseData);
                    //////////List<BasicInformaionEntities> objmodel = new List<BasicInformaionEntities>();
                    //objmodel = result;
                    //TempData["bi"] = result.ToList();
                    //  TBL_EMP_BASICINFO bie = new HRMSEntities().TBL_EMP_BASICINFO.Find(Convert.ToInt32(Session["urlid"]));

                    BasicInformaionEntities bie = new BasicInformaionEntities();
                    bie.EMPLOYEE_FIRSTNAME = result.ToList()[0].EMPLOYEE_FIRSTNAME;
                    bie.EMPLOYEE_LASTNAME = result.ToList()[0].EMPLOYEE_LASTNAME;
                    bie.EMPLOYEE_MIDDLENAME = result.ToList()[0].EMPLOYEE_MIDDLENAME;

                    bie.DOMICILE_STATUS = result.ToList()[0].DOMICILE_STATUS;

                    bie.EMPLOYEE_IMAGE = result.ToList()[0].EMPLOYEE_IMAGE;
                    bie.designationname = result.ToList()[0].designationname;
                    bie.DESIGNATION = result.ToList()[0].DESIGNATION;
                    bie.SUBDIVISION = result.ToList()[0].SUBDIVISION;
                    bie.DIVISION = result.ToList()[0].DIVISION;
                    bie.SECTION = result.ToList()[0].SECTION;
                    bie.DEPARTMENT = result.ToList()[0].DEPARTMENT;
                    bie.REPORTING_TO = result.ToList()[0].REPORTING_TO;
                    bie.EMPLOYEE_FULLNAME = result.ToList()[0].EMPLOYEE_FULLNAME;



                    //bie.JOINING_DATE = DateTime.ParseExact(result.ToList()[0].JOINING_DATE.Value.Date.ToString("dd/mm/yyyy"), "dd/mm/yyyy", null); ;
                    bie.DATE_OF_BIRTH = result.ToList()[0].DATE_OF_BIRTH;

                    bie.AGE = result.ToList()[0].AGE;
                    bie.DOMICILE_STATUS = result.ToList()[0].DOMICILE_STATUS;

                    bie.SEX = result.ToList()[0].SEX;
                    bie.MATERIAL_STATUS = result.ToList()[0].MATERIAL_STATUS;

                    bie.WEDDING_ANNIVERSARY = result.ToList()[0].WEDDING_ANNIVERSARY;
                    bie.GRADE = result.ToList()[0].GRADE;
                    bie.BLOOD_GROUP = result.ToList()[0].BLOOD_GROUP;





                    bie.HEIGHT = result.ToList()[0].HEIGHT;
                    bie.WEIGHT = result.ToList()[0].WEIGHT;
                    bie.ESIC_NO = result.ToList()[0].ESIC_NO;
                    bie.PF_UNID_NUMBER = result.ToList()[0].PF_UNID_NUMBER;

                    bie.MEDICLAIM_NUMBER = result.ToList()[0].MEDICLAIM_NUMBER;
                    bie.INDUCTION = result.ToList()[0].INDUCTION;
                    bie.IDENTIFICATION_MARK = result.ToList()[0].IDENTIFICATION_MARK;
                    bie.LAST_MAJOR_ILLNESS_SURGERY = result.ToList()[0].LAST_MAJOR_ILLNESS_SURGERY;
                    bie.PHYSICAL_DISABILITY = result.ToList()[0].PHYSICAL_DISABILITY;


                    bie.HIRING_TYPE = result.ToList()[0].HIRING_TYPE;
                    bie.CV_TYPE = result.ToList()[0].CV_TYPE;
                    bie.YEAR_OF_EXPERIENCE = result.ToList()[0].YEAR_OF_EXPERIENCE;
                    bie.EXIT_DATE = result.ToList()[0].EXIT_DATE;

                    bie.EXIT_TYPE = result.ToList()[0].EXIT_TYPE;
                    bie.REFERENCE = result.ToList()[0].REFERENCE;
                    bie.FULL_N_FINAL_STATUS = result.ToList()[0].FULL_N_FINAL_STATUS;

                    bie.WORKLOCATION = result.ToList()[0].WORKLOCATION;
                    bie.DIVISIONNAME = result.ToList()[0].DIVISIONNAME;
                    bie.SUB_DIVISIONNAME = result.ToList()[0].SUB_DIVISIONNAME;
                    bie.SECTIONNAME = result.ToList()[0].SECTIONNAME;
                    bie.EMPIMAGE = result.ToList()[0].EMPIMAGE;
                    //FULL_N_FINAL_STATUS: $('#fnf').val()
                    if (bie.FULL_N_FINAL_STATUS != null)
                    {
                        TempData["status"] = bie.FULL_N_FINAL_STATUS;
                    }

                    if (bie.JOINING_DATE != null)
                    {
                        TempData["period"] = bie.JOINING_DATE + "--" + bie.EXIT_DATE;
                    }

                   
                    if (bie.DIVISIONNAME != null )
                    {
                        TempData["fulladdress"] = bie.DIVISIONNAME;
                    }
                    if (bie.SUB_DIVISIONNAME != null)
                    {
                        TempData["fulladdress"] = bie.SUB_DIVISIONNAME;
                    }
                    if (bie.SECTIONNAME != null)
                    {
                        TempData["fulladdress"] = bie.SECTIONNAME;
                    }
                    if (bie.DIVISIONNAME != null && bie.SUB_DIVISIONNAME != null)
                    {
                        TempData["fulladdress"] = bie.DIVISIONNAME + "," + bie.SUB_DIVISIONNAME ;
                    }
                    if (bie.DIVISIONNAME != null && bie.SUB_DIVISIONNAME != null && bie.SECTIONNAME != null)
                    {
                        TempData["fulladdress"] = bie.DIVISIONNAME + "," + bie.SUB_DIVISIONNAME + "," + bie.SECTIONNAME;
                    }
                    if (bie.WORKLOCATION == Convert.ToDecimal(5))
                    {
                        TempData["fulladdress"] = "Khordha";
                    }
                    else if (bie.WORKLOCATION == Convert.ToDecimal(1))
                    {
                        TempData["fulladdress"] = "Fortune Tower , Bhubaneswar";
                    }
                    else if (bie.WORKLOCATION == Convert.ToDecimal(7))
                    {
                        TempData["fulladdress"] = "Project Office";
                    }
                    else if (bie.WORKLOCATION == Convert.ToDecimal(8))
                    {
                        TempData["fulladdress"] = "Kandhamal";
                    }
                    else if (bie.WORKLOCATION == Convert.ToDecimal(9))
                    {
                        TempData["fulladdress"] = "Gurgaon";
                    }
                    else if (bie.WORKLOCATION == Convert.ToDecimal(15))
                    {
                        TempData["fulladdress"] = "Mumbai";
                    }
                    else if (bie.WORKLOCATION == Convert.ToDecimal(11))
                    {
                        TempData["fulladdress"] = "puri";
                    }
                    else if (bie.WORKLOCATION == Convert.ToDecimal(13))
                    {
                        TempData["fulladdress"] = "WB";
                    }
                    else if (bie.WORKLOCATION == Convert.ToDecimal(14))
                    {
                        TempData["fulladdress"] = "Rourkela";
                    }
                   
                    if (bie.MATERIAL_STATUS != null)
                    {
                        TempData["UnMarried"] = bie.MATERIAL_STATUS;
                    }
                    if (bie.SEX != null)
                    {
                        TempData["radioSex"] = bie.SEX;
                    }


                    if (bie.EMPLOYEE_FULLNAME != null)
                    {
                        TempData["fullname"] = bie.EMPLOYEE_FULLNAME;
                    }
                    if (bie.designationname != null)
                    {
                        TempData["designationname"] = bie.designationname;
                    }

                    if (bie.EMPLOYEE_IMAGE != null)
                    {
                        TempData["IMAGEURL"] = "http://localhost:56783~/images/" + bie.EMPLOYEE_IMAGE;
                    }
                    if (bie.EMPIMAGE != null)
                    {
                        TempData["IMGURL"] = bie.EMPIMAGE;
                    }
                    if (bie.DESIGNATION != null)
                    {
                        TempData["designation"] = bie.DESIGNATION;
                    }
                    else { TempData["designation"] = "0"; }


                    if (bie.DIVISION != null)
                    {
                        TempData["division"] = bie.DIVISION;
                    }
                    else { TempData["division"] = "0"; }

                    if (bie.SUBDIVISION != null)
                    {
                        TempData["subdivision"] = bie.SUBDIVISION;
                    }
                    else { TempData["subdivision"] = "0"; }

                    if (bie.SECTION != null)
                    {
                        TempData["section"] = bie.SECTION;
                    }
                    else { TempData["section"] = "0"; }


                    if (bie.DEPARTMENT != null)
                    {
                        TempData["department"] = Convert.ToInt32(bie.DEPARTMENT);
                    }
                    else { TempData["department"] = "0"; }

                    if (bie.REPORTING_TO != null)
                    {
                        TempData["reportingto"] = bie.REPORTING_TO;
                    }
                    else { TempData["reportingto"] = "0"; }




                    if (bie.GRADE != null)
                    {
                        TempData["grade"] = Convert.ToInt32(bie.GRADE);
                    }
                    else { TempData["grade"] = "0"; }

                    if (bie.BLOOD_GROUP != null)
                    {
                        TempData["bloodgroup"] = Convert.ToInt32(bie.BLOOD_GROUP);
                    }
                    else { TempData["bloodgroup"] = "0"; }

                    if (bie.EXIT_TYPE != null)
                    {
                        TempData["exittype"] = Convert.ToInt32(bie.EXIT_TYPE);
                    }
                    else { TempData["exittype"] = "0"; }
                    if (bie.FULL_N_FINAL_STATUS != null)
                    {
                        TempData["fnfstaus"] = bie.FULL_N_FINAL_STATUS;
                    }
                    else { TempData["fnfstaus"] = "0"; }
                    HttpResponseMessage responseMessagetrDtls = await client.GetAsync(url + "transferdetails/" + Convert.ToInt32(Session["urlid"]));
                    if (responseMessagetrDtls.IsSuccessStatusCode)
                    {
                        var responseData1 = responseMessagetrDtls.Content.ReadAsStringAsync().Result;

                        var result1 = JsonConvert.DeserializeObject<List<TransferdetailsEntities>>(responseData1);
                        TempData["trdata"] = result1;
                    }
                    return View(bie);
                }


            }
            return View();
        }
        public ActionResult Example(BasicInformaionEntities Dept)
        {
            //This will populate the Test Partial View with your value(s)
            return PartialView("_BasicInformation");
        }

        //[ChildActionOnly]
        public ActionResult _BasicInformation()
        {
            return PartialView("_BasicInformation");
        }
        //async Actions Methods for Post BisicInformation Data to WebApi
        public async Task<ActionResult> BICreate(BasicInformaionEntities bie)
        {

            bie.ID = Convert.ToInt32(Session["urlid"]);
            //if (ModelState.IsValid)
            //{

            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url + "basicinformation", bie);

            if (responseMessage.IsSuccessStatusCode)
            {
                //return PartialView("_BasicInformation");
                 return Json("_BasicInformation");
                //return RedirectToAction("_BasicInformation");
                //return PartialView("_BasicInformation");
                //return Redirect("~/EmployeeDetails/Index" + Session["urlid"].ToString());
                //return View("Index", "EmployeeDetails", new { id = Session["urlid"].ToString() });
            }

            // }

            return Json("_BasicInformation");
        }

        public ActionResult _CommunicationDetails()
        {

            return PartialView("_CommunicationDetails");
        }
        public async Task<ActionResult> DICreate(CommunicationDetailsEntities bie)
        {
            bie.EMPLOYEE_ID = Convert.ToInt32(Session["urlid"]);
            //if (ModelState.IsValid)
            //{

            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url + "communicatidetails", bie);


            if (responseMessage.IsSuccessStatusCode)
            {
                //return PartialView("_BasicInformation");
                return Json("_CommunicationDetails");
                //return RedirectToAction("_CommunicationDetails");
                //return PartialView("_BasicInformation");
            }
            return Json("_CommunicationDetails");
        }
     
        public async Task<ActionResult> QualificationCreate(QualificationDetailsEntities bie)
        {
            bie.EMPLOYEE_ID = Convert.ToInt32(Session["urlid"]);
            //if (ModelState.IsValid)
            //{

            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url + "qualificationdetails", bie);


            if (responseMessage.IsSuccessStatusCode)
            {
                //return PartialView("_BasicInformation");
                // return Json("_BasicInformation");
                return RedirectToAction("_QualificationDetails");
                //return PartialView("_BasicInformation");
            }
            return Json("_QualificationDetails");
        }
        public async Task<ActionResult> Qualificationdetailsedit(int id, QualificationDetailsEntities bie)
        {
            HttpResponseMessage responseMessageemploymentdetails = await client.PutAsJsonAsync(url + "qualificationdetails/" + id, bie);
            if (responseMessageemploymentdetails.IsSuccessStatusCode)
            {
                //return PartialView("_BasicInformation");
                // return Json("_BasicInformation");
                return RedirectToAction("_QualificationDetails");
                //return PartialView("_BasicInformation");
            }
            return Json("_QualificationDetails");
        }
        public async Task<ActionResult> Employmentcreate(EmploymentEntities bie)
        {
            bie.EMPLOYEE_ID = Convert.ToInt32(Session["urlid"]);
            //if (ModelState.IsValid)
            //{

            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url + "employment", bie);


            if (responseMessage.IsSuccessStatusCode)
            {
                //return PartialView("_BasicInformation");
                // return Json("_BasicInformation");
                return RedirectToAction("_EmploymentDetails");
                //return PartialView("_BasicInformation");
            }
            return Json("_QualificationDetails");
        }
        public async Task<ActionResult> employmentdetailsedit(int id, EmploymentEntities bie)
        {

            HttpResponseMessage responseMessageemploymentdetails = await client.PutAsJsonAsync(url + "employment/" + id, bie);
            if (responseMessageemploymentdetails.IsSuccessStatusCode)
            {
                //return PartialView("_BasicInformation");
                // return Json("_BasicInformation");
                return RedirectToAction("_EmploymentDetails");
                //return PartialView("_BasicInformation");
            }
            return Json("_EmploymentDetails");
        }

        public async Task<ActionResult> relationcreate(RelationshipDetailEntities bie)
        {
            bie.EMPLOYEE_ID = Convert.ToInt32(Session["urlid"]);
            //if (ModelState.IsValid)
            //{

            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url + "relationship", bie);


            if (responseMessage.IsSuccessStatusCode)
            {
                //return PartialView("_BasicInformation");
                // return Json("_BasicInformation");
                return RedirectToAction("_RelationshipDetails");
                //return PartialView("_BasicInformation");
            }
            return Json("_RelationshipDetails");
        }
        public async Task<ActionResult> relationdetailsedit(int id, RelationshipDetailEntities bie)
        {

            HttpResponseMessage responseMessageemploymentdetails = await client.PutAsJsonAsync(url + "relationship/" + id, bie);
            if (responseMessageemploymentdetails.IsSuccessStatusCode)
            {
                //return PartialView("_BasicInformation");
                // return Json("_BasicInformation");
                return RedirectToAction("_RelationshipDetails");
                //return PartialView("_BasicInformation");
            }
            return Json("_RelationshipDetails");
        }

        public async Task<ActionResult> Assetcreate(AssetDetailsEntities bie)
        {
            bie.EMPLOYEE_ID = Convert.ToInt32(Session["urlid"]);
            //if (ModelState.IsValid)
            //{

            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url + "assetdetails", bie);
           
            if (responseMessage.IsSuccessStatusCode)
            {
                //return PartialView("_BasicInformation");
                // return Json("_BasicInformation");
                return RedirectToAction("_Asset");
                //return PartialView("_BasicInformation");
            }
            return Json("_Asset");
        }
        public async Task<ActionResult> Assetedit(int id, AssetDetailsEntities bie)
        {

            HttpResponseMessage responseMessageemploymentdetails = await client.PutAsJsonAsync(url + "assetdetails/" + id, bie);
            if (responseMessageemploymentdetails.IsSuccessStatusCode)
            {
                //return PartialView("_BasicInformation");
                // return Json("_BasicInformation");
                return RedirectToAction("_Asset");
                //return PartialView("_BasicInformation");
            }
            return Json("_Asset");
        }

        public async Task<ActionResult> PIPcreate(PIPDeatilsEntities bie)
        {
            bie.EMPLOYEE_ID = Convert.ToInt32(Session["urlid"]);
            //if (ModelState.IsValid)
            //{

            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url + "pipdetails", bie);


            if (responseMessage.IsSuccessStatusCode)
            {
                //return PartialView("_BasicInformation");
                // return Json("_BasicInformation");
                return RedirectToAction("_PIP");
                //return PartialView("_BasicInformation");
            }
            return Json("_PIP");
        }
        public async Task<ActionResult> PIPtedit(int id, PIPDeatilsEntities bie)
        {

            HttpResponseMessage responseMessageemploymentdetails = await client.PutAsJsonAsync(url + "pipdetails/" + id, bie);
            if (responseMessageemploymentdetails.IsSuccessStatusCode)
            {
                //return PartialView("_BasicInformation");
                // return Json("_BasicInformation");
                return RedirectToAction("_PIP");
                //return PartialView("_BasicInformation");
            }
            return Json("_PIP");
        }

        public async Task<ActionResult> Transfercreate(TransferdetailsEntities bie)
        {
            bie.EMPLOYEE_ID = Convert.ToInt32(Session["urlid"]);
            //if (ModelState.IsValid)
            //{

            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url + "transferdetails", bie);


            if (responseMessage.IsSuccessStatusCode)
            {
                //return PartialView("_BasicInformation");
                // return Json("_BasicInformation");
                //return RedirectToAction("Index", "EmployeeDetails");
                return RedirectToAction("_TransferDetails");
                //return PartialView("_BasicInformation");
            }
            return Json("_TransferDetails");
        }
        public async Task<ActionResult> Transferedit(int id, TransferdetailsEntities bie)
        {

            HttpResponseMessage responseMessageemploymentdetails = await client.PutAsJsonAsync(url + "transferdetails/" + id, bie);
            if (responseMessageemploymentdetails.IsSuccessStatusCode)
            {
                //return PartialView("_BasicInformation");
                // return Json("_BasicInformation");
                return RedirectToAction("_TransferDetails");
                //return PartialView("_BasicInformation");
            }
            return Json("_TransferDetails");
        }

        public async Task<ActionResult> InsertAccountdetails(EmpAcountEntity Acc)
        {
            Acc.EMPLOYEE_ID = Convert.ToInt32(Session["urlid"]);
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url + "salarydetails", Acc);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Json(new { success = true, responseText = "data saved successfuly !" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false, responseText = "data saved unsuccessfuly !" }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult _QualificationDetails()
        {
            //return View();
            return PartialView("_QualificationDetails");
        }
        public ActionResult _EmploymentDetails()
        {
            // return View();
            return PartialView("_EmploymentDetails");
        }
        public ActionResult _RelationshipDetails()
        {
            //return View();
            return PartialView("_RelationshipDetails");
        }
        public ActionResult _RecordDetails()
        {
            return View();
        }
        public ActionResult _LeaveDetails()
        {
            return View();
        }
        public ActionResult _TransferDetails()
        {
            //return View();
            return PartialView("_TransferDetails");
        }
        public ActionResult _PIP()
        {
            //return View();
            return PartialView("_PIP");
        }
        public ActionResult _Asset()
        {
            //return View();
            return PartialView("_Asset");
        }
        public ActionResult _carrerprogress()
        {
            var result = TempData["trdata"];
            //TempData["trdata"] = result1;
            return PartialView("_carrerprogress", result);
        }
    }
}
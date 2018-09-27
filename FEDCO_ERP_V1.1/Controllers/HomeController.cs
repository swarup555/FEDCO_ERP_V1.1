using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FEDCO_ERP_V1._1.Models;
using BUSSINESS_ENTITIES;
using Newtonsoft.Json;
using System.Data;
using System.IO;
using Excel;
using System.Globalization;

namespace FEDCO_ERP_V1._1.Controllers
{
    public class HomeController : Controller
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
        public HomeController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion
        public ActionResult Index()
        {
            //HttpResponseMessage responseMessagedesignation = await client.GetAsync(url + "basicinformation");
            //if (responseMessagedesignation.IsSuccessStatusCode)
            //{
            //    var responseData = responseMessagedesignation.Content.ReadAsStringAsync().Result;

            //    var result = JsonConvert.DeserializeObject<List<BasicInformaionEntities>>(responseData);
            //    TempData["warnmsg"] = TempData["warningmsg"];
            //    TempData["msg"] = TempData["successmsg"];
            //    TempData["errormsg"] = TempData["errormsg"];
            //    var bithdaydata = result.Where(x => x.DATE_OF_BIRTH.HasValue).ToList().Where(y => y.DATE_OF_BIRTH.Value.Day == System.DateTime.Now.Day && y.DATE_OF_BIRTH.Value.Month == System.DateTime.Now.Month).ToList();
            //    TempData["birthday"] = result.Where(x => x.DATE_OF_BIRTH.HasValue).ToList().Where(y => y.DATE_OF_BIRTH.Value.Day == System.DateTime.Now.Day && y.DATE_OF_BIRTH.Value.Month == System.DateTime.Now.Month).ToList().Count;
            //    return View(bithdaydata.ToList());
            //}
            TempData["warnmsg"] = TempData["warningmsg"];
            TempData["msg"] = TempData["successmsg"];
            TempData["errmsg"] = TempData["errormsg"];
            TempData["sucmsg"] = TempData["sucsmsg"];
            return View();
        }
        public async Task<ActionResult> EmployeeCreate(BasicInformaionEntities bie)
        {


            //if (ModelState.IsValid)
            //{

            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url + "basicinformation", bie);

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["sucsmsg"] = "saved";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<ActionResult> DataFromExcel(ExcelUploadEntities bie, HttpPostedFileBase file2)
        {
            try { 
            //if (ModelState.IsValid)
            //{

                if (file2 != null && file2.ContentLength > 0)
                {
                    // ExcelDataReader works with the binary Excel file, so it needs a FileStream
                    // to get started. This is how we avoid dependencies on ACE or Interop:
                    Stream stream = file2.InputStream;

                    // We return the interface, so that
                    IExcelDataReader reader = null;


                    if (file2.FileName.EndsWith(".xls"))
                    {
                        reader = ExcelReaderFactory.CreateBinaryReader(stream);
                    }
                    else if (file2.FileName.EndsWith(".xlsx"))
                    {
                        reader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                    }
                    else
                    {
                        ModelState.AddModelError("File", "This file format is not supported");
                        return View();
                    }

                    reader.IsFirstRowAsColumnNames = true;

                    DataSet result = reader.AsDataSet();

                    //for (int i = 1; i < result.Tables[0].Rows.Count; i++)
                    //{
                    //    DataRow data = result.Tables[0].Rows[i];
                    //    // string CellValue = result.Tables[0].Rows[i][i];

                    //    //System.Diagnostics.Debug.Write(data.Table.Rows[i]["Column header name"]);
                    //}
                    int ap = 0;
                    int an = 0;
                    int bp = 0;
                    int bn = 0;
                    int op = 0;
                    int on = 0;
                    int abp = 0;
                    int abn = 0;
                    for (int i = 0; i < result.Tables[0].Rows.Count; i++)
                    {
                        bie.EMPLOYEE_CODE = null;
                        bie.DESIGNATION = null;
                        bie.EMPLOYEE_FIRSTNAME = null;
                        string fullname = null;
                        bie.EMPLOYEE_MIDDLENAME = null;
                        bie.EMPLOYEE_LASTNAME = null;
                        bie.DATE_OF_BIRTH = null;
                        bie.AGE = null;
                        bie.SEX = null;
                        bie.DOMICILE_STATUS = null;
                        bie.MATERIAL_STATUS = null;
                        bie.WEDDING_ANNIVERSARY = null;
                        bie.REPORTING_TO = null;
                        bie.GRADE = null;
                        bie.BLOOD_GROUP = null;
                        bie.HEIGHT = null;
                        bie.WEIGHT = null;
                        bie.MEDICLAIM_NUMBER = null;
                        bie.ESIC_NO = null;
                        bie.PF_UNID_NUMBER = null;
                        bie.INDUCTION = null;
                        bie.IDENTIFICATION_MARK = null;
                        bie.LAST_MAJOR_ILLNESS_SURGERY = null;
                        bie.ALLERGY_HISTORY = null;
                        bie.HIRING_TYPE = null;
                        bie.CV_TYPE = null;
                        bie.YEAR_OF_EXPERIENCE = null;
                        bie.EXIT_DATE = null;
                        bie.EXIT_TYPE = null;
                        bie.REFERENCE = null;
                        bie.FULL_N_FINAL_STATUS = null;
                        bie.DIVISION = null;
                        bie.SUBDIVISION = null;
                        bie.SECTION = null;
                        bie.DEPARTMENT = null;
                        bie.EMPLOYEE_IMAGE = null;
                        bie.JOINING_DATE = null;
                        bie.RELIGION = null;
                        bie.SUBDIVISION = null;
                        bie.WORKLOCATION = null;
                        bie.MOTHERTOUNGE = null;
                        bie.STATUS = null;
                        bie.Account = null;
                        bie.Relationship = null;
                        bie.Communication = null;
                        bie.qualification = null;
                        bie.Employment = null;
                        //string conn = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                        //SqlConnection con = new SqlConnection(conn);
                        // string query = "Insert into Person(Name,Email,Mobile) Values('" +
                        //ds.Tables[0].Rows[i][0].ToString() + "','" + ds.Tables[0].Rows[i][1].ToString() +
                        //"','" + ds.Tables[0].Rows[i][2].ToString() + "')";
                        //result.Tables[0].Rows[i]
                        if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][1].ToString()))
                        {
                            bie.EMPLOYEE_CODE = Convert.ToString(result.Tables[0].Rows[i][1]).Trim();
                        }
                       

                        if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][2].ToString()))
                        {
                            if (result.Tables[0].Rows[i][2].ToString() == "NESCO - VAI - Balasore")
                            {
                                bie.WORKLOCATION = 2;
                            }
                            else if (result.Tables[0].Rows[i][2].ToString() == "Bhubaneswar")
                            {
                                bie.WORKLOCATION = 1;
                            }
                            else if (result.Tables[0].Rows[i][2].ToString() == "Mumbai")
                            {
                                bie.WORKLOCATION = 10;
                            }
                            else if (result.Tables[0].Rows[i][2].ToString() == "Project office")
                            {
                                bie.WORKLOCATION = 7;
                            }
                            else if (result.Tables[0].Rows[i][2].ToString() == "Puri")
                            {
                                bie.WORKLOCATION =11;
                            }
                            else if (result.Tables[0].Rows[i][2].ToString() == "Khordha")
                            {
                                bie.WORKLOCATION = 5;
                            }
                            else if (result.Tables[0].Rows[i][2].ToString() == "Deputation - Gurgaon")
                            {
                                bie.WORKLOCATION = 9;
                            }
                            else if (result.Tables[0].Rows[i][2].ToString() == "Kandhamal - NRI")
                            {
                                bie.WORKLOCATION = 8;
                            }
                            else if (result.Tables[0].Rows[i][2].ToString() == "WESCO - VAI - Rourkela")
                            {
                                bie.WORKLOCATION = 14;
                            }
                            else if (result.Tables[0].Rows[i][2].ToString() == "Deputation - Bhubaneswar")
                            {
                                bie.WORKLOCATION = 12;
                            }
                            else if (result.Tables[0].Rows[i][2].ToString() == "Deputation - Mumbai")
                            {
                                bie.WORKLOCATION = 15;
                            }
                            else if (result.Tables[0].Rows[i][2].ToString() == "WB")
                            {
                                bie.WORKLOCATION = 13;
                            }
                            else if (result.Tables[0].Rows[i][2].ToString() == "Khordha 1" || result.Tables[0].Rows[i][2].ToString() == "Khordha-1")
                            {
                               
                                bie.WORKLOCATION = 2;
                                bie.DIVISION = "000001";
                            }
                            else if (result.Tables[0].Rows[i][2].ToString() == "Khordha 2" || result.Tables[0].Rows[i][2].ToString() == "Khordha-2")
                            {
                                bie.WORKLOCATION = 2;
                                bie.DIVISION = "000007";
                            }
                            else if (result.Tables[0].Rows[i][2].ToString() == "Nayagarh")
                            {
                                bie.WORKLOCATION = 2;
                                bie.DIVISION = "000002";
                            }
                            else if (result.Tables[0].Rows[i][2].ToString() == "Balugaon")
                            {
                                bie.WORKLOCATION = 2;
                                bie.DIVISION = "000003";
                            }
                            else if (result.Tables[0].Rows[i][2].ToString() == "Puri Urban")
                            {
                                bie.WORKLOCATION = 2;
                                bie.DIVISION = "000004";
                            }
                            else if (result.Tables[0].Rows[i][2].ToString() == "Puri Rural")
                            {
                                bie.WORKLOCATION = 2;
                                bie.DIVISION = "000006";
                            }
                           
                        }
                        if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][4].ToString()))
                        {
                            bie.WORKLOCATION = 3;
                            bie.SUBDIVISION = Convert.ToString(result.Tables[0].Rows[i][4].ToString()).Trim();
                        }
                        if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][5].ToString()))
                        {
                            bie.WORKLOCATION = 4;
                            bie.SECTION = Convert.ToString(result.Tables[0].Rows[i][5].ToString()).Trim();
                        }
                        fullname = result.Tables[0].Rows[i][6].ToString().Trim();
                         //char[] delimiters1 = new[] { "", StringSplitOptions.RemoveEmptyEntries};
                         //string[] data = fullname.Split(new []{null}, StringSplitOptions.RemoveEmptyEntries);
                        var data = fullname.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                        if(data.ToList().Count==3)
                        {
                            if (!string.IsNullOrEmpty(data[0].ToString()))
                            {
                                bie.EMPLOYEE_FIRSTNAME = Convert.ToString(data[0]).Trim();
                            }
                            if (!string.IsNullOrEmpty(data[1].ToString()))
                            {
                                bie.EMPLOYEE_MIDDLENAME = Convert.ToString(data[1]).Trim();
                            }
                            if (!string.IsNullOrEmpty(data[2].ToString()))
                            {
                                bie.EMPLOYEE_LASTNAME = Convert.ToString(data[2]).Trim();
                            }
                        }
                        if (data.ToList().Count == 2)
                        {
                            if (!string.IsNullOrEmpty(data[0].ToString()))
                            {
                                bie.EMPLOYEE_FIRSTNAME = Convert.ToString(data[0]).Trim();
                            }
                            if (!string.IsNullOrEmpty(data[1].ToString()))
                            {
                                bie.EMPLOYEE_LASTNAME = Convert.ToString(data[1]).Trim();
                            }
                        }
                        if (data.ToList().Count == 1)
                        {
                            if (!string.IsNullOrEmpty(data[0].ToString()))
                            {
                                bie.EMPLOYEE_FIRSTNAME = Convert.ToString(data[0]).Trim();
                            }
                        }
                        if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][7].ToString()))
                        {
                            bie.designationname = Convert.ToString(result.Tables[0].Rows[i][7]).Trim();
                        }
                        if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][8].ToString()))
                        {
                            bie.departmentname = Convert.ToString(result.Tables[0].Rows[i][8]).Trim();
                        }
                        if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][9].ToString()))
                        {
                            bie.gradename = Convert.ToString(result.Tables[0].Rows[i][9]).Trim();
                        }
                        if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][10].ToString()))
                        {
                            bie.REPORTING_TO = Convert.ToString(result.Tables[0].Rows[i][10]);
                        }
                        if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][11].ToString()))
                        {
                            //double joining = Convert.ToDouble(result.Tables[0].Rows[i][8]);
                            //DateTime dt = DateTime.FromOADate(joining);
                            bie.JOINING_DATE = Convert.ToDateTime(result.Tables[0].Rows[i][11]);
                        }
                        if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][12].ToString()))
                        {
                            bie.STATUS = Convert.ToString(result.Tables[0].Rows[i][12]);
                        }
                        if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][17].ToString()))
                        {
                            //double dob = Convert.ToDouble(result.Tables[0].Rows[i][14]);
                            //DateTime dt = DateTime.FromOADate(dob);
                            bie.DATE_OF_BIRTH = Convert.ToDateTime(result.Tables[0].Rows[i][17]);
                        }
                        if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][18].ToString()))
                        {
                            bie.MATERIAL_STATUS = Convert.ToString(result.Tables[0].Rows[i][18]);
                        }
                        if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][19].ToString()))
                        {
                            //double wed = Convert.ToDouble(result.Tables[0].Rows[i][16]);
                            //DateTime dt = DateTime.FromOADate(wed);
                            bie.WEDDING_ANNIVERSARY = Convert.ToDateTime(result.Tables[0].Rows[i][19]);
                        }
                        if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][26].ToString()))
                        {
                            //bie.bloodgroup = Convert.ToString(result.Tables[0].Rows[i][25]);
                            if (result.Tables[0].Rows[i][26].ToString() == "A +ve")
                            {
                                ap++;
                                bie.BLOOD_GROUP = 7;
                            }
                            else if (result.Tables[0].Rows[i][26].ToString() == "A -ve")
                            {
                                an++;
                                bie.BLOOD_GROUP = 1;
                            }
                            else if (result.Tables[0].Rows[i][26].ToString() == "B -ve")
                            {
                                bn++;
                                bie.BLOOD_GROUP = 2;
                            }
                            else if (result.Tables[0].Rows[i][26].ToString() == "B +ve" || result.Tables[0].Rows[i][26].ToString() == "B +ve ")
                            {
                                bp++;
                                bie.BLOOD_GROUP = 8;
                            }
                            else if (result.Tables[0].Rows[i][26].ToString() == "O +ve")
                            {
                                op++;
                                bie.BLOOD_GROUP = 3;
                            }
                            else if (result.Tables[0].Rows[i][26].ToString() == "O -ve")
                            {
                                on++;
                                bie.BLOOD_GROUP = 4;
                            }
                            else if (result.Tables[0].Rows[i][26].ToString() == "AB +ve")
                            {
                                abp++;
                                bie.BLOOD_GROUP = 5;
                            }
                            else if (result.Tables[0].Rows[i][26].ToString() == "AB -ve")
                            {
                                abn++;
                                bie.BLOOD_GROUP = 6;
                            }
                        }
                        if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][32].ToString()))
                        {
                            string[] yrdata = result.Tables[0].Rows[i][32].ToString().Split(null);
                            if (yrdata.ToList().Count > 1)
                            {
                                if (yrdata[1].Contains("months") || yrdata[1].Contains("Month") || yrdata[1].Contains("month") || yrdata[1].Contains("Months"))
                                {
                                    decimal? YROFEXP = Convert.ToDecimal(yrdata[0]) / 100;
                                    bie.YEAR_OF_EXPERIENCE = Convert.ToString(YROFEXP);
                                }
                                if (yrdata[1].Contains("Year") || yrdata[1].Contains("Years") || yrdata[0].Contains("year") || yrdata[1].Contains("years") || yrdata[1].Contains("yrs") || yrdata[1].Contains("Yrs"))
                                {
                                    bie.YEAR_OF_EXPERIENCE = Convert.ToString(yrdata[0]);
                                }
                                //else
                                //{
                                //    bie.YEAR_OF_EXPERIENCE = Convert.ToDecimal(yrdata[0]);
                                //}
                            }
                            if (yrdata[0].Contains("months") || yrdata[0].Contains("Month") || yrdata[0].Contains("month") || yrdata[0].Contains("Months"))
                            {
                                bie.YEAR_OF_EXPERIENCE = "0";
                            }
                            if (yrdata[0].Contains("Year") || yrdata[0].Contains("Years") || yrdata[0].Contains("year") || yrdata[0].Contains("years") || yrdata[0].Contains("yrs") || yrdata[0].Contains("Yrs"))
                            {
                                bie.YEAR_OF_EXPERIENCE = "0";
                            }
                            
                            foreach (string str in yrdata)
                            {
                                if (str.Contains("fresher"))
                                {
                                    bie.YEAR_OF_EXPERIENCE = "0";
                                }
                                //else if (str.Contains("month") || str.Contains("Month") || str.Contains("months") || str.Contains("Months"))
                                //{
                                //    if (yrdata[0].Contains("months") || yrdata[0].Contains("Month") || yrdata[0].Contains("month") || yrdata[0].Contains("Months"))
                                //    {

                                //    }
                                //    else
                                //    {
                                //        bie.YEAR_OF_EXPERIENCE = Convert.ToDecimal(yrdata[0]) / 100;
                                //    }
                                   
                                   
                                //}
                                //else if (str.Contains("Year") || str.Contains("Years") || str.Contains("year") || str.Contains("years") || str.Contains("yrs") || str.Contains("Yrs"))
                                //{
                                //     if (yrdata[0].Contains("Year") || yrdata[0].Contains("Years") || yrdata[0].Contains("year") || yrdata[0].Contains("years") || yrdata[0].Contains("yrs") || yrdata[0].Contains("Yrs"))
                                //     {

                                //     }
                                //     else
                                //     {
                                //         bie.YEAR_OF_EXPERIENCE = Convert.ToDecimal(yrdata[0]);
                                //     }
                                //}
                                //else
                                //{
                                //    bie.YEAR_OF_EXPERIENCE = Convert.ToDecimal(yrdata[0]);
                                //}

                            }
                           
                        }
                        if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][40].ToString()))
                        {
                            bie.ESIC_NO = Convert.ToString(result.Tables[0].Rows[i][40]);
                        }
                        List<RelationshipDetailEntities> bi = new List<RelationshipDetailEntities>();
                        if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][20].ToString()))
                        {
                            //List<RelationshipDetailEntities> spouse = new List<RelationshipDetailEntities>();
                          
                            RelationshipDetailEntities spouse = new RelationshipDetailEntities();
                            spouse.RELATIONSHIP = "Husband/Spouse";
                            string[] data1 = result.Tables[0].Rows[i][20].ToString().Split(',');
                            if (data1.ToList().Count >0)
                            {
                                spouse.RELATIVE_NAME = Convert.ToString(data1[0]);
                            }
                            if (data1.ToList().Count > 1)
                            {
                                spouse.RELATIVE_NAME = Convert.ToString(data1[0]);
                                spouse.DATE_OF_BIRTH = Convert.ToDateTime(data1[1]);
                            }
                            bi.Add(spouse);
                           
                        }
                      
                       
                        if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][21].ToString()))
                        {
                           
                            RelationshipDetailEntities Child1 = new RelationshipDetailEntities();
                            Child1.RELATIONSHIP = "Child1";
                            string[] data1 = result.Tables[0].Rows[i][21].ToString().Split(',');
                            if (data1.ToList().Count > 0)
                            {
                                Child1.RELATIVE_NAME = Convert.ToString(data1[0]);
                            }
                            if (data1.ToList().Count > 1)
                            {
                                Child1.RELATIVE_NAME = Convert.ToString(data1[0]);
                                Child1.DATE_OF_BIRTH = Convert.ToDateTime(data1[1]);
                            }
                            bi.Add(Child1);
                           
                        }
                      
                       
                        if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][22].ToString()))
                        {
                          
                            RelationshipDetailEntities Child2 = new RelationshipDetailEntities();
                            Child2.RELATIONSHIP = "Child2";
                            char[] delimiters = new[] { ',', ';' };
                            string[] data1 = result.Tables[0].Rows[i][22].ToString().Split(delimiters);
                            if (data1.ToList().Count > 0)
                            {
                                Child2.RELATIVE_NAME = Convert.ToString(data1[0]);
                            }
                            if (data1.ToList().Count > 1)
                            {
                                Child2.RELATIVE_NAME = Convert.ToString(data1[0]);
                                Child2.DATE_OF_BIRTH = Convert.ToDateTime(data1[1]);
                            }
                            bi.Add(Child2);
                          
                           
                        }
                        if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][23].ToString()))
                        {

                            RelationshipDetailEntities Father = new RelationshipDetailEntities();
                            Father.RELATIONSHIP = "Father/Mother";
                            Father.RELATIVE_NAME = Convert.ToString(result.Tables[0].Rows[i][23]);
                            string[] data1 = result.Tables[0].Rows[i][23].ToString().Split();
                            //if (data1.ToList().Count > 0)
                            //{
                            //    Father.RELATIVE_NAME = Convert.ToString(data1[0]);
                            //}
                            foreach (string str in data1)
                            {
                                if (str.Contains("Mother") || str.Contains("mother"))
                                {
                                    Father.RELATIONSHIP = "Mother";
                                }
                            }
                         
                            bi.Add(Father);


                        }

                        bie.Relationship = bi;
                        List<CommunicationDetailsEntities> com = new List<CommunicationDetailsEntities>();
                        CommunicationDetailsEntities obj = new CommunicationDetailsEntities();
                        if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][14].ToString()))
                        {
                            obj.MOBILE_NUMBER = Convert.ToString(result.Tables[0].Rows[i][14].ToString().Trim());
                        }
                        if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][15].ToString()))
                        {
                            obj.EMERGENCY_CONTACT_NUMBER = Convert.ToString(result.Tables[0].Rows[i][15].ToString()).Trim();
                        }
                        if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][16].ToString()))
                        {
                            obj.OFFICIAL_MOBILE_NUMBER = Convert.ToString(result.Tables[0].Rows[i][16].ToString()).Trim();
                        }
                        if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][28].ToString()))
                        {
                            obj.PANCARD_NUMBER = Convert.ToString(result.Tables[0].Rows[i][28].ToString()).Trim();
                        }
                        if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][27].ToString()))
                        {
                            obj.PERMANENT_ADDRESS =Convert.ToString( result.Tables[0].Rows[i][27].ToString());
                        }
                        if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][25].ToString()))
                        {
                            obj.PERSONAL_EMAIL =Convert.ToString( result.Tables[0].Rows[i][25].ToString());
                        }
                        if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][24].ToString()))
                        {
                            obj.OFFICIAL_EMAIL =Convert.ToString( result.Tables[0].Rows[i][24].ToString());
                        }
                        if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][29].ToString()))
                        {
                            obj.AADHAR_NUMBER = Convert.ToString(result.Tables[0].Rows[i][29].ToString());
                        }
                        com.Add(obj);
                        bie.Communication = com;
                        List<EmpAcountEntity> acc = new List<EmpAcountEntity>();
                        EmpAcountEntity acount = new EmpAcountEntity();
                        if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][35].ToString()))
                        {
                            acount.BANKNAME = result.Tables[0].Rows[i][35].ToString();
                        }
                        if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][36].ToString()))
                        {
                            acount.ACCOUNTNO = result.Tables[0].Rows[i][36].ToString();
                        }
                        if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][37].ToString()))
                        {
                            acount.IFSCCODE = result.Tables[0].Rows[i][37].ToString();
                        }
                        if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][38].ToString()))
                        {
                            acount.BRANCH = result.Tables[0].Rows[i][38].ToString();
                        }
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][36].ToString()))
                        //{
                        //    acount.CTC = result.Tables[0].Rows[i][36].ToString();
                        //}
                        acc.Add(acount);
                        bie.Account = acc;
                        if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][40].ToString()))
                        {
                            bie.ESIC_NO = result.Tables[0].Rows[i][40].ToString();
                        }
                        List<QualificationDetailsEntities> qualificationdtls = new List<QualificationDetailsEntities>();
                        QualificationDetailsEntities qual = new QualificationDetailsEntities();
                        if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][30].ToString()))
                        {
                            qual.EXAM_DEGREE_TYPE = result.Tables[0].Rows[i][30].ToString();
                        }
                        qualificationdtls.Add(qual);
                        bie.qualification = qualificationdtls;
                        List<EmploymentEntities> Employmentdtls = new List<EmploymentEntities>();
                        EmploymentEntities emp = new EmploymentEntities();
                        if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][33].ToString()))
                        {
                            emp.ORGANISATION_NAME = result.Tables[0].Rows[i][33].ToString();
                        }
                        Employmentdtls.Add(emp);
                        bie.Employment = Employmentdtls;
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][33].ToString()))
                        //{
                        //    acount.ct = result.Tables[0].Rows[i][33].ToString();
                        //}
                        //foreach (string name in data)
                        //{
                        //    foreach (ListItem li in DropDownList1.Items)
                        //    {
                        //        if (li.Value == word)
                        //        {
                        //            DropDownList2.Items.Add(new ListItem(li.Value));
                        //        }
                        //    }
                        //}
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][1].ToString()))
                        //{
                        //    bie.EMPLOYEE_CODE = Convert.ToString(result.Tables[0].Rows[i][1]);
                        //}
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][2].ToString()))
                        //{
                        //    bie.DESIGNATION = Convert.ToDecimal(result.Tables[0].Rows[i][2]);
                        //}
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][3].ToString()))
                        //{
                        //    bie.EMPLOYEE_FIRSTNAME = Convert.ToString(result.Tables[0].Rows[i][3]);
                        //}
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][4].ToString()))
                        //{
                        //    bie.EMPLOYEE_MIDDLENAME = Convert.ToString(result.Tables[0].Rows[i][4]);
                        //}
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][5].ToString()))
                        //{
                        //    bie.EMPLOYEE_LASTNAME = Convert.ToString(result.Tables[0].Rows[i][5]);
                        //}
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][6].ToString()))
                        //{
                        //    double dob = Convert.ToDouble(result.Tables[0].Rows[i][6]);
                        //    DateTime dt = DateTime.FromOADate(dob);
                        //    bie.DATE_OF_BIRTH = dt;
                        //}
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][7].ToString()))
                        //{
                        //    bie.AGE = Convert.ToDecimal(result.Tables[0].Rows[i][7]);
                        //}
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][8].ToString()))
                        //{
                        //    bie.SEX = Convert.ToString(result.Tables[0].Rows[i][8]);
                        //}
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][9].ToString()))
                        //{
                        //    bie.DOMICILE_STATUS = Convert.ToString(result.Tables[0].Rows[i][9]);
                        //}
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][10].ToString()))
                        //{
                        //    bie.MATERIAL_STATUS = Convert.ToString(result.Tables[0].Rows[i][10]);
                        //}
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][11].ToString()))
                        //{
                        //    double dob = Convert.ToDouble(result.Tables[0].Rows[i][11]);
                        //    DateTime dt = DateTime.FromOADate(dob);
                        //    bie.WEDDING_ANNIVERSARY = dt;
                        //}
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][12].ToString()))
                        //{
                        //    bie.REPORTING_TO = Convert.ToString(result.Tables[0].Rows[i][12]);
                        //}
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][13].ToString()))
                        //{
                        //    bie.GRADE = Convert.ToDecimal(result.Tables[0].Rows[i][13]);
                        //}
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][14].ToString()))
                        //{
                        //    bie.BLOOD_GROUP = Convert.ToDecimal(result.Tables[0].Rows[i][14]);
                        //}
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][15].ToString()))
                        //{
                        //    bie.HEIGHT = Convert.ToDecimal(result.Tables[0].Rows[i][15]);
                        //}
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][16].ToString()))
                        //{
                        //    bie.WEIGHT = Convert.ToDecimal(result.Tables[0].Rows[i][16]);
                        //}
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][17].ToString()))
                        //{
                        //    bie.MEDICLAIM_NUMBER = Convert.ToString(result.Tables[0].Rows[i][17]);
                        //}
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][18].ToString()))
                        //{
                        //    bie.ESIC_NO = Convert.ToString(result.Tables[0].Rows[i][18]);
                        //}
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][19].ToString()))
                        //{
                        //    bie.PF_UNID_NUMBER = Convert.ToString(result.Tables[0].Rows[i][19]);
                        //}
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][20].ToString()))
                        //{
                        //    bie.INDUCTION = Convert.ToString(result.Tables[0].Rows[i][20]);
                        //}
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][21].ToString()))
                        //{
                        //    bie.IDENTIFICATION_MARK = Convert.ToString(result.Tables[0].Rows[i][21]);
                        //}
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][22].ToString()))
                        //{
                        //    bie.LAST_MAJOR_ILLNESS_SURGERY = Convert.ToString(result.Tables[0].Rows[i][22]);
                        //}
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][23].ToString()))
                        //{
                        //    bie.ALLERGY_HISTORY = Convert.ToString(result.Tables[0].Rows[i][23]);
                        //}
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][24].ToString()))
                        //{
                        //    bie.PHYSICAL_DISABILITY = Convert.ToString(result.Tables[0].Rows[i][24]);
                        //}
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][25].ToString()))
                        //{
                        //    bie.HIRING_TYPE = Convert.ToString(result.Tables[0].Rows[i][25]);
                        //}
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][26].ToString()))
                        //{
                        //    bie.CV_TYPE = Convert.ToString(result.Tables[0].Rows[i][26]);
                        //}
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][27].ToString()))
                        //{
                        //    bie.YEAR_OF_EXPERIENCE = Convert.ToDecimal(result.Tables[0].Rows[i][27]);
                        //}
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][28].ToString()))
                        //{
                        //    double dob = Convert.ToDouble(result.Tables[0].Rows[i][28]);
                        //    DateTime dt = DateTime.FromOADate(dob);
                        //    bie.EXIT_DATE = dt;
                        //}
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][29].ToString()))
                        //{
                        //    bie.EXIT_TYPE = Convert.ToDecimal(result.Tables[0].Rows[i][29]);
                        //}
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][30].ToString()))
                        //{
                        //    bie.REFERENCE = Convert.ToString(result.Tables[0].Rows[i][30]);
                        //}
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][31].ToString()))
                        //{
                        //    bie.FULL_N_FINAL_STATUS = Convert.ToString(result.Tables[0].Rows[i][31]);
                        //}
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][36].ToString()))
                        //{
                        //    bie.DIVISION = Convert.ToString(result.Tables[0].Rows[i][36]);
                        //}
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][37].ToString()))
                        //{
                        //    bie.SUBDIVISION = Convert.ToString(result.Tables[0].Rows[i][37]);
                        //}
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][38].ToString()))
                        //{
                        //    bie.SECTION = Convert.ToString(result.Tables[0].Rows[i][38]);
                        //}
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][39].ToString()))
                        //{
                        //    bie.DEPARTMENT = Convert.ToDecimal(result.Tables[0].Rows[i][39]);
                        //}
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][44].ToString()))
                        //{
                        //    double dob = Convert.ToDouble(result.Tables[0].Rows[i][44]);
                        //    DateTime dt = DateTime.FromOADate(dob);
                        //    bie.JOININGDATE = dt.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                        //}
                        ////bie.DATE_OF_BIRTH = Convert.ToDateTime(result.Tables[0].Rows[i][6]);
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][45].ToString()))
                        //{
                        //    bie.RELIGION = Convert.ToString(result.Tables[0].Rows[i][45]);
                        //}
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][46].ToString()))
                        //{
                        //    bie.WORKLOCATION = Convert.ToDecimal(result.Tables[0].Rows[i][46]);
                        //}
                        //if (!string.IsNullOrEmpty(result.Tables[0].Rows[i][47].ToString()))
                        //{
                        //    bie.MOTHERTOUNGE = Convert.ToString(result.Tables[0].Rows[i][47]);
                        //}

                        //HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url + "excelupload", bie);


                        //if (responseMessage.IsSuccessStatusCode)
                        //{
                        //    TempData["successmsg"] = "saved";
                        //    return RedirectToAction("Index");
                        //}

                        //con.Open();
                        //SqlCommand cmd = new SqlCommand(query, con);
                        //cmd.ExecuteNonQuery();
                        //con.Close();
                    }
                    reader.Close();
                    TempData["successmsg"] = "saved";
                    return RedirectToAction("Index");
                }
                TempData["warningmsg"] = "warn";
            }
            catch (Exception ex)
            {
                var outputLines = new List<string>();
                outputLines.Add(string.Format(
                    "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now,
                    ex.Message, ex.StackTrace, ex.InnerException, ex.HelpLink));
              
                System.IO.File.AppendAllLines(@"D:\errors.txt", outputLines);
                TempData["errormsg"] = "error";
                return RedirectToAction("Index");
            }

                //}
                //else
                //{
                //    ModelState.AddModelError("File", "Please Upload Your file");
                //}
            //}
            return RedirectToAction("Index");
        }
      
	}
}
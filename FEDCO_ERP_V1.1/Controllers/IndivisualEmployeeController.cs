﻿using BUSSINESS_ENTITIES;
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
using System.Web.Script.Serialization;
using System.Web.Configuration;
using System.Runtime.Caching;

namespace FEDCO_ERP_V1._1.Controllers
{
    public class IndivisualEmployeeController : Controller
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
        public IndivisualEmployeeController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion
        //
        // GET: /Indivisual/
        public async Task<ActionResult> Index(string id = null)
        {
            if(id==null)
            {
                id = "1";
            }
            HttpResponseMessage responseMessagedesignation = await client.GetAsync(url + "indivisual" + "/" + id);
            if (responseMessagedesignation.IsSuccessStatusCode)
            {
                var responseData = responseMessagedesignation.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<IndivisualEmployeeEntities>>(responseData);
               

                //HttpResponseMessage responseMessagePIPDtls = await client.GetAsync(url + "transferdetails/" + id);
                //if (responseMessagePIPDtls.IsSuccessStatusCode)
                //{
                //    var responseData1 = responseMessagePIPDtls.Content.ReadAsStringAsync().Result;

                //    var result1 = JsonConvert.DeserializeObject<List<TransferdetailsEntities>>(responseData);
                //    TempData["ModelLs"] = result1;
                //}
                return View(result.ToList());
            }
             return View();
        }
	}
}
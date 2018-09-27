using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BUSSINESS_SERVICE;
using BUSSINESS_ENTITIES;
using System.IO;

namespace FEDCOAPI.Controllers
{
    public class ExceluploadController : ApiController
    {
        private readonly IExcelUpload _ExcelUpload;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
        public ExceluploadController()
        {
            _ExcelUpload = new ExcelUploadService();
        }
        #endregion
        // GET api/excelupload
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/excelupload/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/excelupload
        public int Post([FromBody] ExcelUploadEntities item)
        {
            var root = System.Web.Hosting.HostingEnvironment.MapPath("~/images/");
            DirectoryInfo di = new DirectoryInfo(root);
            FileInfo[] images = di.GetFiles();
            foreach (FileInfo image in images)
            {
                var name = image.Name;
                if (name.Contains("user.png"))
                {
                    long imageFileLength = image.Length;
                    FileStream fs = new FileStream(root + name, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    var imageData = br.ReadBytes((int)imageFileLength);
                    item.EMPIMG = imageData;
                }
            }
            return _ExcelUpload.CreateExcelupload(item);
        }

        // PUT api/excelupload/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/excelupload/5
        public void Delete(int id)
        {
        }
    }
}

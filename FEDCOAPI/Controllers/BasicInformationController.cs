using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BUSSINESS_SERVICE;
using BUSSINESS_ENTITIES;
using System.IO;
using System.Drawing;

namespace FEDCOAPI.Controllers
{
    public class BasicInformationController : ApiController
    {
        private readonly IBasicinfo _Basicinfo;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
         public BasicInformationController()
        {
            _Basicinfo = new BasicInformationService();
        }
        #endregion
        // GET api/basicinformation
         public HttpResponseMessage Get()
         {
             var Basicinfo = _Basicinfo.GetAllEmployeeBasicinfo();
             if (Basicinfo != null)
             {
                 var BasicinfoEntities = Basicinfo as List<BasicInformaionEntities> ?? Basicinfo.ToList();
                 if (BasicinfoEntities.Any())
                     return Request.CreateResponse(HttpStatusCode.OK, BasicinfoEntities);
             }
             return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Basicinfo not found");
         }
        // GET api/basicinformation/5
         public HttpResponseMessage Get(int id)
         {
             var Basicinfo = _Basicinfo.GetEmployeebasicinfoById(id);
             if (Basicinfo != null)
                 return Request.CreateResponse(HttpStatusCode.OK, Basicinfo);
             return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Basicinfo found for this id");
         }
      
        // POST api/basicinformation
         public int Post([FromBody] BasicInformaionEntities item)
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
             //string[] files = Directory.GetFiles(root, "*.png");
             //foreach (string file in Directory.GetFiles(root))
             //{
             //    var name = file.fo;
             //    if (name.Contains(keyword))
             //    {
             //        imgname = name;
             //    }
             //}
             return _Basicinfo.CreateEmployeebasicinfo(item);
         }
        // PUT api/basicinformation/5
         public bool Put(int id, [FromBody]BasicInformaionEntities item)
         {
             if (id > 0)
             {
                 return _Basicinfo.UpdateEmployeebasicinfo(id, item);
             }
             return false;
         }

        // DELETE api/basicinformation/5
        public void Delete(int id)
        {
        }

        //public static Bitmap ResizeImage(Stream stream, int hght, int wdth)
        //{
        //    System.Drawing.Image originalImage = Bitmap.FromStream(stream);

        //    int height = hght;//150;
        //    int width = wdth; //150;

        //    Bitmap scaledImage = new Bitmap(width, height);

        //    using (Graphics g = Graphics.FromImage(scaledImage))
        //    {
        //        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        //        g.DrawImage(originalImage, 0, 0, width, height);
        //        //  g.DrawString("My photo from " + RadComboBox2.SelectedItem.Text + ", " + RadComboBox1.SelectedItem.Text, new Font("Tahoma", 18), Brushes.White, new PointF(0, 0));
        //        return scaledImage;
        //    }

        //}


        //File Upload
        //[Route("api/district_wise_sor_countapi/Get_District_Wise_SOR_Count/{level1id}/{level2id}/{fromdate}/{todate}/{projectid}")]
//        [HttpPost, Route("api/mpformdata")]
//        public async Task<HttpResponseMessage> PostMpFormData()
//        {
//            if (!Request.Content.IsMimeMultipartContent())
//            {
//                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
//            }
//            return await UseMultipartFormDataStream();
//        }

//        private async Task<HttpResponseMessage> UseMultipartFormDataStream()
//        {
//            string root = HttpContext.Current.Server.MapPath("~/images");
//            var provider = new MultipartFormDataStreamProvider(root);
//            MultipartFormDataContent mpfdc = new MultipartFormDataContent();



//            // DEFINE THE PATH WHERE WE WANT TO SAVE THE FILES.
//            string sPath = "";
//            sPath = System.Web.Hosting.HostingEnvironment.MapPath("~/images/");

//            System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;

           
//            // CHECK THE FILE COUNT.
//            for (int iCnt = 0; iCnt <= hfc.Count - 1; iCnt++)
//            {
//                System.Web.HttpPostedFile hpf = hfc[iCnt];
//                var filepath = string.Empty;
//                var fileNamefuStamp = string.Empty;
//                var physicalPathfuStamp = string.Empty;
//                if (hpf.ContentLength > 0)
//                {
//                    // CHECK IF THE SELECTED FILE(S) ALREADY EXISTS IN FOLDER. (AVOID DUPLICATE)
//                    if (!File.Exists(sPath + Path.GetFileName(hpf.FileName)))
//                    {
//                        // SAVE THE FILES IN THE FOLDER.
//                        Bitmap bitmapImage = ResizeImage(hpf.InputStream, 200, 200);
//                        System.IO.MemoryStream stream = new System.IO.MemoryStream();
//                        bitmapImage.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
//                        var data = stream.ToArray();
//                       // Random r = new Random();
//                       // string code = r.Next().ToString();
//                       // fileNamefuStamp = Path.GetFileName(code + hpf.FileName);
//                       // physicalPathfuStamp = Path.Combine(Server.MapPath("~/Models/"), fileNamefuStamp);
//                        //filepath = "\\images\\Partners\\" + code + x.FileName;
//                        //filepath = code + file.FileName;
//                        File.WriteAllBytes(sPath + Path.GetFileName(hpf.FileName), (data as byte[]));
//                        //file.SaveAs(Server.MapPath("~/images/Partners/" + fileNamefuStamp));
//                        //hpf.SaveAs(sPath + Path.GetFileName(hpf.FileName));
//                        // iUploadedCnt = iUploadedCnt + 1;
//                        BasicInformaionEntities item = new BasicInformaionEntities();
//                        item.EMPLOYEE_IMAGE= Path.GetFileName(hpf.FileName);

//                        item.EMPIMG = data;
//                        string s=hpf.FileName;
//int ix = s.IndexOf('_');
////s = ix != -1 ? s.Substring(ix + 1) : s;
////using the ternary operator here is quite useless, better to write:
////yourStringVariable.Substring(0, ix);
//s = s.Substring(0,ix);





//                        int id = Convert.ToInt32(new String(s.ToCharArray().Where(c => Char.IsDigit(c)).ToArray()));
//                      bool b= _Basicinfo.UpdateEmployeebasicinfo(id, item);
//                    }

//                }
//                //else
//                //{
//                //    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "");
//                //}
//            }

//            var response = Request.CreateResponse();
//            response.StatusCode = HttpStatusCode.OK;
//            return response;

//            //var file = provider.FileData;

//            //if (file != null && file. > 0)
//            //{
//            //   var filename = file.Headers.ContentDisposition.FileName;
//            //    var path = Path.Combine(Server.MapPath("~/App_Data/"), fileName);
//            //    file.SaveAs(path);
//            //}

//            //try
//            //{
//            //    await Request.Content.ReadAsMultipartAsync(provider);

//            //    foreach (MultipartFileData file in provider.FileData)
//            //    {
//            //        var filename = file.Headers.ContentDisposition.FileName;
//            //        Trace.WriteLine(filename);



//            //        Trace.WriteLine("Server file path: " + file.LocalFileName);

//            //        mpfdc.Add(new ByteArrayContent(File.ReadAllBytes(file.LocalFileName)), "File", filename);


//            //         var path = Path.Combine(root, filename);

//            //    }
//            //    var response = Request.CreateResponse();
//            //    response.Content = mpfdc;
//            //    response.StatusCode = HttpStatusCode.OK;
//            //    return response;
//            //}
//            //catch (System.Exception e)
//            //{
//            //    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
//            //}
//        }








    }
}

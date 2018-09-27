using BUSSINESS_ENTITIES;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;


namespace FEDCO_ERP_V1._1.Models
{
    public class SendMail
    {
        HttpClient client;
        string url = System.Configuration.ConfigurationManager.AppSettings["APIUrl"];
    public SendMail()
	{
        client = new HttpClient();
        client.BaseAddress = new Uri(url);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
	}

    public async Task SendScheduleMail()
    {
        string body = string.Empty;
        HttpResponseMessage responseMessagedesignation = await client.GetAsync(url + "basicinformation");

        var responseData = responseMessagedesignation.Content.ReadAsStringAsync().Result;
        //var result = (BasicInformaionEntities)null;
        //if(responseData!=null)
        //{
        //    result = JsonConvert.DeserializeObject<BasicInformaionEntities>(responseData);
        //}
        var result = JsonConvert.DeserializeObject<List<BasicInformaionEntities>>(responseData);
        var birhdaydata=result.Where(x => x.STATUS == "Active").Where(x => x.DATE_OF_BIRTH.HasValue).ToList().Where(y => y.DATE_OF_BIRTH.Value.Day == System.DateTime.Now.Day && y.DATE_OF_BIRTH.Value.Month == System.DateTime.Now.Month).ToList();
        if(birhdaydata.ToList().Count>0)
        {
            foreach(var item in birhdaydata)
            {
                string tomail = item.OFFICIAL_EMAIL;
            }
        }
        try
        {
            using (StreamReader reader = new StreamReader(HostingEnvironment.MapPath("~/Birthdaymail.html")))
            {
                body = reader.ReadToEnd();
            }
        }
        catch(Exception)
        {

        }
        //string birthdayurl = HostingEnvironment.MapPath("http://localhost:56777/images/Birthday.png");
        body = body.Replace("{name}", "Swarup");
        body = body.Replace("{birtdaypic}", "http://enserv.feedbackinfra.com/Images/approve.png");
        using (MailMessage mm = new MailMessage("fedcornd@gmail.com", "swrpmohanty3@gmail.com"))
        {
            mm.Subject = "Provisional Approval";
            //body = PopulateBody();
            mm.Body = body;
            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            //smtp.Host = "openmail.feedbackventures.com";
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential("fedcornd@gmail.com", "fvpl@123");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            try
            {
                smtp.Send(mm);
            }
            catch (Exception ex) 
            {
                var outputLines = new List<string>();
                outputLines.Add(string.Format(
                    "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now,
                    ex.Message, ex.StackTrace, ex.InnerException, ex.HelpLink));

                System.IO.File.AppendAllLines(@"D:\errors.txt", outputLines);
            }
        }

     // Write your send mail code here.
       // System.Net.Mail.MailMessage mailMessage = new MailMessage();
       // mailMessage.From = new MailAddress(FromEmailid); //From Email Id
       // mailMessage.Subject = Subj; //Subject of Email
       // mailMessage.Body = Message; //body or message of Email
       // mailMessage.IsBodyHtml = true;

       //string[] ToMuliId = ToEmail.Split(',');
       // foreach (string ToEMailId in ToMuliId)
       // {
       //     mailMessage.To.Add(new MailAddress(ToEMailId)); //adding multiple TO Email Id
       // }


       // string[] CCId = cc.Split(',');

       // foreach (string CCEmail in CCId)
       // {
       //     mailMessage.CC.Add(new MailAddress(CCEmail)); //Adding Multiple CC email Id
       // }

       // string[] bccid = bcc.Split(',');

       // foreach (string bccEmailId in bccid)
       // {
       //     mailMessage.Bcc.Add(new MailAddress(bccEmailId)); //Adding Multiple BCC email Id
       // }
       // SmtpClient smtp = new SmtpClient();  // creating object of smptpclient
       // smtp.Host = HostAdd;              //host of emailaddress for example smtp.gmail.com etc

       // //network and security related credentials

       // smtp.EnableSsl = true;
       // NetworkCredential NetworkCred = new NetworkCredential();
       // NetworkCred.UserName = mailMessage.From.Address;
       // NetworkCred.word = ;
       // smtp.UseDefaultCredentials = true;
       // smtp.Credentials = NetworkCred;
       // smtp.Port = 587;
       // smtp.Send(mailMessage); //sending Email
    }
    }
}
using FEDCO_ERP_V1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FEDCO_ERP_V1._1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        double inter;
        System.Timers.Timer myTimer = new System.Timers.Timer();
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            // Code that runs on application startup
          
            // Set the Interval to 5 seconds (5000 milliseconds).
            inter = (double)GetNextInterval();
            myTimer.Interval = inter;
            //inter = 86400000;
            myTimer.AutoReset = true;
            myTimer.Elapsed += new ElapsedEventHandler(myTimer_Elapsed);
            myTimer.Enabled = true; 
        }
        public void myTimer_Elapsed(object source, System.Timers.ElapsedEventArgs e)
        {
            inter = 86400000;
            myTimer.Interval = inter;
            SendMail objScheduleMail = new SendMail();
            Task task= objScheduleMail.SendScheduleMail();
           
        }
        private double GetNextInterval()
        {
            string timeString = "05:27 PM";
            DateTime t = DateTime.Parse(timeString);
            TimeSpan ts = new TimeSpan();
            ts = t - System.DateTime.Now;
            if (ts.TotalMilliseconds < 0)
            {
                ts = t.AddDays(1) - System.DateTime.Now;//Here you can increase the timer interval based on your requirments.   
            }
            return ts.TotalMilliseconds;
        }  
    }
}

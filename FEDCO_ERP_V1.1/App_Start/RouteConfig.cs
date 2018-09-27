using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FEDCO_ERP_V1._1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
   name: "SubmitBid",
   url: "Utility/GetEmployeeInfo/{WORKLOCATION}/{division}/{subdivision}/{section}/{department}",
   defaults: new
   {
       controller = "Utility",
       action = "GetEmployeeInfo",
       WORKLOCATION = UrlParameter.Optional,
       division = UrlParameter.Optional,
       subdivision = UrlParameter.Optional,
       section = UrlParameter.Optional,
       department = UrlParameter.Optional
   });
            routes.MapRoute(
  name: "Submiidash",
  url: "Dashboard/GetEmployeeInfofilter/{WORKLOCATIONs}/{divisions}/{subdivisions}/{sections}/{departments}/{designation}/{grade}",
  defaults: new
  {
      controller = "Dashboard",
      action = "GetEmployeeInfofilter",
      WORKLOCATIONs = UrlParameter.Optional,
      divisions = UrlParameter.Optional,
      subdivisions = UrlParameter.Optional,
      sections = UrlParameter.Optional,
      departments = UrlParameter.Optional,
      designation = UrlParameter.Optional,
      grade = UrlParameter.Optional
  });
            routes.MapRoute(
name: "SubmiReport",
url: "Report/GetEmployeeReport/{WORKLOCATIONs}/{divisions}/{subdivisions}/{sections}/{departments}/{designation}/{grade}/{bloodgroup}",
defaults: new
{
    controller = "Report",
    action = "GetEmployeeReport",
    WORKLOCATIONs = UrlParameter.Optional,
    divisions = UrlParameter.Optional,
    subdivisions = UrlParameter.Optional,
    sections = UrlParameter.Optional,
    departments = UrlParameter.Optional,
    designation = UrlParameter.Optional,
    grade = UrlParameter.Optional,
    bloodgroup = UrlParameter.Optional
});

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

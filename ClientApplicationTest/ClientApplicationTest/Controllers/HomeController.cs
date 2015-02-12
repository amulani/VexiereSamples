using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tavisca.Vexiere.ClientApplicationTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            ViewBag.FOCodeFlow = ConfigurationManager.AppSettings["FOCodeFlow"].ToString();
            ViewBag.WebFormCodeFlow = ConfigurationManager.AppSettings["WebFormCodeFlow"].ToString();
            ViewBag.WebFormDotNetOpenAuth = ConfigurationManager.AppSettings["WebFormDotNetOpenAuth"].ToString();
            ViewBag.soapharness = ConfigurationManager.AppSettings["soapharness"].ToString();
            ViewBag.wcfharness = ConfigurationManager.AppSettings["wcfharness"].ToString();
            ViewBag.Implicit = ConfigurationManager.AppSettings["ImplicitFlow"].ToString();
            ViewBag.oauth2 = ConfigurationManager.AppSettings["OAuth2playground"].ToString();
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}

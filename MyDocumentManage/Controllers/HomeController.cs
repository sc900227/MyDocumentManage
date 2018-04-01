using Abp.Web.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDocumentManage.Controllers
{
    public class HomeController :Controller
    {
        //IGeneInfoAppService service;
        //public HomeController() { }
        //public HomeController(IGeneInfoAppService myService) {
        //    service = myService;
        //}
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //var result=service.GetGeneInfosOS();
            //ViewBag.Message = result.ToString();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
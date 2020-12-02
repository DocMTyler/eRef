using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eRef.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Welcome to eRef! eRef is short for electronic referendum. It is a tool built to help connect voters to their elected representatives to see how they affect your life through the legislation they vote on. Have a look around!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "https://docmtyler.github.io/DocMTyler_PortfolioChallenge/";

            return View();
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;

namespace socNetwork.Controllers
{
    public class HomeController : Controller
    {
        private ITextService _svc;
        public HomeController(ITextService svc)
        {
            _svc = svc;
        }

        public ActionResult Index()
        {
            ViewBag.LinkName = _svc.GetText("My test link");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
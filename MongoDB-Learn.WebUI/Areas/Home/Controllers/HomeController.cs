﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MongoDB_Learn.WebUI.Areas.Home.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}
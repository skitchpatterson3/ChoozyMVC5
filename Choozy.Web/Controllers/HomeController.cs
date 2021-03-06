﻿using Choozy.Data.Models;
using Choozy.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Choozy.Web.Controllers
{
    public class HomeController : Controller
    {
        IPersonData db;

        public HomeController(IPersonData db)
        {
            this.db = db;
        }

        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
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

        [HttpGet]
        public ActionResult GetRandom()
        {
            //var model = db.GetAll();
            Person rndPerson = db.GetRandom();
            
            return PartialView("_GetRandom", rndPerson);
        }
    }
}
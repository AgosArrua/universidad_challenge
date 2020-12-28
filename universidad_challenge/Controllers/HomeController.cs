using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using universidad_challenge.Filters;
using universidad_challenge.Models;

namespace universidad_challenge.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
                
    }
}
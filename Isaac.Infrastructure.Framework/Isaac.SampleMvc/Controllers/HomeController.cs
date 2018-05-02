using Isaac.SampleMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Isaac.SampleMvc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult StrongTypeLink()
        {
            return View();
        }

        [HttpPost]
        public ViewResult StrongTypeLink(StrongTypeLinkSample sample)
        {
            if (ModelState.IsValid)
            {
                return View("Thanks", sample);
            }
            else
            {
                return View();
            }
        }

        //public ActionResult Thanks(StrongTypeLinkSample sample)
        //{
        //    return View(sample);
        //}
    }
}
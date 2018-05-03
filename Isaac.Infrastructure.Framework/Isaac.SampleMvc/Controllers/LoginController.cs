using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Isaac.SampleMvc.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login(string userName, string password)
        {
            return View();
        }
    }
}
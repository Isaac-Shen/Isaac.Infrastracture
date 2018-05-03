using Isaac.Infrastructure.Framework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Isaac.SampleMvc.Controllers
{
    public class ManagerController : AdminController
    {
        public ManagerController(ILog logger)
            : base(logger)
        { }

        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }
    }
}
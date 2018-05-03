using Isaac.Infrastructure.Framework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Isaac.SampleMvc.Controllers
{
    public class IssueController : AdminController
    {

        public IssueController(ILog logger)
            : base(logger)
        {
        }

        // GET: Issue
        public ActionResult Index()
        {
            return View();
        }
    }
}
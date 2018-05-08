using Isaac.Infrastructure.Framework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Isaac.SampleMvc.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class AbstractController : Controller
    {

        protected readonly ILog Logger;

        protected AbstractController(ILog logger)
        {
            Logger = logger;
        }

        protected JsonResult Success(object resultObj, JsonRequestBehavior behavior = JsonRequestBehavior.AllowGet)
        {
            return Json(new { success = true, result = resultObj }, behavior);
        }

        protected JsonResult Failure(object resultObj, JsonRequestBehavior behavior = JsonRequestBehavior.AllowGet)
        {
            return Json(new { success = false, result = resultObj }, behavior);
        }
    }
} 
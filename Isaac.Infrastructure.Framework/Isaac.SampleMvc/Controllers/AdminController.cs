using Autofac;
using Isaac.Infrastructure.Framework.Utils;
using Isaac.SampleMvc.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace Isaac.SampleMvc.Controllers
{
    /// <summary>
    /// 管理控制器基类
    /// </summary>
    public class AdminController : Controller
    {
        public AdminController(ILog logger)
            :base()
        {
            _logger = logger;
        }
        
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (requestContext.HttpContext.Request.IsAjaxRequest())
            {
                if (requestContext.HttpContext.User.Identity.IsAuthenticated)
                {
                    if (requestContext.HttpContext.User.Identity is FormsIdentity)
                    {
                        var userAuths = GetUserData<UserAuth>(requestContext.HttpContext.User.Identity as FormsIdentity);
                    }
                }
                else
                {
                    // redirect
                }
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (/*!filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.Equals("login", StringComparison.OrdinalIgnoreCase) &&*/
                filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.HttpContext.Response.Redirect(FormsAuthentication.LoginUrl);
            }

            var userData = 
                GetUserData<UserAuth>(filterContext.HttpContext.User.Identity as FormsIdentity);
            if (userData != null)
            {
                ViewBag.Menus = userData.AuthActions;
            }
            else
            {
                ViewBag.Menu = new List<AuthAction>();
            }

            base.OnActionExecuting(filterContext);
        }

        protected T GetUserData<T>(FormsIdentity id)
            where T : class
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(id.Ticket.UserData);
            }
            catch (Exception exp)
            {
                return default(T);
            }
        }

        protected ILog _logger;
    }
}
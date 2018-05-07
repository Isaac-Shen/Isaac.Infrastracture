using Autofac;
using Isaac.App.Framework.Utils.Logs;
using Isaac.Infrastructure.Framework.Patterns;
using Isaac.Infrastructure.Framework.Utils;
using Isaac.SampleMvc.Dal.Daos;
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
        private readonly AuthDao _authDao;

        public AdminController(ILog logger, AuthDao auth = null)
            :base()
        {
            _logger = logger;

            if (auth == null)
                _authDao = GlobalHandle<ILifetimeScope>.GetCurrentRef().Resolve<AuthDao>();
            else
                _authDao = auth;
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
                ViewBag.Menus = userData.UserActions;
            }
            else
            {
                ViewBag.Menu = new List<UserAction>();
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
        protected ILifetimeScope _container = GlobalHandle<ILifetimeScope>.GetCurrentRef();
    }
}
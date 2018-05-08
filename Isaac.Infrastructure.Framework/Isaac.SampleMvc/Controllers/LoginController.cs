using Isaac.Infrastructure.Framework.Utils;
using Isaac.SampleMvc.Dal.Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Isaac.SampleMvc.Controllers
{
    public class LoginController : AbstractController
    {
        private readonly StaffDao StaffDao;

        /// <summary>
        /// 登录类型
        /// </summary>
        public enum LoginType
        {
            /// <summary>
            /// 手机号
            /// </summary>
            PhoneNumber = 0,

            /// <summary>
            /// 电子邮件
            /// </summary>
            EmailAddress = 1,

            /// <summary>
            /// 员工编号
            /// </summary>
            StaffId = 2
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger">日志</param>
        /// <param name="staffDao">员工查询</param>
        public LoginController(ILog logger, StaffDao staffDao)
            :base(logger)
        {
            StaffDao = staffDao;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Login";

            return View();
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="userId">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="type">登陆类型</param>
        /// <returns></returns>
        public ActionResult Login(string userId, string password, LoginType type = LoginType.PhoneNumber)
        {
            bool isValid = false;
            switch (type)
            {
                case LoginType.StaffId:
                    isValid = StaffDao.ValidatePass(int.Parse(userId), password);
                    break;
                case LoginType.PhoneNumber:
                    isValid = StaffDao.ValidatePhonePass(userId, password);
                    break;
                default:
                    isValid = false;
                    break;
            }

            if (isValid)
            {
                return Success(new { code = HttpStatusCode.OK, url = @"/Home/Index" });
            }
            else
            {
                return Failure(HttpStatusCode.Unauthorized);
            }
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return Success(HttpStatusCode.OK);
        }
    }
}
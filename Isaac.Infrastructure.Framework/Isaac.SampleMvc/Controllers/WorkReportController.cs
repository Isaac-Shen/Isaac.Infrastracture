using Isaac.Infrastructure.Framework.Utils;
using Isaac.SampleMvc.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Isaac.SampleMvc.Controllers
{
    /// <summary>
    /// 工作日报
    /// </summary>
    public class WorkReportController : AdminController
    {
        private readonly WorkReportDao _workReportDao;

        public WorkReportController(ILog logger, WorkReportDao workReportDao)
            : base(logger)
        {
            _workReportDao = workReportDao;
        }

        /// <summary>
        /// 不使用模板写报告
        /// </summary>
        /// <returns></returns>
        public ViewResult NewReport()
        {
            return View();
        }

        /// <summary>
        /// 使用模板写报告
        /// </summary>
        /// <param name="templateId">模板编号</param>
        /// <returns></returns>
        [HttpPost]
        public ViewResult NewReport(string templateId)
        {
            return View();
        }

        /// <summary>
        /// 我的报告列表
        /// </summary>
        /// <param name="pageNum">第几页</param>
        /// <param name="pageLoads">每页承载数量</param>
        /// <returns></returns>
        public ViewResult MyReportList(int pageNum, int pageLoads)
        {
            return View();
        }

        /// <summary>
        /// 某一篇具体的报告内容
        /// </summary>
        /// <param name="reportId">报告编号</param>
        /// <returns></returns>
        public ViewResult Report(string reportId)
        {
            return View();
        }

        /// <summary>
        /// 待恢复报告
        /// </summary>
        /// <param name="pageNum">第几页</param>
        /// <param name="pageLoads">每页承载数量</param>
        /// <returns></returns>
        public ViewResult MyUnreplyReport(int pageNum, int pageLoads)
        {
            return View();
        }

        /// <summary>
        /// 回复列表
        /// </summary>
        /// <param name="pageNum">第几页</param>
        /// <param name="pageLoads">每页承载量</param>
        /// <returns></returns>
        public ViewResult MyReplyList(int pageNum, int pageLoads)
        {
            return View();
        }
    }
}
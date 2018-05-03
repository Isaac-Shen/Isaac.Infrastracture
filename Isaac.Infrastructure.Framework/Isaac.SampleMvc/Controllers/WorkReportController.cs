using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Isaac.SampleMvc.Controllers
{
    public class WorkReportController : Controller
    {
        /// <summary>
        /// 不使用模板写报告
        /// </summary>
        /// <returns></returns>
        public ViewResult WriteReport()
        {
            return View();
        }

        /// <summary>
        /// 使用模板写报告
        /// </summary>
        /// <param name="templateId"></param>
        /// <returns></returns>
        public ViewResult WriteReport(string templateId)
        {
            return View();
        }

        /// <summary>
        /// 指定人员的报告列表
        /// </summary>
        /// <param name="workId">工号集合</param>
        /// <param name="pageNum">第几页</param>
        /// <param name="pageLoads">每页承载数量</param>
        /// <returns></returns>
        [HttpPost]
        public ViewResult ReportList(int workId, int pageNum, int pageLoads)
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
        /// 回复列表
        /// </summary>
        /// <param name="workId">工号</param>
        /// <param name="pageNum">第几页</param>
        /// <param name="pageLoads">每页承载量</param>
        /// <returns></returns>
        public ViewResult ReplyList(int workId, int pageNum, int pageLoads)
        {
            return View();
        }
    }
}
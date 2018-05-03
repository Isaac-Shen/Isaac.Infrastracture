using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.SampleMvc.Models
{
    /// <summary>
    /// 工作日报
    /// </summary>
    public class WorkReport
    {
        /// <summary>
        /// 报告编号
        /// </summary>
        public int Id;

        /// <summary>
        /// 主标题
        /// </summary>
        public string MainTitle { get; set; }

        /// <summary>
        /// 副标题
        /// </summary>
        public string SubTitle { get; set; }

        /// <summary>
        /// 内容(分标题)
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 作者工号
        /// </summary>
        public int AuthorWorkId { get; set; }

        /// <summary>
        /// 作者名称
        /// </summary>
        public string AuthorName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 最新更新时间
        /// </summary>
        public DateTime LastUpdateTime { get; set; }

        /// <summary>
        /// 报告频率
        /// </summary>
        public Frequency ReportFrequency { get; set; }

        /// <summary>
        /// 是否包含附件
        /// </summary>
        public bool HasAttachment { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.SampleMvc.Models
{
    /// <summary>
    /// 工作报告模板
    /// </summary>
    public class WorkReportTemplate
    {
        /// <summary>
        /// 模板编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 模板名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 主标题模板
        /// </summary>
        public string MainTitleTemplate { get; set; }

        /// <summary>
        /// 副标题模板
        /// </summary>
        public string SubTitleTemplate { get; set; }

        /// <summary>
        /// 主题模板
        /// </summary>
        public List<string> TopicTemplate { get; set; }

        /// <summary>
        /// 汇报频率
        /// </summary>
        public Frequency ReportFrequency { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 最新更新时间
        /// </summary>
        public DateTime LastUpdateTime { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.SampleMvc.Models
{
    /// <summary>
    /// 事务模型
    /// </summary>
    public class Issue
    {
        /// <summary>
        /// 工单编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 主题
        /// </summary>
        public string Topic { get; set; }

        /// <summary>
        /// 优先级
        /// </summary>
        public IssuePriority CurrentPriority { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 作者工号
        /// </summary>
        public int AuthorId { get; set; }

        /// <summary>
        /// 作者名称
        /// </summary>
        public string AuthorName { get; set; }

        /// <summary>
        /// 预计截止日期
        /// </summary>
        public DateTime ExpectedDeadline { get; set; }

        /// <summary>
        /// 工单状态
        /// </summary>
        public IssueStatus CurrentStatus { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 最新更新时间
        /// </summary>
        public DateTime LastUpdateTime { get; set; }

        /// <summary>
        /// 是否包含附件
        /// </summary>
        public bool HasAttachment { get; set; }
    }
}

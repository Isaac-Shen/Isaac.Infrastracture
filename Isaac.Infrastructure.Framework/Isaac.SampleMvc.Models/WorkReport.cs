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
        public int report_id;

        /// <summary>
        /// 主标题
        /// </summary>
        public string main_title { get; set; }

        /// <summary>
        /// 副标题
        /// </summary>
        public string sub_title { get; set; }

        /// <summary>
        /// 内容(分标题)
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// 作者工号
        /// </summary>
        public int author_id { get; set; }

        /// <summary>
        /// 作者名称
        /// </summary>
        public string author_name { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime create_time { get; set; }

        /// <summary>
        /// 最新更新时间
        /// </summary>
        public DateTime last_updated_time { get; set; }

        /// <summary>
        /// 报告频率
        /// </summary>
        public Frequency frequency { get; set; }

        /// <summary>
        /// 是否包含附件
        /// </summary>
        public bool has_attachment { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.SampleMvc.Models
{
    /// <summary>
    /// 工作回复
    /// </summary>
    public class WorkReply
    {
        /// <summary>
        /// 回复编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 宿主文章编号
        /// </summary>
        public int BelongTo { get; set; }

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
    }
}

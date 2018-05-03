using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.SampleMvc.Models
{
    /// <summary>
    /// 附件
    /// </summary>
    public class Attachment
    {
        /// <summary>
        /// 附件编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 宿主
        /// </summary>
        public int BelongTo { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public byte[] Content { get; set; }

        /// <summary>
        /// 文件后缀
        /// </summary>
        public string Suffix { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 最新更新时间
        /// </summary>
        public DateTime LastUpdatedTime { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsEnable { get; set; }
    }
}

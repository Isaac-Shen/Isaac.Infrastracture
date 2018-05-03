using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.SampleMvc.Models
{
    /// <summary>
    /// 员工信息
    /// </summary>
    public class Staff
    {
        /// <summary>
        /// 工号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 身份证编号
        /// </summary>
        public string IdentityId { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 电子邮件地址
        /// </summary>
        public string EmailAdd { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 入职时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 最新更新时间
        /// </summary>
        public DateTime LastUpdatedTime { get; set; }

        /// <summary>
        /// 是否激活
        /// </summary>
        public bool IsEnable { get; set; }
    }
}

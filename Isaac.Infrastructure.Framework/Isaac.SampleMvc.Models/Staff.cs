﻿using System;
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
        public int staff_id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string staff_name { get; set; }

        /// <summary>
        /// 身份证编号
        /// </summary>
        public string identity_id { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int gender { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string phone_number { get; set; }

        /// <summary>
        /// 电子邮件地址
        /// </summary>
        public string email_address { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public string department { get; set; }

        /// <summary>
        /// 是否激活
        /// </summary>
        public bool is_enable { get; set; }

        /// <summary>
        /// 入职时间
        /// </summary>
        public DateTime create_time { get; set; }

        /// <summary>
        /// 最新更新时间
        /// </summary>
        public DateTime last_updated_time { get; set; }
    }
}

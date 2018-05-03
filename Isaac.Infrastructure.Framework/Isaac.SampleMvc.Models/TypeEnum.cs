using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.SampleMvc.Models
{
    /// <summary>
    /// 频率
    /// </summary>
    public enum Frequency
    {
        NoFrequency = -1,     //!< null frequency
        Once = 0,             //!< only once, e.g., a zero-coupon
        Annual = 1,           //!< once a year
        Semiannual = 2,       //!< twice a year
        EveryFourthMonth = 3, //!< every fourth month
        Quarterly = 4,        //!< every third month
        Bimonthly = 6,        //!< every second month
        Monthly = 12,         //!< once a month
        EveryFourthWeek = 13, //!< every fourth week
        Biweekly = 26,        //!< every second week
        Weekly = 52,          //!< once a week
        Daily = 365,          //!< once a day
        OtherFrequency = 999  //!< some other unknown frequency
    }

    /// <summary>
    /// 工单状态
    /// </summary>
    public enum IssueStatus
    {
        /// <summary>
        /// 打开
        /// </summary>
        Open,

        /// <summary>
        /// 已解决
        /// </summary>
        Resolved,
        
        /// <summary>
        /// 关闭
        /// </summary>
        Closed,

        /// <summary>
        /// 重新打开
        /// </summary>
        Reopen,

        /// <summary>
        /// 等待评审
        /// </summary>
        Pending,

        /// <summary>
        /// 强制不受理
        /// </summary>
        Scrapped
    }

    /// <summary>
    /// 事务优先级
    /// </summary>
    public enum IssuePriority
    {
        /// <summary>
        /// 极其高
        /// </summary>
        ExtremelyHigh,

        /// <summary>
        /// 高
        /// </summary>
        High,

        /// <summary>
        /// 中等
        /// </summary>
        Medium,

        /// <summary>
        /// 低
        /// </summary>
        Low,

        /// <summary>
        /// 可忽略
        /// </summary>
        Ignore
    }
}

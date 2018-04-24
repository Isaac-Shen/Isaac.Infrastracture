using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.Infrastructure.Framework.Utils
{
    /// <summary>
    /// 日志等级
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// 冗余
        /// </summary>
        Verbose = 1,

        /// <summary>
        /// 追踪
        /// </summary>
        Trace = 2,

        /// <summary>
        /// 调试
        /// </summary>
        Debug = 3,

        /// <summary>
        /// 常规信息
        /// </summary>
        Information = 4,

        /// <summary>
        /// 警告
        /// </summary>
        Warning = 5,

        /// <summary>
        /// 错误
        /// </summary>
        Error = 6,

        /// <summary>
        /// 致命错误
        /// </summary>
        Fatal = 7,

        /// <summary>
        /// 全部包含
        /// </summary>
        All = 1,

        /// <summary>
        /// 关闭
        /// </summary>
        Off = 7,

        /// <summary>
        /// 无日志
        /// </summary>
        None = 7
    }

    /// <summary>
    /// 通用日志接口
    /// </summary>
    public interface ILog
    {
        void Verbose(string message);
        void Trace(string message);
        void Debug(string message);
        void Information(string message);
        void Warning(string message);
        void Error(string message);
        void Error(string message, Exception ex);
        void Fatal(string message);

        void Verbose(bool condition, string message);
        void Trace(bool condition, string message);
        void Debug(bool condition, string message);
        void Information(bool condition, string message);
        void Warning(bool condition, string message);
        void Error(bool condition, string message);
        void Error(bool condition, string message, Exception ex);
        void Fatal(bool condition, string message);

        void Verbose(Func<bool> condition, string message);
        void Trace(Func<bool> condition, string message);
        void Debug(Func<bool> condition, string message);
        void Information(Func<bool> condition, string message);
        void Warning(Func<bool> condition, string message);
        void Error(Func<bool> condition, string message);
        void Fatal(Func<bool> condition, string message);

        bool IsEnabled(LogLevel level);

        bool IsVerboseEnabled { get; }
        bool IsTraceEnabled { get; }
        bool IsDebugEnabled { get; }
        bool IsInformationEnabled { get; }
        bool IsWarningEnabled { get; }
        bool IsErrorEnabled { get; }
        bool IsFatalEnabled { get; }
    }
}

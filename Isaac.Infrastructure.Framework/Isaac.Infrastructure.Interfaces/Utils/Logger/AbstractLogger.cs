using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.Infrastructure.Framework.Utils
{
    /// <summary>
    /// 抽象日志对象，已默认一些行为，方便使用
    /// </summary>
    public abstract class AbstractLogger : ILog
    {
        protected AbstractLogger()
        {
            LogLevel = LogLevel.All;
        }

        public void AtLevel(LogLevel level, string message)
        {
            switch (level)
            {
                case LogLevel.Verbose:
                    {
                        Verbose(message);
                        break;
                    }
                case LogLevel.Trace:
                    {
                        Trace(message);
                        break;
                    }
                case LogLevel.Debug:
                    {
                        Debug(message);
                        break;
                    }
                case LogLevel.Information:
                    {
                        Information(message);
                        break;
                    }
                case LogLevel.Warning:
                    {
                        Warning(message);
                        break;
                    }
                case LogLevel.Error:
                    {
                        Error(message);
                        break;
                    }
                case LogLevel.Fatal:
                    {
                        Fatal(message);
                        break;
                    }
            }
        }

        public abstract void Verbose(string message);
        public abstract void Trace(string message);
        public abstract void Debug(string message);
        public abstract void Warning(string message);
        public abstract void Information(string message);
        public abstract void Error(string message);
        public abstract void Error(string msg, Exception ex);
        public abstract void Fatal(string message);

        public void Verbose(bool condition, string message)
        {
            if (!condition)
            {
                return;
            }

            Verbose(message);
        }

        public void Trace(bool condition, string message)
        {
            if (!condition)
            {
                return;
            }

            Trace(message);
        }

        public void Debug(bool condition, string message)
        {
            if (!condition)
            {
                return;
            }

            Debug(message);
        }

        public void Information(bool condition, string message)
        {
            if (!condition)
            {
                return;
            }

            Information(message);
        }

        public void Warning(bool condition, string message)
        {
            if (!condition)
            {
                return;
            }

            Warning(message);
        }

        public void Error(bool condition, string message)
        {
            if (!condition)
            {
                return;
            }

            Error(message);
        }

        public void Error(bool condition, string message, Exception ex)
        {
            if (!condition)
            {
                return;
            }
            Error(message, ex);
        }

        public void Fatal(bool condition, string message)
        {
            if (!condition)
            {
                return;
            }

            Fatal(message);
        }

        public void Verbose(Func<bool> condition, string message)
        {
            Verbose(condition(), message);
        }

        public void Trace(Func<bool> condition, string message)
        {
            Trace(condition(), message);
        }

        public void Debug(Func<bool> condition, string message)
        {
            Debug(condition(), message);
        }

        public void Information(Func<bool> condition, string message)
        {
            Information(condition(), message);
        }

        public void Warning(Func<bool> condition, string message)
        {
            Warning(condition(), message);
        }

        public void Error(Func<bool> condition, string message)
        {
            Error(condition(), message);
        }

        public void Fatal(Func<bool> condition, string message)
        {
            Fatal(condition(), message);
        }

        public LogLevel LogLevel { get; protected set; }

        public virtual bool IsEnabled(LogLevel level)
        {
            return LogLevel <= level;
        }

        public virtual bool IsVerboseEnabled
        {
            get { return LogLevel < LogLevel.Trace; }
        }

        public virtual bool IsTraceEnabled
        {
            get { return LogLevel < LogLevel.Debug; }
        }

        public virtual bool IsDebugEnabled
        {
            get { return LogLevel < LogLevel.Information; }
        }

        public virtual bool IsInformationEnabled
        {
            get { return LogLevel < LogLevel.Warning; }
        }

        public virtual bool IsWarningEnabled
        {
            get { return LogLevel < LogLevel.Error; }
        }

        public virtual bool IsErrorEnabled
        {
            get { return LogLevel < LogLevel.Fatal; }
        }

        public virtual bool IsFatalEnabled
        {
            get { return true; }
        }
    }
}

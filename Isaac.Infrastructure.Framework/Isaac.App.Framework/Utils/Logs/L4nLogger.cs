using Isaac.Infrastructure.Framework.Utils;
using log4net;
using log4net.Config;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.App.Framework.Utils.Logs
{
    /// <summary>
    /// 使用Log4Net实现的日志记录器
    /// </summary>
    public class L4nLogger : AbstractLogger
    {
        private static bool _needInitialize = true;
        private static readonly object _sychro = new object();
        private readonly log4net.ILog _logger;

        public L4nLogger()
        {
            lock (_sychro)
            {
                if (_needInitialize)
                {
                    XmlConfigurator.Configure();
                    _needInitialize = false;
                }
            }

            LogLevel = LogLevel.Off;
            _logger = LogManager.GetLogger(this.GetType());
        }

        public override void Verbose(string message)
        {
            if (_logger.Logger.IsEnabledFor(Level.Verbose))
            {
                _logger.DebugFormat("Verbose: {0}", message);
            }
        }

        public override void Trace(string message)
        {
            if (_logger.Logger.IsEnabledFor(Level.Trace))
            {
                _logger.DebugFormat("Trace: {0}", message);
            }
        }

        public override void Debug(string message)
        {
            _logger.Debug(message);
        }

        public override void Warning(string message)
        {
            _logger.Warn(message);
        }

        public override void Information(string message)
        {
            _logger.Info(message);
        }

        public override void Error(string message)
        {
            _logger.Error(message);
        }

        public override void Error(string message, Exception ex)
        {
            _logger.Error(message, ex);
        }

        public override void Fatal(string message)
        {
            _logger.Fatal(message);
        }
    }
}

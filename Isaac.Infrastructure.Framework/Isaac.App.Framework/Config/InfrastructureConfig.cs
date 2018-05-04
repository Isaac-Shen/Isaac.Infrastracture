using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.App.Framework.Config
{
    public class InfrastructureConfig
    {
        private static string IOC_CONFIG_KEY = "autofac:ConfigLocation";
        private static string BUNDLE_CONFIG_KEY = "bundle:Optimizations";

        /// <summary>
        /// IOC 配置文件路径
        /// </summary>
        public static string IOC_CONFIG_FILE_LOCATION
        {
            get
            {
                if (ConfigurationManager.AppSettings.AllKeys.Contains(IOC_CONFIG_KEY))
                {
                    return string.Format(
                        "{0}{1}",
                        AppDomain.CurrentDomain.BaseDirectory,
                        ConfigurationManager.AppSettings[IOC_CONFIG_KEY]);
                }
                else
                {
                    return String.Empty;
                }
            }
        }

        /// <summary>
        /// 是否启用Bundle优化
        /// </summary>
        public static bool BUNDLE_OPTIMIZATIONS
        {
            get
            {
                if (ConfigurationManager.AppSettings.AllKeys.Contains(BUNDLE_CONFIG_KEY))
                {
                    bool result = false;
                    if (Boolean.TryParse(ConfigurationManager.AppSettings[BUNDLE_CONFIG_KEY], out result))
                    {
                        return result;
                    }
                }

                return false;
            }
        }

        /// <summary>
        /// 设置IOC配置键值
        /// </summary>
        /// <param name="iocKey">IOC键值</param>
        public static void SetIOCConfigKey(string iocKey)
        {
            if (string.IsNullOrEmpty(iocKey))
                IOC_CONFIG_KEY = iocKey;
        }

        /// <summary>
        /// 设置Bundle优化键值
        /// </summary>
        /// <param name="bundleKey">Bundle优化键值</param>
        public static void SetBundleConfigKey(string bundleKey)
        {
            if (string.IsNullOrEmpty(bundleKey))
                BUNDLE_CONFIG_KEY = bundleKey;
        }

    }
}

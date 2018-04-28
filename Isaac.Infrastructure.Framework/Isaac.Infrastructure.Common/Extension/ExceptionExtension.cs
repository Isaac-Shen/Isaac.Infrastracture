using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.Infrastructure.Common.Extension
{
    public static class ExceptionExtension
    {
        public static string AllMessage(this Exception exception)
        {
            if (exception.InnerException != null)
            {
                return string.Format("[{2}]{0}\n-->{1}", 
                    exception.Message, 
                    exception.InnerException.AllMessage(),
                    exception.GetType().Name);
            }
            else
            {
                return exception.Message;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.App.Framework.Utils.InitialLoad
{
    public interface ILoadSuccess
    {
        void NotifyAll(Action notifyAction);
    }

    public class LoadSuccess : ILoadSuccess
    {
        public void NotifyAll(Action notifyAction = null)
        {
            if (notifyAction == null)
            {
                notifyAction = () => Console.WriteLine("Initialization successfully completed!");
            }

            notifyAction();
        }
    }
}

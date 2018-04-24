using Autofac;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.App.Framework.Utils.InitialLoad
{
    public abstract class AbstractLoad<T> : IInterceptor
    {
        protected AbstractLoad(Func<T> loadAction, ContainerBuilder builder)
        {
            _builder = builder;
            GetAction = loadAction;
        }

        public Func<T> GetAction
        {
            get
            {
                return _getAction;
            }
            set
            {
                _getAction = value ?? DefaultAction;
            }
        }
        private Func<T> _getAction;

        protected ContainerBuilder _builder;

        public abstract T DefaultAction();

        public virtual void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
        }
    }
}

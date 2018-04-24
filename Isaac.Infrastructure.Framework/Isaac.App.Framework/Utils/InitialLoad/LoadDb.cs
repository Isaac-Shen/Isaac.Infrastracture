using Autofac;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.App.Framework.Utils.InitialLoad
{
    public class LoadDb : AbstractLoad<string>, IComparable<LoadDb>
    {
        public LoadDb(string name, Type dbType, Func<string> action, ContainerBuilder builder)
            : base(action, builder)
        {
            Name = name;
            builder.RegisterType(dbType).As(dbType).Named(name, dbType);
        }

        public override string DefaultAction()
        {
            if (ConfigurationManager.ConnectionStrings[_name] != null)
            {
                return ConfigurationManager.ConnectionStrings[_name].ConnectionString;
            }
            else
            {
                throw new Exception(string.Format(
                    "Default action is activated but there seems no db config named {0} in your app.config", _name));
            }
        }

        public int CompareTo(LoadDb other)
        {
            if (other != null)
            {
                return Name.CompareTo(other.Name);
            }
            else
            {
                return -1;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name");
                }
                else
                {
                    _name = value;
                }
            }
        }
        private string _name;
    }
}

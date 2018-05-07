using Autofac;
using Autofac.Core;
using DapperExtensions;
using DapperExtensions.Mapper;
using DapperExtensions.Sql;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.App.Framework.DataServices
{
    public class DataService
    {
        public enum DatabseType
        {
            SqlServer,
            MySql,
            Oracle
        }

        public DataService(string name, string connStr, Type dataServiceType)
        {
            if (dataServiceType.IsSubclassOf(typeof(AbstractDapperDatabase)))
            {
                Name = name;
                ConnectionString = connStr;
                DatabaseType = dataServiceType;
            }
            else
            {
                throw new ArgumentOutOfRangeException("DatabaseType");
            }
        }

        public string Name { get; set; }
        public string ConnectionString { get; set; }
        public Type DatabaseType { get; set; }

        public static void LoadSqlServerService(ContainerBuilder builder, List<DataService> services)
        {
            //注册DapperExtensions配置
            builder.RegisterType<DapperExtensionsConfiguration>()
                .As<IDapperExtensionsConfiguration>()
                .WithParameters(new[]
                {
                    new NamedParameter("defaultMapper",typeof(AutoClassMapper<>)),
                    new NamedParameter("mappingAssemblies",GetClassMapperAssemblies()),
                    new NamedParameter("sqlDialect",new SqlServerDialect()),
                }).SingleInstance();

            //注册DapperExtensions的Sql生成器
            builder.RegisterType<SqlGeneratorImpl>().As<ISqlGenerator>().SingleInstance();

            //数据库连接字符串对象配置
            builder.RegisterType<SqlConnection>().As<IDbConnection>();

            RegisterService(builder, services);
        }

        public static void LoadMySqlService(ContainerBuilder builder, List<DataService> services)
        {
            //注册DapperExtensions配置
            builder.RegisterType<DapperExtensionsConfiguration>()
                .As<IDapperExtensionsConfiguration>()
                .WithParameters(new[]
                {
                    new NamedParameter("defaultMapper",typeof(AutoClassMapper<>)),
                    new NamedParameter("mappingAssemblies",GetClassMapperAssemblies()),
                    new NamedParameter("sqlDialect",new MySqlDialect()),
                }).SingleInstance();

            //注册DapperExtensions的Sql生成器
            builder.RegisterType<SqlGeneratorImpl>().As<ISqlGenerator>().SingleInstance();

            //数据库连接字符串对象配置
            builder.RegisterType<MySqlConnection>().As<IDbConnection>();

            RegisterService(builder, services);
        }

        [Obsolete("Unimplemented still")]
        public static void LoadOracleService(ContainerBuilder builder, List<DataService> services)
        {
            throw new NotImplementedException();
        }
        
        private static List<Assembly> GetClassMapperAssemblies()
        {
            var config = ConfigurationManager.AppSettings["dapper_mapper_assemblies"];
            if (string.IsNullOrEmpty(config))
            {
                return new List<Assembly> { Assembly.GetAssembly(typeof(DataService)) };
            }

            var assemblies = config.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            var list = new List<Assembly>(assemblies.Length);
            list.AddRange(assemblies.Select(Assembly.Load));
            return list;
        }

        private static void RegisterService(ContainerBuilder builder, List<DataService> services)
        {
            foreach (var item in services)
            {
                try
                {
                    builder.RegisterType(item.DatabaseType).As(item.DatabaseType)
                           .OnPreparing(e =>
                           {
                               e.Parameters = new List<Parameter>(e.Parameters)
                               {
                               new NamedParameter(
                                   "connection",
                                   e.Context.Resolve<IDbConnection>(
                                       new NamedParameter("connectionString",item.ConnectionString)))
                               };
                           });
                }
                catch (Exception exp)
                {
                    throw new TypeInitializationException(item.DatabaseType.FullName, exp);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.App.Framework.Utils.Mapper
{
    public class ObjectMapper
    {
        public static void LoadMapperProfile(params Assembly[] assemblies)
        {
            AutoMapper.Mapper.Initialize(
                config => {
                    config.AddProfiles(assemblies);
                });

            AutoMapper.Mapper.AssertConfigurationIsValid();
        }
    }
}

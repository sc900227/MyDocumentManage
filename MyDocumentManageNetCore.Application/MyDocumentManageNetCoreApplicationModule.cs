using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManageNetCore.Application
{
    [DependsOn(typeof(AbpAutoMapperModule))]
    public class MyDocumentManageNetCoreApplicationModule:AbpModule
    {
        public override void Initialize()
        {
            var thisAssembly = typeof(MyDocumentManageNetCoreApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}

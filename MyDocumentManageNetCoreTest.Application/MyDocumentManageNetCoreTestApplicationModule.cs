using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using System;

namespace MyDocumentManageNetCoreTest.Application
{
    [DependsOn(typeof(AbpAutoMapperModule))]
    public class MyDocumentManageNetCoreTestApplicationModule: AbpModule
    {
        public override void Initialize()
        {
            var thisAssembly = typeof(MyDocumentManageNetCoreTestApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}

using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyDocumentManageNetCore.Domain;
using System;

namespace MyDocumentManageNetCore.Application
{
    [DependsOn(typeof(MyDocumentManageNetCoreDomainModule),typeof(AbpAutoMapperModule))]
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

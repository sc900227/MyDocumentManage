
using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyDocumentManage.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManage.Application
{
    
    [DependsOn(typeof(MyDocumentManageDomainModule),typeof(AbpAutoMapperModule))]
    public class MyDocumentManageApplicationModule:AbpModule
    {
        public override void Initialize()
        {
            var thisAssembly = typeof(MyDocumentManageApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);
            
            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}

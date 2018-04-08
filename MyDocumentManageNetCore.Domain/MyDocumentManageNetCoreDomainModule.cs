using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyDocumentManageNetCore.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManageNetCore.Domain
{
    [DependsOn(typeof(MyDocumentManageNetCoreApplicationModule),typeof(AbpAspNetCoreModule))]
    public class MyDocumentManageNetCoreDomainModule:AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAspNetCore()
                 .CreateControllersForAppServices(
                     typeof(MyDocumentManageNetCoreApplicationModule).Assembly,moduleName:"app",useConventionalHttpVerbs:true
                 );
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}

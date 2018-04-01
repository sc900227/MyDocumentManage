using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;
using MyDocumentManage.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MyDocumentManage.App_Start
{
    [DependsOn(typeof(AbpWebApiModule),typeof(MyDocumentManageApplicationModule))]
    public class MyDocumentManageModule:AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(MyDocumentManageApplicationModule).Assembly, "MyDocumentManage")
                .WithConventionalVerbs()
                .Build();
        }
        public override void PreInitialize()
        {
            Configuration.Modules.AbpWeb().AntiForgery.IsEnabled = false;
        }
    }
}
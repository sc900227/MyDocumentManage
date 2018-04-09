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
using Abp.EntityFramework;
using MyDocumentMange.EntityFramework;
using MyDocumentManage.Domain;

namespace MyDocumentManage.App_Start
{
    [DependsOn(typeof(AbpWebApiModule),typeof(MyDocumentManageApplicationModule),typeof(MyDocumentMangeEntityFrameworkModule),typeof(MyDocumentManageDomainModule))]
    public class MyDocumentManageModule:AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(MyDocumentManageApplicationModule).Assembly, "MyDocumentManage")
                .Build();
        }
        public override void PreInitialize()
        {
            Configuration.Modules.AbpWeb().AntiForgery.IsEnabled = false;
        }
    }
}
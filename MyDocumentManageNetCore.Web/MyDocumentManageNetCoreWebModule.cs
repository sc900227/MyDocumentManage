using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.AspNetCore.SignalR;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MyDocumentManageNetCore.Application;
using MyDocumentManageNetCore.Domain;
using MyDocumentManageNetCore.Domain.Configuration;
using MyDocumentManageNetCoreTest.Application;
using MyDocumentMange.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MyDocumentManageNetCore.Web
{
    [DependsOn(
        typeof(AbpAspNetCoreModule),
        typeof(AbpAspNetCoreSignalRModule),
        typeof(MyDocumentManageNetCoreDomainModule),
         typeof(MyDocumentManageNetCoreApplicationModule),
         typeof(MyDocumentMangeEntityFrameworkCoreModule)
         )]
    public class MyDocumentManageNetCoreWebModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;
        public MyDocumentManageNetCoreWebModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }
        public override void PreInitialize()
        {

            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                "mydb"
            );
            Configuration.Modules.AbpAspNetCore()
                 .CreateControllersForAppServices(
                     typeof(MyDocumentManageNetCoreApplicationModule).GetAssembly()
                 );

        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyDocumentManageNetCoreWebModule).GetAssembly());
        }
    }
}

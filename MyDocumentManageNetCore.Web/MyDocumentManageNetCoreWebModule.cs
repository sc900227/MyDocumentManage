using Abp.Modules;
using MyDocumentManageNetCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MyDocumentManageNetCore.Web
{
    [DependsOn(typeof(MyDocumentManageNetCoreDomainModule))]
    public class MyDocumentManageNetCoreWebModule:AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}

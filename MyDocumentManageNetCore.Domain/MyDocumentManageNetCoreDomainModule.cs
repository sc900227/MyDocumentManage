using Abp.Modules;
using System;
using System.Reflection;

namespace MyDocumentManageNetCore.Domain
{
    public class MyDocumentManageNetCoreDomainModule:AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}

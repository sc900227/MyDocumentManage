
using Abp.Modules;
using Abp.NHibernate;
using Abp.Reflection.Extensions;
using MyDocumentManage.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManage.Domain
{
    [DependsOn(typeof(MyDocumentManageInfrastructureModule))]
    public class MyDocumentManageDomainModule:AbpModule
    {
        
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}

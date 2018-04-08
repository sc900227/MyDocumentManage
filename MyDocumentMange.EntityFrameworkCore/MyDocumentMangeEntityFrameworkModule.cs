using Abp.Modules;
using MyDocumentManage.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentMange.EntityFrameworkCore
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(AbpEntityFrameworkCoreModule), typeof(MyDocumentManageInfrastructureModule))]
    public class MyDocumentMangeEntityFrameworkModule:AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}

using Abp.EntityFramework;
using Abp.Modules;
using MyDocumentManage.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentMange.EntityFramework
{
    [DependsOn(typeof(AbpEntityFrameworkModule))]
    public class MyDocumentMangeEntityFrameworkModule:AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<LocalDbContext>(null);
            Configuration.DefaultNameOrConnectionString = "mydb";
            Configuration.UnitOfWork.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;

        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}

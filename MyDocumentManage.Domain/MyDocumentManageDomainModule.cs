
using Abp.Dapper;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.EntityFramework;
using Abp.Modules;
using Abp.NHibernate;
using Abp.Reflection.Extensions;
using MyDocumentManage.Domain.Entitys;
using MyDocumentManage.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManage.Domain
{
    [DependsOn(typeof(MyDocumentManageInfrastructureModule))]
    public class MyDocumentManageDomainModule:AbpModule
    {
        //public override void PreInitialize()
        //{
        //    Database.SetInitializer<LocalDbContext>(null);
        //    Configuration.DefaultNameOrConnectionString = "mydb";
        //    Configuration.UnitOfWork.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;

        //}
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}

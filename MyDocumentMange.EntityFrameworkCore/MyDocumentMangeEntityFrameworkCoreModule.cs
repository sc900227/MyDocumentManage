using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Castle.Core.Configuration;
using System;
using System.Reflection;

namespace MyDocumentMange.EntityFrameworkCore
{
    [DependsOn(typeof(AbpEntityFrameworkCoreModule))]
    public class MyDocumentMangeEntityFrameworkCoreModule:AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<LocalCoreDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        MyDocumentManageDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        MyDocumentManageDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            //IocManager.Register<IConfiguration>(Abp.Dependency.DependencyLifeStyle.Singleton);
        }
    }
}

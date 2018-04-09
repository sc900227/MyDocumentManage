using Abp.Dependency;
using Castle.Windsor.Installer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyDocumentManageNetCore.Domain.Configuration;
using MyDocumentManageNetCore.Domain.Web;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyDocumentMange.EntityFrameworkCore
{
    public class LocalDbContextOption: ISingletonDependency
    {
        public DbContextOptions<LocalCoreDbContext> GetDbContextOption() {
            var builder = new DbContextOptionsBuilder<LocalCoreDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            MyDocumentManageDbContextConfigurer.Configure(builder, configuration.GetConnectionString("mydb"));

            return builder.Options;
        }
    }
}

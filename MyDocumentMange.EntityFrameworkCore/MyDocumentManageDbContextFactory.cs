using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MyDocumentManageNetCore.Domain.Configuration;
using MyDocumentManageNetCore.Domain.Web;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyDocumentMange.EntityFrameworkCore
{
    public class MyDocumentManageDbContextFactory: IDesignTimeDbContextFactory<LocalCoreDbContext>
    {
        public LocalCoreDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<LocalCoreDbContext>();
            //var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            MyDocumentManageDbContextConfigurer.Configure(builder, AppConfigurtaionServices.GetAppSettings()["ConnectionStrings:mydb"]);

            return new LocalCoreDbContext();
        }
    }
}

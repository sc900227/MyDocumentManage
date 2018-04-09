using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace MyDocumentMange.EntityFrameworkCore
{
    public static class MyDocumentManageDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<LocalCoreDbContext> builder, string connectionString)
        {
            builder.UseSqlite(connectionString);

        }

        public static void Configure(DbContextOptionsBuilder<LocalCoreDbContext> builder, DbConnection connection)
        {
            builder.UseSqlite(connection);
        }
    }
}

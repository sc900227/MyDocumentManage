﻿using Abp.EntityFramework;
using MyDocumentManage.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentMange.EntityFramework
{
    public class LocalDbContext:AbpDbContext
    {
        public virtual IDbSet<TB_GeneInfo> GeneInfo { get; set; }
        public virtual IDbSet<TB_GeneTypeResult> GeneTypeResult { get; set; }
        public virtual IDbSet<TB_ReagentInfo> ReagentInfo { get; set; }
        // 数据库连接串
        //private static string connString = string.Format("data source={0};", @"D:\Document\ReportDB.db");
        //private static DbConnection conn=new SQLiteConnection(connString);

        public LocalDbContext() : base("mydb") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TB_GeneInfo>().ToTable("TB_GeneInfo").HasKey(a => a.ID);
            modelBuilder.Entity<TB_GeneTypeResult>().ToTable("TB_GeneTypeResult").HasKey(a => a.ID);
            modelBuilder.Entity<TB_ReagentInfo>().ToTable("TB_ReagentInfo").HasKey(a => a.ID);
        }
    }
}

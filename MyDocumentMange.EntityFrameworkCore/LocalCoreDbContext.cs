using Abp.Dependency;
using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyDocumentManageNetCore.Domain.Configuration;
using MyDocumentManageNetCore.Domain.Entitys;
using MyDocumentManageNetCore.Domain.Web;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace MyDocumentMange.EntityFrameworkCore
{
    public class LocalCoreDbContext:AbpDbContext
    {
        public virtual DbSet<TB_GeneInfo> GeneInfo { get; set; }
        public virtual DbSet<TB_GeneTypeResult> GeneTypeResult { get; set; }
        public virtual DbSet<TB_ReagentInfo> ReagentInfo { get; set; }
        
        public LocalCoreDbContext() : base(IocManager.Instance.Resolve<LocalDbContextOption>().GetDbContextOption()) { }
    }
}

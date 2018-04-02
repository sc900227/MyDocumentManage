using Abp.Dapper.Repositories;
using Abp.Dependency;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;
using MyDocumentManage.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManage.Domain.Repositorys.ReagentInfo
{
    public class ReagentInfoRep: EfRepositoryBase<LocalDbContext,TB_ReagentInfo, Int64>, IReagentInfoRep
    {
        //public ReagentInfoRep(LocalDbActiveTransactionProvider DbActive) : base(DbActive) { }
        public ReagentInfoRep(IDbContextProvider<LocalDbContext> DbContext):base(DbContext) { }
    }
}

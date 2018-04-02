using Abp.Dapper.Repositories;
using Abp.Dependency;
using MyDocumentManage.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManage.Domain.Repositorys.ReagentInfo
{
    public class ReagentInfoRep: DapperRepositoryBase<TB_ReagentInfo,Int64>, IReagentInfoRep
    {
        public ReagentInfoRep() : base(IocManager.Instance.Resolve<LocalDbActiveTransactionProvider>()) { }
    }
}

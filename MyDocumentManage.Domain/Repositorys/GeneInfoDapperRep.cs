using Abp.Dapper.Repositories;
using Abp.Dependency;
using MyDocumentManage.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManage.Domain.Repositorys
{
    public class GeneInfoDapperRep: DapperRepositoryBase<TB_GeneInfo,Int64>,IGeneInfoDapperRep
    {
        public GeneInfoDapperRep(): base(IocManager.Instance.Resolve<LocalDbActiveTransactionProvider>()) { }
    }
}

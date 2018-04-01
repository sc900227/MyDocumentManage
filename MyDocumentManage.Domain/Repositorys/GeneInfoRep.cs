using Abp.Dependency;
using MyDocumentManage.Domain;
using MyDocumentManage.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDocumentManage.Infrastructure;
using Abp.NHibernate.Repositories;

namespace MyDocumentManage.Domain.Repositorys
{
    public class GeneInfoRep: NhRepositoryBase<TB_GeneInfo, Int64>, IGeneInfoRep
    {
        public GeneInfoRep()
        : base(IocManager.Instance.Resolve<LocalDbSessionProvider>())
        { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using MyDocumentManage.Domain;
using MyDocumentManage.Domain.Entitys;
using MyDocumentManage.Infrastructure;

namespace MyDocumentManage.Domain.Repositorys
{
    public class GeneInfoQueryService : BaseQueryService, IGeneInfoQueryService
    {
        public GeneInfoQueryService() : base(IocManager.Instance.Resolve<LocalDbSessionProvider>()) { }
        public IList<TB_GeneInfo> SearchGeneInfos(string keyword)
        {
            IList<TB_GeneInfo> list= Query<TB_GeneInfo>("select * from TB_GeneInfo").ToList();
            return list;
        }
    }
}

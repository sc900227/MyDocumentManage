using Abp.Domain.Repositories;
using MyDocumentManage.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManage.Domain.Repositorys
{
    public interface IGeneInfoRep:IRepository<TB_GeneInfo,Int64>

    {
    }
}

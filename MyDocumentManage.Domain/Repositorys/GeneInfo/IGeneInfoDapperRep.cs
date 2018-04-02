using Abp.Dapper.Repositories;
using MyDocumentManage.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManage.Domain.Repositorys.GeneInfo
{
    public interface IGeneInfoDapperRep:IDapperRepository<TB_GeneInfo,Int64>
    {
    }
}

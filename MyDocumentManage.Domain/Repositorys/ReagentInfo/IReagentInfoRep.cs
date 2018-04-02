using Abp.Dapper.Repositories;
using MyDocumentManage.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManage.Domain.Repositorys.ReagentInfo
{
    public interface IReagentInfoRep:IBaseDapperRepository<TB_ReagentInfo, Int64> //IDapperRepository<TB_ReagentInfo,Int64>
    {
    }
}

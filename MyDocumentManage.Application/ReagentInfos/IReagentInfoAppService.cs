using Abp.Application.Services;
using MyDocumentManage.Application.ReagentInfos.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MyDocumentManage.Application.ReagentInfos
{
    public interface IReagentInfoAppService: IApplicationService
    {
        [HttpGet]
        List<ReagentInfoDto> GetReagentInfos();

        [HttpPost]
        ReagentInfoDto CreateReagentInfo(CreateReagentInfoDto input);


        [HttpPost]
        ReagentInfoDto UpdateReagentInfo(ReagentInfoDto input);


        [HttpPost]
        void DeleteReagentInfo(Int64 id);
        [HttpGet]
        Int64 GetMaxID();
       
    }
}

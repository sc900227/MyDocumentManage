using Abp.Application.Services;
using MyDocumentManage.Application.ReagentInfos.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManage.Application.ReagentInfos
{
    public interface IReagentInfoAppService: IApplicationService
    {
        List<ReagentInfoDto> GetReagentInfos();


        ReagentInfoDto CreateReagentInfo(CreateReagentInfoDto input);



        ReagentInfoDto Update(ReagentInfoDto input);



        void Delete(Int64 id);
       
    }
}

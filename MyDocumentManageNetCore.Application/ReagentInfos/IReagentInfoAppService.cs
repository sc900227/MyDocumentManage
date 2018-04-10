using Abp.Application.Services;
using Microsoft.AspNetCore.Mvc;
using MyDocumentManageNetCore.Application.ReagentInfos.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManageNetCore.Application.ReagentInfos
{
    public interface IReagentInfoAppService: IApplicationService
    {
        
        Task<List<ReagentInfoDto>> GetReagentInfos();

        
        Task<ReagentInfoDto> CreateReagentInfo(CreateReagentInfoDto input);


        
        Task<ReagentInfoDto> UpdateReagentInfo(ReagentInfoDto input);


        
        Task DeleteReagentInfo(Int64 id);
        
       
    }
}

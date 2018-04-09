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
        [HttpGet]
        Task<List<ReagentInfoDto>> GetReagentInfos();

        [HttpPost]
        Task<ReagentInfoDto> CreateReagentInfo(CreateReagentInfoDto input);


        [HttpPost]
        Task<ReagentInfoDto> UpdateReagentInfo(ReagentInfoDto input);


        [HttpPost]
        Task DeleteReagentInfo(Int64 id);
        
       
    }
}

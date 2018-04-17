using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using MyDocumentManageNetCore.Application.GeneInfos.Dto;
using MyDocumentManageNetCore.Application.UserInfos.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManageNetCore.Application.UserInfos
{
    public interface IGeneInfoAppService: IApplicationService
    {
        
        PagedResultDto<GeneInfoDto> GetReagentInfosPage(GetGeneInfosInput input);
        Task<List<GeneInfoDto>> GetGeneInfos();
        
        Task<GeneInfoDto> CreateGeneInfo(CreateGeneInfoDto input);

      
        Task<GeneInfoDto> UpdateGeneInfo(GeneInfoDto input);

        
        Task DeleteGeneInfo(Int64 id);
        
    }
}

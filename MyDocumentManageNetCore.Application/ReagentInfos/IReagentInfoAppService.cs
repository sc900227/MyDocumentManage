﻿using Abp.Application.Services;
using Abp.Application.Services.Dto;
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
        Task<List<ReagentGeneTypeTestResultDto>> GetReagentGeneTypeTestResults(Int64 reagentId);
        Task<List<ReagentGeneInfoDto>> GetReagentGeneInfos();
        Task<List<ReagentGeneInfoDto>> GetReagentGeneInfosById(Int64 id);
        PagedResultDto<ReagentInfoDto> GetReagentInfosPage(GetReagentInfosInput input);
        Task<List<ReagentInfoDto>> GetReagentInfos();

        
        Task<ReagentInfoDto> CreateReagentInfo(CreateReagentInfoDto input);


        
        Task<ReagentInfoDto> UpdateReagentInfo(ReagentInfoDto input);


        
        Task DeleteReagentInfo(Int64 id);
        
       
    }
}

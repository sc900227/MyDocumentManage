using Abp.Application.Services;
using Microsoft.AspNetCore.Mvc;
using MyDocumentManageNetCore.Application.GeneTypeResults.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManageNetCore.Application.GeneTypeResults
{
    public interface IGeneTypeResultAppService: IApplicationService
    {
        Task<List<GeneTypeTestResultDto>> GetGeneTypeTestResults(Int64 reagentId);
        Task<List<GeneTypeResultDto>> GetGeneTypeResults();
        
        Task<GeneTypeResultDto> CreateGeneTypeResult(CreateGeneTypeResultDto input);

        
        Task<GeneTypeResultDto> UpdateGeneTypeResult(GeneTypeResultDto input);

        
        Task DeleteGeneTypeResult(Int64 id);
        Task DeleteGeneTypeResultByReagentId(Int64 reagentId);
    }
}

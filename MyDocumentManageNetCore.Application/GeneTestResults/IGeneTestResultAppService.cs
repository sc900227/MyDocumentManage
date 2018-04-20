using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyDocumentManageNetCore.Application.GeneTestResults.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManageNetCore.Application.GeneTestResults
{
    public interface IGeneTestResultAppService: IApplicationService
    {
        Task<List<GeneTestResultDto>> GetGeneTestResults(Int64 geneTypeResultId);
        PagedResultDto<GeneTestResultDto> GetReagentInfosPage(GetGeneTestResultsInput input);
        


        Task<GeneTestResultDto> CreateReagentInfo(CreateGeneTestResultDto input);



        Task<GeneTestResultDto> UpdateReagentInfo(GeneTestResultDto input);

        Task DeleteGeneTestResult(Int64 id);
    }
}

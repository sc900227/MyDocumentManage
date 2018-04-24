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
        Task<List<GeneTestResultDto>> CreateGeneTestResults(List<CreateGeneTestResultDto> input);
        Task<List<GeneTestResultDto>> GetGeneTestResults(Int64 geneTypeResultId);
        PagedResultDto<GeneTestResultDto> GetGeneTestResultsPage(GetGeneTestResultsInput input);
        


        Task<GeneTestResultDto> CreateGeneTestResult(CreateGeneTestResultDto input);



        Task<GeneTestResultDto> UpdateGeneTestResult(GeneTestResultDto input);

        Task DeleteGeneTestResult(Int64 id);
    }
}

using Abp.Application.Services;
using MyDocumentManage.Application.GeneTypeResults.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MyDocumentManageNetCoreTest.Application.GeneTypeResults
{
    public interface IGeneTypeResultAppService: IApplicationService
    {
        [HttpGet]
        Task<List<GeneTypeResultDto>> GetGeneTypeResults();
        [HttpPost]
        Task<GeneTypeResultDto> CreateGeneTypeResult(CreateGeneTypeResultDto input);

        [HttpPost]
        Task<GeneTypeResultDto> UpdateGeneTypeResult(GeneTypeResultDto input);

        [HttpPost]
        Task DeleteGeneTypeResult(GeneTypeResultDto input);
    }
}

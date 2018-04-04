using Abp.Application.Services;
using MyDocumentManage.Application.GeneTypeResults.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MyDocumentManage.Application.GeneTypeResults
{
    public interface IGeneTypeResultAppService: IApplicationService
    {
        [HttpGet]
        List<GeneTypeResultDto> GetGeneTypeResults();
        [HttpPost]
        GeneTypeResultDto CreateGeneTypeResult(CreateGeneTypeResultDto input);

        [HttpPost]
        GeneTypeResultDto UpdateGeneTypeResult(GeneTypeResultDto input);

        [HttpPost]
        void DeleteGeneTypeResult(GeneTypeResultDto input);
    }
}

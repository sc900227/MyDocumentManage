using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyDocumentManage.Application.UserInfos.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MyDocumentManage.Application.UserInfos
{
    public interface IGeneInfoAppService: IApplicationService
    {
        [HttpGet]
        Task<List<GeneInfoDto>> GetGeneInfos();
        [HttpPost]
        Task<GeneInfoDto> CreateGeneInfo(CreateGeneInfoDto input);

        [HttpPost]
        Task<GeneInfoDto> UpdateGeneInfo(GeneInfoDto input);

        
        Task DeleteGeneInfo(Int64 id);
        
    }
}

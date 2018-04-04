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
        List<GeneInfoDto> GetGeneInfos();
        [HttpPost]
        GeneInfoDto CreateGeneInfo(CreateGeneInfoDto input);

        [HttpPost]
        GeneInfoDto UpdateGeneInfo(GeneInfoDto input);

        [HttpPost]
        void DeleteGeneInfo(GeneInfoDto input);
        
    }
}

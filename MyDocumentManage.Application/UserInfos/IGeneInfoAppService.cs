using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyDocumentManage.Application.UserInfos.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManage.Application.UserInfos
{
    public interface IGeneInfoAppService: IApplicationService
    {
        List<GeneInfoDto> GetGeneInfos();
        object GetGeneInfosOS();
    }
}

using AutoMapper;
using MyDocumentManageNetCore.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManageNetCore.Application.UserInfos.Dto
{
    public class GeneInfoMapProfile:Profile
    {
        public GeneInfoMapProfile() {
            CreateMap<GeneInfoDto, TB_GeneInfo>();
            CreateMap<CreateGeneInfoDto,TB_GeneInfo>();
            CreateMap<TB_GeneInfo, CreateGeneInfoDto>();
        }
        
    }
}

using AutoMapper;
using MyDocumentManageNetCore.Application.GeneInfos.Dto;
using MyDocumentManageNetCore.Application.ReagentInfos.Dto;
using MyDocumentManageNetCore.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManageNetCore.Application.UserInfos.Dto
{
    public class GeneInfoMapProfile : Profile
    {
        public GeneInfoMapProfile()
        {
            CreateMap<GeneInfoDto, TB_GeneInfo>();
            CreateMap<CreateGeneInfoDto, TB_GeneInfo>();
            CreateMap<TB_GeneInfo, CreateGeneInfoDto>();
            //CreateMap<TB_GeneInfo, ReagentInfoDto>().ForMember(r => r.Id, opt => opt.MapFrom(t => t.ReagentID));
            //CreateMap<TB_GeneInfo, ReagentGeneInfoDto>()
            //    .ForMember(
            //    r => r.ReagentInfo.Id, opt => opt.MapFrom
            //       (a=>a.ReagentID)).AfterMap((t,r)=>r.ReagentInfo=new ReagentInfoDto { Id=t.ReagentID});
        }

    }
}

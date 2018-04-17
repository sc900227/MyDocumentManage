using AutoMapper;
using MyDocumentManageNetCore.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManageNetCore.Application.ReagentInfos.Dto
{
    public class ReagentInfoProfile:Profile
    {
        public ReagentInfoProfile() {
            CreateMap<CreateReagentInfoDto, TB_ReagentInfo>();
            CreateMap<ReagentInfoDto,TB_ReagentInfo>();
            CreateMap<TB_ReagentInfo, ReagentInfoDto>();
            CreateMap<TB_ReagentInfo, ReagentGeneInfoDto>().ForMember(dto => dto.GeneInfos, opt => opt.Ignore());
        }
    }
}

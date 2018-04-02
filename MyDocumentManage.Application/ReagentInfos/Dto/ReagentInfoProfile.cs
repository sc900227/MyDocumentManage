using AutoMapper;
using MyDocumentManage.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManage.Application.ReagentInfos.Dto
{
    public class ReagentInfoProfile:Profile
    {
        public ReagentInfoProfile() {
            CreateMap<CreateReagentInfoDto, TB_ReagentInfo>();
            CreateMap<ReagentInfoDto,TB_ReagentInfo>();
            CreateMap<TB_ReagentInfo, ReagentInfoDto>();
        }
    }
}

using AutoMapper;
using MyDocumentManageNetCore.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManageNetCore.Application.GeneTypeResults.Dto
{
    public class GeneTypeResultProfile:Profile
    {
        public GeneTypeResultProfile() {
            CreateMap<CreateGeneTypeResultDto, TB_GeneTypeResult>();
            CreateMap<TB_GeneTypeResult, GeneTypeResultDto>();
            CreateMap<GeneTypeResultDto, TB_GeneTypeResult>();
            CreateMap<TB_GeneTypeResult, GeneTypeTestResultDto>().ForMember(dto => dto.GeneTestResults, opt => opt.Ignore());
        }
    }
}

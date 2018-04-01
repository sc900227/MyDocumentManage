using AutoMapper;
using MyDocumentManage.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManage.Application.GeneTypeResults.Dto
{
    public class GeneTypeResultProfile:Profile
    {
        public GeneTypeResultProfile() {
            CreateMap<CreateGeneTypeResultDto, TB_GeneTypeResult>();
            CreateMap<TB_GeneTypeResult, GeneTypeResultDto>();
        }
    }
}

using AutoMapper;
using MyDocumentManage.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManage.Application.UserInfos.Dto
{
    public class GeneInfoMapProfile:Profile
    {
        public GeneInfoMapProfile() {
            CreateMap<GeneInfoDto, TB_GeneInfo>();
        }
        
    }
}

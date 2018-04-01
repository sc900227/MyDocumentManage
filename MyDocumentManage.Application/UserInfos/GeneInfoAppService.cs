using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Dapper.Repositories;
using MyDocumentManage.Application.UserInfos.Dto;
using MyDocumentManage.Domain.Entitys;
using MyDocumentManage.Domain.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManage.Application.UserInfos
{
    public class GeneInfoAppService : ApplicationService, IGeneInfoAppService
    {
        public IGeneInfoRep GeneInfoRepository { get; set; }
        public IGeneInfoQueryService GeneInfoQueryService { get; set; }
        public IGeneInfoDapperRep GeneInfoDapperRepository { get; set; }
        

        //private readonly IDapperRepository<TB_GeneInfo,Int64> _personDapperRepository;
        //public object GetGeneInfos()
        //{
        //    var geneInfos= GeneInfoRepository.GetAll();
        //    return geneInfos;
        //}

        public object GetGeneInfosOS() {
            return GeneInfoDapperRepository.GetAll().ToList();
            //return GeneInfoQueryService.SearchGeneInfos("");
        }

        public List<GeneInfoDto> GetGeneInfos()
        {
            var geneInfos = GeneInfoDapperRepository.GetAll().ToList();
            return new List<GeneInfoDto>(ObjectMapper.Map<List<GeneInfoDto>>(geneInfos));
        }
    }
}

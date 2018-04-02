using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Dapper.Repositories;
using MyDocumentManage.Application.UserInfos.Dto;
using MyDocumentManage.Domain.Entitys;
using MyDocumentManage.Domain.Repositorys;
using MyDocumentManage.Domain.Repositorys.GeneInfo;
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
        public GeneInfoDto Create(CreateGeneInfoDto input) {
            var geneInfo = ObjectMapper.Map<TB_GeneInfo>(input);
            Int64 id=  GeneInfoDapperRepository.InsertAndGetId(geneInfo);
            return ObjectMapper.Map<GeneInfoDto>(GeneInfoDapperRepository.Get(id));
        }

        public GeneInfoDto Update(GeneInfoDto input) {
            var geneInfo = ObjectMapper.Map<TB_GeneInfo>(input);
            GeneInfoDapperRepository.Update(geneInfo);
            return ObjectMapper.Map<GeneInfoDto>(GeneInfoDapperRepository.Get(input.Id));
        }

        public void Delete(Int64 id) {
            var geneInfo=GeneInfoDapperRepository.Get(id);
            GeneInfoDapperRepository.Delete(geneInfo);
        }
    }
}

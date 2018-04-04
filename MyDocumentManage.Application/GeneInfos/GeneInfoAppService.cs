using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Dapper.Repositories;
using Abp.Domain.Repositories;
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
        
        private readonly IRepository<TB_GeneInfo, Int64> repository;
        public GeneInfoAppService(IRepository<TB_GeneInfo, Int64> _repository) {
            repository = _repository;
        }
       
        public List<GeneInfoDto> GetGeneInfos()
        {
            var geneInfos = repository.GetAll().ToList();
            return new List<GeneInfoDto>(ObjectMapper.Map<List<GeneInfoDto>>(geneInfos));
        }
        public GeneInfoDto CreateGeneInfo(CreateGeneInfoDto input) {
            var geneInfo = ObjectMapper.Map<TB_GeneInfo>(input);
            geneInfo.ID = geneInfo.Id = GetMaxID() + 1;
            Int64 id= repository.InsertAndGetId(geneInfo);
            return ObjectMapper.Map<GeneInfoDto>(geneInfo);
        }

        public GeneInfoDto UpdateGeneInfo(GeneInfoDto input) {
            var geneInfo = ObjectMapper.Map<TB_GeneInfo>(input);
            repository.Update(geneInfo);
            return ObjectMapper.Map<GeneInfoDto>(geneInfo);
        }

        public void DeleteGeneInfo(GeneInfoDto input) {
            repository.Delete(a=>a.ID==input.Id);
        }
        public Int64 GetMaxID() {
            var maxId = repository.GetAll().OrderByDescending(a => a.ID).Select(a => a.ID).FirstOrDefault();
            return maxId;
        }
    }
}

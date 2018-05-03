using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Dapper.Repositories;
using Abp.Domain.Repositories;
using MyDocumentManage.Application.UserInfos.Dto;
using MyDocumentManage.Domain.Entitys;
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
       
        public async Task<List<GeneInfoDto>> GetGeneInfos()
        {
            var geneInfos = await repository.GetAllListAsync();
            geneInfos = geneInfos.OrderBy(a => a.ID).ToList();
            return new List<GeneInfoDto>(ObjectMapper.Map<List<GeneInfoDto>>(geneInfos));
        }
        public async Task<GeneInfoDto> CreateGeneInfo(CreateGeneInfoDto input) {
            var geneInfo = ObjectMapper.Map<TB_GeneInfo>(input);
            geneInfo.ID = geneInfo.Id = GetMaxID() + 1;
            Int64 id= await repository.InsertAndGetIdAsync(geneInfo);
            return ObjectMapper.Map<GeneInfoDto>(geneInfo);
        }

        public async Task<GeneInfoDto> UpdateGeneInfo(GeneInfoDto input) {
            var geneInfo = ObjectMapper.Map<TB_GeneInfo>(input);
            await repository.UpdateAsync(geneInfo);
            return ObjectMapper.Map<GeneInfoDto>(geneInfo);
        }

        public async Task DeleteGeneInfo(Int64 id) {
           await repository.DeleteAsync(a=>a.ID==id);
        }
        public Int64 GetMaxID() {
            var maxId = repository.GetAll().OrderByDescending(a => a.ID).Select(a => a.ID).FirstOrDefault();
            return maxId;
        }
    }
}

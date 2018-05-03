using Abp.Application.Services;
using Abp.Domain.Repositories;
using MyDocumentManage.Application.GeneTypeResults.Dto;
using MyDocumentManage.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManage.Application.GeneTypeResults
{
    public class GeneTypeResultAppService : ApplicationService, IGeneTypeResultAppService
    {
        private readonly IRepository<TB_GeneTypeResult, Int64> repository;
        public GeneTypeResultAppService(IRepository<TB_GeneTypeResult,Int64> _repository) {
            repository = _repository;
        }

        public async Task<GeneTypeResultDto> CreateGeneTypeResult(CreateGeneTypeResultDto input)
        {
            var info = ObjectMapper.Map<TB_GeneTypeResult>(input);
            info.ID = info.Id = input.Id;
            var infoId=await repository.InsertAndGetIdAsync(info);
            return ObjectMapper.Map<GeneTypeResultDto>(info);
            
        }

        public async Task DeleteGeneTypeResult(Int64 id)
        {
             await repository.DeleteAsync(a => a.ID == id);
        }

        public async Task<List<GeneTypeResultDto>> GetGeneTypeResults()
        {
            var info = await repository.GetAllListAsync();
            info=info.OrderBy(a => a.ID).ToList();
            return ObjectMapper.Map<List<GeneTypeResultDto>>(info);
        }

        public Int64 GetMaxID() {
           var maxId= repository.GetAll().OrderByDescending(a => a.ID).Select(a => a.ID).FirstOrDefault();
            return maxId;
        }

        public async Task<GeneTypeResultDto> UpdateGeneTypeResult(GeneTypeResultDto input)
        {
            var info = ObjectMapper.Map<TB_GeneTypeResult>(input);
            await repository.UpdateAsync(info);
            return ObjectMapper.Map<GeneTypeResultDto>(input);
        }
    }
}

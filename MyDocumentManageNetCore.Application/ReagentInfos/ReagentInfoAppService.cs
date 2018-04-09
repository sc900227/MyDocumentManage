using Abp.Application.Services;
using Abp.Dependency;
using Abp.Domain.Repositories;
using MyDocumentManage.Domain.Entitys;
using MyDocumentManageNetCore.Application.ReagentInfos.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManageNetCore.Application.ReagentInfos
{
    public class ReagentInfoAppService:ApplicationService,IReagentInfoAppService
    {
        //private readonly IReagentInfoRep dapperRepository;
        private readonly IRepository<TB_ReagentInfo,Int64> repository;
        //private readonly IReagentInfoRep dapperRepository;

        public ReagentInfoAppService(IRepository<TB_ReagentInfo, Int64> _repository)
        {
            repository = _repository;
        }
        public async Task<List<ReagentInfoDto>> GetReagentInfos() {
            var reagentInfos = await repository.GetAllListAsync();
            reagentInfos=reagentInfos.OrderBy(a => a.Id).ToList();
            return ObjectMapper.Map<List<ReagentInfoDto>>(reagentInfos);
        }

        public async Task<ReagentInfoDto> CreateReagentInfo(CreateReagentInfoDto input) {
            var reagentInfo = ObjectMapper.Map<TB_ReagentInfo>(input);
            reagentInfo.ID =reagentInfo.Id= GetMaxID() + 1;
            var id= await repository.InsertAndGetIdAsync(reagentInfo);
            return ObjectMapper.Map<ReagentInfoDto>(reagentInfo);
        }
        
        public async Task<ReagentInfoDto> UpdateReagentInfo(ReagentInfoDto input)
        {
            var reagentInfo = ObjectMapper.Map<TB_ReagentInfo>(input);
            await repository.UpdateAsync(reagentInfo);
            return ObjectMapper.Map<ReagentInfoDto>(reagentInfo);
        }

        public async Task DeleteReagentInfo(Int64 id) {
            //var reagentInfo= repository.Get(id);
            await repository.DeleteAsync(a => a.ID == id);
        }

        public long GetMaxID()
        {
            Int64 maxId = repository.GetAll().OrderByDescending(a => a.Id).Select(a =>a.Id).FirstOrDefault();
            return maxId;
        }
    }
}

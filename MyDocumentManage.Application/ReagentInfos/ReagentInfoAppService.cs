using Abp.Application.Services;
using Abp.Dapper.Repositories;
using Abp.Dependency;
using Abp.Domain.Repositories;
using MyDocumentManage.Application.ReagentInfos.Dto;
using MyDocumentManage.Domain.Entitys;
using MyDocumentManage.Domain.Repositorys;
using MyDocumentManage.Domain.Repositorys.ReagentInfo;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManage.Application.ReagentInfos
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
        public List<ReagentInfoDto> GetReagentInfos() {
            var reagentInfos= repository.GetAll().OrderBy(a => a.Id).ToList();
            return ObjectMapper.Map<List<ReagentInfoDto>>(reagentInfos);
        }

        public Int64 CreateReagentInfo(CreateReagentInfoDto input) {
            var reagentInfo = ObjectMapper.Map<TB_ReagentInfo>(input);
            reagentInfo.ID =reagentInfo.Id= GetMaxID() + 1;
            
            var id= repository.InsertAndGetId(reagentInfo);
            return id;
        }

        public ReagentInfoDto Update(ReagentInfoDto input)
        {
            var reagentInfo = ObjectMapper.Map<TB_ReagentInfo>(input);
            repository.Update(reagentInfo);
            return ObjectMapper.Map<ReagentInfoDto>(repository.Get(input.Id));
        }

        public void Delete(Int64 id) {
            //var reagentInfo= repository.Get(id);
            repository.Delete(a => a.ID == id);
        }

        public long GetMaxID()
        {
            var info = repository.GetAll().OrderByDescending(a => a.Id).Select(a => new ReagentInfoDto { Id = a.Id }).FirstOrDefault();
            Int64 maxId = info.Id;
            return maxId;
        }
    }
}

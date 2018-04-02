using Abp.Application.Services;
using Abp.Dapper.Repositories;
using MyDocumentManage.Application.ReagentInfos.Dto;
using MyDocumentManage.Domain.Entitys;
using MyDocumentManage.Domain.Repositorys;
using MyDocumentManage.Domain.Repositorys.ReagentInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManage.Application.ReagentInfos
{
    public class ReagentInfoAppService:ApplicationService,IReagentInfoAppService
    {
        private readonly IReagentInfoRep dapperRepository;
       
        public ReagentInfoAppService(IReagentInfoRep _dapperRepository)
        {
            dapperRepository = _dapperRepository;
        }
        public List<ReagentInfoDto> GetReagentInfos() {
            var reagentInfos= dapperRepository.GetAll().OrderBy(a => a.Id).ToList();
            return ObjectMapper.Map<List<ReagentInfoDto>>(reagentInfos);
        }

        public ReagentInfoDto CreateReagentInfo(CreateReagentInfoDto input) {
            var reagentInfo = ObjectMapper.Map<TB_ReagentInfo>(input);
            var id=dapperRepository.InsertAndGetId(reagentInfo);
            return ObjectMapper.Map<ReagentInfoDto>(dapperRepository.Get(id));
        }

        public ReagentInfoDto Update(ReagentInfoDto input)
        {
            var reagentInfo = ObjectMapper.Map<TB_ReagentInfo>(input);
            dapperRepository.Update(reagentInfo);
            return ObjectMapper.Map<ReagentInfoDto>(dapperRepository.Get(input.Id));
        }

        public void Delete(Int64 id) {
            var reagentInfo=dapperRepository.Get(id);
            dapperRepository.Delete(reagentInfo);
        }
    }
}

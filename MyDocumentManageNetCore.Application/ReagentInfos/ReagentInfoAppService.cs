using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.AspNetCore.Mvc;
using MyDocumentManageNetCore.Application.ReagentInfos.Dto;
using MyDocumentManageNetCore.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyDocumentManage.Infrastructure;
using System.Linq.Expressions;
using System.Net.Http;
using Microsoft.AspNetCore.Cors;
using Abp.Collections.Extensions;
using MyDocumentManageNetCore.Application.UserInfos.Dto;
using MyDocumentManageNetCore.Application.UserInfos;
using MyDocumentManageNetCore.Application.GeneTypeResults;
using MyDocumentManageNetCore.Application.GeneTypeResults.Dto;
using MyDocumentManageNetCore.Application.GeneTestResults.Dto;

namespace MyDocumentManageNetCore.Application.ReagentInfos
{
    public class ReagentInfoAppService : ApplicationService, IReagentInfoAppService
    {
        //private readonly IReagentInfoRep dapperRepository;
        private readonly IRepository<TB_ReagentInfo, Int64> repository;
        //private readonly IReagentInfoRep dapperRepository;
        private readonly IRepository<TB_GeneInfo, Int64> geneInfoRepository;
        private readonly IGeneInfoAppService geneInfoAppService;
        private readonly IGeneTypeResultAppService geneTypeResultAppService;

        public ReagentInfoAppService(IRepository<TB_ReagentInfo, Int64> _repository,IRepository<TB_GeneInfo,Int64> _geneInfoRepository, IGeneInfoAppService _geneInfoAppService, IGeneTypeResultAppService _geneTypeResultAppService)
        {
            repository = _repository;
            geneInfoRepository = _geneInfoRepository;
            geneInfoAppService = _geneInfoAppService;
            geneTypeResultAppService = _geneTypeResultAppService;
        }
        
        [HttpGet]
        [EnableCors("AllowSameDomain")]
        public async Task<GeneTypeTestResultDto> GetReagentGeneTypeTests(Int64 reagentId = -1)
        {
            var geneTypeTests=await geneTypeResultAppService.GetGeneTypeTestResults(reagentId);
            if (geneTypeTests==null|| geneTypeTests.Count<=0)
            {
                geneTypeTests = new List<GeneTypeTestResultDto>();
                geneTypeTests.Add(new GeneTypeTestResultDto()
                {
                    ReagentID = reagentId,
                    GeneTestResults = ObjectMapper.Map<List<GeneTestResultDto>>(geneInfoRepository.GetAllListAsync(g => g.ReagentID == reagentId).Result)
                });
            }
            
            
            return geneTypeTests.FirstOrDefault();
        }
        [HttpGet]
        [EnableCors("AllowSameDomain")]
        public async Task<List<ReagentGeneTypeTestResultDto>> GetReagentGeneTypeTestResults(Int64 reagentId=-1) {
            var reagentInfo =reagentId==-1? await repository.GetAllListAsync():await repository.GetAllListAsync(a=>a.Id==reagentId);
            var reagentInfoDto= ObjectMapper.Map<List<ReagentInfoDto>>(reagentInfo);
            var reagentGeneTypeTestResults = ObjectMapper.Map<List<ReagentGeneTypeTestResultDto>>(reagentInfoDto);
            reagentGeneTypeTestResults.ForEach(a =>
            {
                a.GeneTypeTestResults =geneTypeResultAppService.GetGeneTypeTestResults(a.Id).Result;
            });
            return reagentGeneTypeTestResults;
        }
        [HttpPost]
        [EnableCors("AllowSameDomain")]
        public PagedResultDto<ReagentInfoDto> GetReagentInfosPage(GetReagentInfosInput input)
        {
            //帅选
            var where = LambdaHelper.True<TB_ReagentInfo>();
            if (input.Filters != null && input.Filters.Count > 0)
            {
                foreach (var item in input.Filters)
                {
                    if (item.ColumName == "ReagentName")
                        item.ColumValue = item.ColumValue.ToUpper();
                    where = where.And(LambdaHelper.GetContains<TB_ReagentInfo>(item.ColumName, item.ColumValue));
                }
            }
            var query = repository.GetAll().Where(where);
            //排序
            if (!string.IsNullOrEmpty(input.Sorting))
            {
                if (input.Sorting.Contains("-"))
                {
                    var sort = input.Sorting.Split("-");
                    query = sort[1] == "desc" ? query.OrderByDescending(sort[0]) : query.OrderBy(sort[0]);
                }
                else
                {
                    query = query.OrderBy(input.Sorting);
                }
            }
            else
            {
                query = query.OrderBy(t => t.ID);
            }
            //query = !string.IsNullOrEmpty(input.Sorting) ? query.OrderBy(input.Sorting) : query.OrderBy(t => t.ID);
            //获取总数
            var totalCount = query.Include(a => a.ID).Count();
            //默认的分页方式
            //var reagentList = query.Skip(input.SkipCount).Take(input.MaxResultCount).ToList();

            //ABP提供了扩展方法PageBy分页方式
            var reagentList = query.PageBy(input).ToList();
            var result = new PagedResultDto<ReagentInfoDto>(totalCount, ObjectMapper.Map<List<ReagentInfoDto>>(reagentList));
            return result;

        }
        [HttpGet]
        [EnableCors("AllowSameDomain")]
        public async Task<List<ReagentGeneInfoDto>> GetReagentGeneInfos()
        {
            var reagentInfos = await repository.GetAllListAsync();
            var reagents = ObjectMapper.Map<List<ReagentGeneInfoDto>>(reagentInfos).OrderBy(a=>a.Id).ToList();
            
            reagents.ForEach(a => a.GeneInfos = geneInfoAppService.GetGeneInfos(a.Id).Result);
            
            return reagents;
        }
        [HttpGet]
        [EnableCors("AllowSameDomain")]
        public async Task<List<ReagentInfoDto>> GetReagentInfos()
        {
            var reagentInfos = await repository.GetAllListAsync();
            reagentInfos = reagentInfos.OrderBy(a => a.Id).ToList();
            return ObjectMapper.Map<List<ReagentInfoDto>>(reagentInfos);
        }
        [HttpPost]
        [EnableCors("AllowSameDomain")]
        public async Task<ReagentInfoDto> CreateReagentInfo(CreateReagentInfoDto input)
        {
            var reagentInfo = ObjectMapper.Map<TB_ReagentInfo>(input);
            reagentInfo.ID = reagentInfo.Id = GetMaxID() + 1;
            input.ReagentName = input.ReagentName.ToUpper();
            var id = await repository.InsertAndGetIdAsync(reagentInfo);
            return ObjectMapper.Map<ReagentInfoDto>(reagentInfo);
        }
        [HttpPost]
        [EnableCors("AllowSameDomain")]
        public async Task<ReagentInfoDto> UpdateReagentInfo(ReagentInfoDto input)
        {
            var reagentInfo = ObjectMapper.Map<TB_ReagentInfo>(input);
            await repository.UpdateAsync(reagentInfo);
            return ObjectMapper.Map<ReagentInfoDto>(reagentInfo);
        }
        [HttpDelete]
        [EnableCors("AllowSameDomain")]
        public async Task DeleteReagentInfo(Int64 id)
        {
            //var reagentInfo= repository.Get(id);
            await repository.DeleteAsync(a => a.ID == id);
            await geneInfoRepository.DeleteAsync(a => a.ReagentID == id);
            await geneTypeResultAppService.DeleteGeneTypeResultByReagentId(id);
        }

        public long GetMaxID()
        {
            Int64 maxId = repository.GetAll().OrderByDescending(a => a.Id).Select(a => a.Id).FirstOrDefault();
            return maxId;
        }

       
    }
}

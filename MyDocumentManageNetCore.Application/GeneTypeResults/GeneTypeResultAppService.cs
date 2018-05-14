using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyDocumentManage.Infrastructure;
using MyDocumentManageNetCore.Application.GeneTestResults;
using MyDocumentManageNetCore.Application.GeneTestResults.Dto;
using MyDocumentManageNetCore.Application.GeneTypeResults.Dto;
using MyDocumentManageNetCore.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManageNetCore.Application.GeneTypeResults
{
    public class GeneTypeResultAppService : ApplicationService, IGeneTypeResultAppService
    {
        private readonly IRepository<TB_GeneTypeResult, Int64> repository;
        private readonly IRepository<TB_GeneTestResult, Int64> geneTestRepository;
        private readonly IGeneTestResultAppService geneTestResultAppService;
        private readonly IRepository<TB_ReagentInfo, Int64> reagentRepository;
        public GeneTypeResultAppService(IRepository<TB_GeneTypeResult, Int64> _repository, IRepository<TB_GeneTestResult, Int64> _geneTestRepository, IGeneTestResultAppService _geneTestResultAppService, IRepository<TB_ReagentInfo, Int64> _reagentRepository)
        {
            repository = _repository;
            geneTestRepository = _geneTestRepository;
            geneTestResultAppService = _geneTestResultAppService;
            reagentRepository = _reagentRepository;
        }
        [HttpPost]
        [EnableCors("AllowSameDomain")]
        public async Task<GeneTypeTestResultDto> CreateGeneTypeTestResult(GeneTypeTestResultDto input) {
            var geneTypeResult = ObjectMapper.Map<TB_GeneTypeResult>(input);
            var geneTestResults = ObjectMapper.Map<List<TB_GeneTestResult>>(input.GeneTestResults);
            geneTypeResult.ID = geneTypeResult.Id = GetMaxID() + 1;
            Int64 geneTypeResulyId=await repository.InsertAndGetIdAsync(geneTypeResult);

            var createGeneTests=ObjectMapper.Map<List<CreateGeneTestResultDto>>(geneTestResults);
            createGeneTests.ForEach(a => a.GeneTypeResultID = geneTypeResulyId);
            

            GeneTypeTestResultDto result = ObjectMapper.Map<GeneTypeTestResultDto>(geneTypeResult);
            result.GeneTestResults= await geneTestResultAppService.CreateGeneTestResults(createGeneTests);
            //var results=await GetGeneTypeTestResults(input.ReagentID);
            return result;
        }
        [HttpGet]
        [EnableCors("AllowSameDomain")]
        public async Task<List<GeneTypeTestResultDto>> GetGeneTypeTestResults(Int64 reagentId=-1)
        {
            var geneTypeResults =reagentId==-1? await repository.GetAllListAsync(): await repository.GetAllListAsync(a => a.ReagentID == reagentId);
            geneTypeResults = geneTypeResults.OrderBy(a => a.Id).ToList();
            var geneTypeTestResults = ObjectMapper.Map<List<GeneTypeTestResultDto>>(geneTypeResults);

            geneTypeTestResults.ForEach(a =>
            {
                a.GeneTestResults = geneTestResultAppService.GetGeneTestResults(a.Id).Result;
                a.ReagmentName = reagentRepository.FirstOrDefault(r => r.ID == a.ReagentID).ReagentName;

            });
            return geneTypeTestResults;
        }
        [HttpPost]
        [EnableCors("AllowSameDomain")]
        public PagedResultDto<GeneTypeResultDto> GetReagentInfosPage(GetGeneTypeResultsInput input)
        {
            //帅选
            var where = LambdaHelper.True<TB_GeneTypeResult>();
            if (input.Filters != null && input.Filters.Count > 0)
            {
                foreach (var item in input.Filters)
                {
                    where = where.And(LambdaHelper.GetContains<TB_GeneTypeResult>(item.ColumName, item.ColumValue));
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
            var result = new PagedResultDto<GeneTypeResultDto>(totalCount, ObjectMapper.Map<List<GeneTypeResultDto>>(reagentList));
            return result;
        }
        [HttpPost]
        [EnableCors("AllowSameDomain")]
        public async Task<GeneTypeResultDto> CreateGeneTypeResult(CreateGeneTypeResultDto input)
        {
            var info = ObjectMapper.Map<TB_GeneTypeResult>(input);
            info.ID = info.Id = GetMaxID() + 1;
            var infoId = await repository.InsertAndGetIdAsync(info);
            return ObjectMapper.Map<GeneTypeResultDto>(info);

        }
        [HttpDelete]
        [EnableCors("AllowSameDomain")]
        public async Task DeleteGeneTypeResultByReagentId(Int64 reagentId) {
            var geneTypeResults=await  repository.GetAllListAsync(a => a.ReagentID == reagentId);
            if (geneTypeResults!=null&&geneTypeResults.Count>0)
            {
                foreach (var item in geneTypeResults)
                {
                   await DeleteGeneTypeResult(item.Id);
                }
            }
        }
        [HttpDelete]
        [EnableCors("AllowSameDomain")]
        public async Task DeleteGeneTypeResult(Int64 id)
        {
            await repository.DeleteAsync(a => a.ID ==id);
            await geneTestRepository.DeleteAsync(a => a.GeneTypeResultID == id);
        }
        [HttpGet]
        [EnableCors("AllowSameDomain")]
        public async Task<List<GeneTypeResultDto>> GetGeneTypeResults()
        {
            var info = await repository.GetAllListAsync();
            info = info.OrderBy(a => a.ID).ToList();
            return ObjectMapper.Map<List<GeneTypeResultDto>>(info);
        }

        public Int64 GetMaxID()
        {
            var maxId = repository.GetAll().OrderByDescending(a => a.ID).Select(a => a.ID).FirstOrDefault();
            return maxId;
        }
        [HttpPost]
        [EnableCors("AllowSameDomain")]
        public async Task<GeneTypeResultDto> UpdateGeneTypeResult(GeneTypeResultDto input)
        {
            var info = ObjectMapper.Map<TB_GeneTypeResult>(input);
            await repository.UpdateAsync(info);
            return ObjectMapper.Map<GeneTypeResultDto>(input);
        }
    }
}

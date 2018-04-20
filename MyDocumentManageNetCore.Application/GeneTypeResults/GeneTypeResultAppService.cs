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
        public GeneTypeResultAppService(IRepository<TB_GeneTypeResult,Int64> _repository, IRepository<TB_GeneTestResult, Int64> _geneTestRepository, IGeneTestResultAppService _geneTestResultAppService, IRepository<TB_ReagentInfo, Int64> _reagentRepository) {
            repository = _repository;
            geneTestRepository = _geneTestRepository;
            geneTestResultAppService = _geneTestResultAppService;
            reagentRepository = _reagentRepository;
        }
        [HttpGet]
        [EnableCors("AllowSameDomain")]
        public async Task<List<GeneTypeTestResultDto>> GetGeneTypeTestResults() {
            var geneTypeResults = await repository.GetAllListAsync();
            geneTypeResults = geneTypeResults.OrderBy(a => a.Id).ToList();
            var geneTypeTestResults = ObjectMapper.Map<List<GeneTypeTestResultDto>>(geneTypeResults);

            //var geneTestResults = await geneTestResultAppService.GetGeneTestResults(); //geneTestRepository.GetAll().OrderBy(a => a.ID).ToList();
            //var geneTests = ObjectMapper.Map<List<GeneTestResultDto>>(geneTestResults);
            geneTypeTestResults.ForEach(a => {
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
        public async Task<GeneTypeResultDto> CreateGeneTypeResult(CreateGeneTypeResultDto input)
        {
            var info = ObjectMapper.Map<TB_GeneTypeResult>(input);
            info.ID = info.Id = input.Id;
            var infoId=await repository.InsertAndGetIdAsync(info);
            return ObjectMapper.Map<GeneTypeResultDto>(info);
            
        }
        [HttpPost]
        public async Task DeleteGeneTypeResult(GeneTypeResultDto input)
        {
             await repository.DeleteAsync(a => a.ID == input.Id);
        }
        [HttpGet]
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
        [HttpPost]
        public async Task<GeneTypeResultDto> UpdateGeneTypeResult(GeneTypeResultDto input)
        {
            var info = ObjectMapper.Map<TB_GeneTypeResult>(input);
            await repository.UpdateAsync(info);
            return ObjectMapper.Map<GeneTypeResultDto>(input);
        }
    }
}

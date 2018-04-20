using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyDocumentManage.Infrastructure;
using MyDocumentManageNetCore.Application.GeneTestResults.Dto;
using MyDocumentManageNetCore.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManageNetCore.Application.GeneTestResults
{
    public class GeneTestResultAppService : ApplicationService, IGeneTestResultAppService
    {
        private readonly IRepository<TB_GeneTestResult, Int64> repository;
        private readonly IRepository<TB_GeneInfo, Int64> geneRepository;
        public GeneTestResultAppService(IRepository<TB_GeneTestResult, Int64> _repository, IRepository<TB_GeneInfo, Int64> _geneRepository) {
            repository = _repository;
            geneRepository = _geneRepository;
        }
        [HttpPost]
        [EnableCors("AllowSameDomain")]
        public async Task<GeneTestResultDto> CreateReagentInfo(CreateGeneTestResultDto input)
        {
            var geneTestResult = ObjectMapper.Map<TB_GeneTestResult>(input);
            geneTestResult.ID = geneTestResult.Id = GetMaxID() + 1;
            Int64 id = await repository.InsertAndGetIdAsync(geneTestResult);
            return ObjectMapper.Map<GeneTestResultDto>(geneTestResult);
        }

        public async Task DeleteGeneTestResult(Int64 id)
        {
            await repository.DeleteAsync(a => a.ID == id);
        }
        [HttpGet]
        [EnableCors("AllowSameDomain")]
        public async Task<List<GeneTestResultDto>> GetGeneTestResults(Int64 geneTypeResultId=-1)
        {
            var geneTestResults= geneTypeResultId==-1? await repository.GetAllListAsync():await repository.GetAllListAsync(a=>a.GeneTypeResultID==geneTypeResultId);
            geneTestResults = geneTestResults.OrderBy(a => a.ID).ToList();
            var geneTests = ObjectMapper.Map<List<GeneTestResultDto>>(geneTestResults);
            geneTests.ForEach(a => a.GeneName = geneRepository.FirstOrDefault(g=>g.ID==a.GeneID).GeneName);
            return new List<GeneTestResultDto>(geneTests);
        }
        [HttpPost]
        [EnableCors("AllowSameDomain")]
        public async Task<GeneTestResultDto> UpdateReagentInfo(GeneTestResultDto input)
        {
            var geneTestResult = ObjectMapper.Map<TB_GeneTestResult>(input);
            await repository.UpdateAsync(geneTestResult);
            return ObjectMapper.Map<GeneTestResultDto>(geneTestResult);
        }
        [HttpPost]
        [EnableCors("AllowSameDomain")]
        public PagedResultDto<GeneTestResultDto> GetReagentInfosPage(GetGeneTestResultsInput input)
        {
            //帅选
            var where = LambdaHelper.True<TB_GeneTestResult>();
            if (input.Filters != null && input.Filters.Count > 0)
            {
                foreach (var item in input.Filters)
                {
                    where = where.And(LambdaHelper.GetContains<TB_GeneTestResult>(item.ColumName, item.ColumValue));
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
            var result = new PagedResultDto<GeneTestResultDto>(totalCount, ObjectMapper.Map<List<GeneTestResultDto>>(reagentList));
            return result;
        }
        

        public Int64 GetMaxID()
        {
            var maxId = repository.GetAll().OrderByDescending(a => a.ID).Select(a => a.ID).FirstOrDefault();
            return maxId;
        }
    }
}

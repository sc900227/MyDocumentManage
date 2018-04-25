using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyDocumentManage.Infrastructure;
using MyDocumentManageNetCore.Application.Dtos;
using MyDocumentManageNetCore.Application.GeneInfos.Dto;
using MyDocumentManageNetCore.Application.ReagentInfos.Dto;
using MyDocumentManageNetCore.Application.UserInfos.Dto;
using MyDocumentManageNetCore.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManageNetCore.Application.UserInfos
{
    public class GeneInfoAppService : ApplicationService, IGeneInfoAppService
    {
        
        private readonly IRepository<TB_GeneInfo, Int64> repository;
        private readonly IRepository<TB_ReagentInfo, Int64> repositoryReagent;
        private readonly IRepository<TB_GeneTestResult, Int64> repositoryGeneInfo;
        public GeneInfoAppService(IRepository<TB_GeneInfo, Int64> _repository, IRepository<TB_ReagentInfo, Int64> _repositoryReagent, IRepository<TB_GeneTestResult, Int64> _repositoryGeneInfo) {
            repository = _repository;
            repositoryReagent = _repositoryReagent;
            repositoryGeneInfo = _repositoryGeneInfo;
        }
        [HttpPost]
        [EnableCors("AllowSameDomain")]
        public PagedResultDto<GeneInfoDto> GetReagentInfosPage(GetGeneInfosInput input)
        {
            //帅选
            var where = LambdaHelper.True<TB_GeneInfo>();
            if (input.Filters != null && input.Filters.Count > 0)
            {
                foreach (var item in input.Filters)
                {
                    if (item.ColumName == "GeneName")
                        item.ColumValue = item.ColumValue.ToUpper();
                    where = where.And(LambdaHelper.GetContains<TB_GeneInfo>(item.ColumName, item.ColumValue));
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
            var result = new PagedResultDto<GeneInfoDto>(totalCount, ObjectMapper.Map<List<GeneInfoDto>>(reagentList));
            return result;

        }
        [HttpPost]
        [EnableCors("AllowSameDomain")]
        public async Task<List<GeneInfoDto>> GetGeneInfosFilter(List<FilterInputDto> input) {
            //帅选
            var where = LambdaHelper.True<TB_GeneInfo>();
            if (input != null && input.Count > 0)
            {
                foreach (var item in input)
                {
                    if (item.ColumName == "GeneName")
                        item.ColumValue = item.ColumValue.ToUpper();
                    where = where.And(LambdaHelper.CreateEqual<TB_GeneInfo>(item.ColumName, item.ColumValue));
                }
            }
            var geneInfos = await repository.GetAllListAsync(where);
            return ObjectMapper.Map<List<GeneInfoDto>>(geneInfos);
        } 
        [HttpGet]
        [EnableCors("AllowSameDomain")]
        public async Task<List<GeneInfoDto>> GetGeneInfos(Int64 reagentId=-1)
        {
            var geneInfos = reagentId == -1? await repository.GetAllListAsync(): await repository.GetAllListAsync(a=>a.ReagentID== reagentId);
            geneInfos = geneInfos.OrderBy(a => a.ID).ToList();
            return new List<GeneInfoDto>(ObjectMapper.Map<List<GeneInfoDto>>(geneInfos));
        }
        [HttpPost]
        [EnableCors("AllowSameDomain")]
        public async Task<GeneInfoDto> CreateGeneInfo(CreateGeneInfoDto input) {
            var geneInfo = ObjectMapper.Map<TB_GeneInfo>(input);
            geneInfo.ID = geneInfo.Id = GetMaxID() + 1;
            geneInfo.GeneName = geneInfo.GeneName.ToUpper();
            Int64 id= await repository.InsertAndGetIdAsync(geneInfo);
            return ObjectMapper.Map<GeneInfoDto>(geneInfo);
        }
        [HttpPost]
        [EnableCors("AllowSameDomain")]
        public async Task<GeneInfoDto> UpdateGeneInfo(GeneInfoDto input) {
            var geneInfo = ObjectMapper.Map<TB_GeneInfo>(input);
            await repository.UpdateAsync(geneInfo);
            return ObjectMapper.Map<GeneInfoDto>(geneInfo);
        }
        [EnableCors("AllowSameDomain")]
        public async Task DeleteGeneInfo(Int64 id) {
           await repository.DeleteAsync(a=>a.ID==id);
           await repositoryGeneInfo.DeleteAsync(a => a.GeneID == id);
        }
        public Int64 GetMaxID() {
            var maxId = repository.GetAll().OrderByDescending(a => a.ID).Select(a => a.ID).FirstOrDefault();
            return maxId;
        }
    }
}

﻿using Abp.Application.Services;
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

namespace MyDocumentManageNetCore.Application.ReagentInfos
{
    public class ReagentInfoAppService : ApplicationService, IReagentInfoAppService
    {
        //private readonly IReagentInfoRep dapperRepository;
        private readonly IRepository<TB_ReagentInfo, Int64> repository;
        //private readonly IReagentInfoRep dapperRepository;
        private readonly IRepository<TB_GeneInfo, Int64> geneInfoRepository;

        public ReagentInfoAppService(IRepository<TB_ReagentInfo, Int64> _repository,IRepository<TB_GeneInfo,Int64> _geneInfoRepository)
        {
            repository = _repository;
            geneInfoRepository = _geneInfoRepository;
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
            var geneInfos =await geneInfoRepository.GetAllListAsync();
            var genes = ObjectMapper.Map<List<GeneInfoDto>>(geneInfos);
            reagents.ForEach(a => a.GeneInfos = genes.Where(g => g.ReagentID == a.Id).OrderBy(t=>t.Id).ToList());
            //if (reagents!=null&&reagents.Count>0)
            //{
            //    foreach (var item in reagents)
            //    {
            //        item.GeneInfos = genes.Where(a => a.ReagentID == item.Id).ToList();
            //    }
            //}
            return reagents;
        }
        [HttpGet]
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
        
        [EnableCors("AllowSameDomain")]
        public async Task DeleteReagentInfo(Int64 id)
        {
            //var reagentInfo= repository.Get(id);
            await repository.DeleteAsync(a => a.ID == id);
        }

        public long GetMaxID()
        {
            Int64 maxId = repository.GetAll().OrderByDescending(a => a.Id).Select(a => a.Id).FirstOrDefault();
            return maxId;
        }

       
    }
}
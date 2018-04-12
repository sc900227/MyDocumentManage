using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Text;

namespace MyDocumentManageNetCore.Application.Dtos
{
    public class PagedAndFilteredInputDto : PagedAndSortedInputDto
    {
        //[Range(1, AppConsts.MaxPageSize)]
        //public int MaxResultCount { get; set; }

        //[Range(0, int.MaxValue)]
        //public int SkipCount { get; set; }

        public List<FilterInputDto> Filters { get; set; }

        public PagedAndFilteredInputDto()
        {
            MaxResultCount = AppConsts.DefaultPageSize;
        }
        
    }
}

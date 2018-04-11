using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyDocumentManageNetCore.Application.Dtos
{
    public class PagedAndSortedInputDto: PagedInputDto, ISortedResultRequest
    {
        public string Sorting { get; set; }
 
         public PagedAndSortedInputDto()
         {
             MaxResultCount = AppConsts.DefaultPageSize;
         }
}
}

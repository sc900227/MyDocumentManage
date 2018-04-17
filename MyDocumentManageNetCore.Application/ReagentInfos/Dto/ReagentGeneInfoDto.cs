using Abp.Application.Services.Dto;
using MyDocumentManageNetCore.Application.ReagentInfos.Dto;
using MyDocumentManageNetCore.Application.UserInfos.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyDocumentManageNetCore.Application.ReagentInfos.Dto
{
    public class ReagentGeneInfoDto: EntityDto<Int64>
    {
       
        /// <summary>
        /// 试剂名称
        /// </summary>
        [Required]
        public string ReagentName { get; set; }
        /// <summary>
        /// 作用药物
        /// </summary>
        public string ForDrug { get; set; }

        public List<GeneInfoDto> GeneInfos { get; set; }
    }
}

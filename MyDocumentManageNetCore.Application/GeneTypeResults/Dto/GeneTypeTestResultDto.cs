using Abp.Application.Services.Dto;
using MyDocumentManageNetCore.Application.GeneTestResults.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyDocumentManageNetCore.Application.GeneTypeResults.Dto
{
    public class GeneTypeTestResultDto:EntityDto<Int64>
    {
        /// <summary>
        /// 试剂ID
        /// </summary>
        public Int64 ReagentID { get; set; }
        /// <summary>
        /// 试剂名称
        /// </summary>
        public string ReagmentName { get; set; }
        /// <summary>
        /// 基因检测结果
        /// </summary>
        public List<GeneTestResultDto> GeneTestResults { get; set; }
        /// <summary>
        /// 结果解释
        /// </summary>
        public string ResultExpl { get; set; }
    }
}

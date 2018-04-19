using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyDocumentManageNetCore.Application.GeneTestResults.Dto
{
    public class CreateGeneTestResultDto: EntityDto<Int64>
    {
       
        /// <summary>
        /// 基因结果ID
        /// </summary>
        public Int64 GeneTypeResultID { get; set; }
        /// <summary>
        /// 基因位点ID
        /// </summary>
        public Int64 GeneID { get; set; }
        /// <summary>
        /// 基因型名称简写（W,H,M）
        /// </summary>
        public string GeneTypeShortName { get; set; }
    }
}

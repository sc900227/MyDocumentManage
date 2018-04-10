using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManageNetCore.Application.GeneTypeResults.Dto
{
    public class GeneTypeResultDto:EntityDto<Int64>
    {
        /// <summary>
        /// 试剂ID
        /// </summary>
        public Int64 ReagentID { get; set; }
        /// <summary>
        /// 基因型名称简写1
        /// </summary>
        public string GeneTypeShortName1 { get; set; }
        /// <summary>
        /// 基因型名称简写2
        /// </summary>
        public string GeneTypeShortName2 { get; set; }
        /// <summary>
        /// 结果解释
        /// </summary>
        public string ResultExpl { get; set; }
    }
}

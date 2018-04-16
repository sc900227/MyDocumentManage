using Abp.Application.Services.Dto;
using MyDocumentManageNetCore.Application.ReagentInfos.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyDocumentManageNetCore.Application.GeneInfos.Dto
{
    public class ReagentGeneInfoDto: EntityDto<Int64>
    {
        [Required]
        public string GeneName { get; set; }
        /// <summary>
        /// 检测方法
        /// </summary>
        [Required]
        public string TestMethod { get; set; }
        /// <summary>
        /// 基因型野生
        /// </summary>
        [Required]
        public string GeneTypeW { get; set; }
        /// <summary>
        /// 基因型杂合
        /// </summary>
        [Required]
        public string GeneTypeH { get; set; }
        /// <summary>
        /// 基因型突变
        /// </summary>
        [Required]
        public string GeneTypeM { get; set; }
        /// <summary>
        /// 基因型未知
        /// </summary>
        [Required]
        public string GeneTypeX { get; set; }
        
        /// 试剂盒名称
        /// </summary>
        [Required]
        public ReagentInfoDto ReagentInfo { get; set; }
    }
}

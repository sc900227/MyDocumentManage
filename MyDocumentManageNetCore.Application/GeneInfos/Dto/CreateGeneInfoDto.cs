using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManageNetCore.Application.UserInfos.Dto
{
    public class CreateGeneInfoDto: EntityDto<Int64>
    {
        /// <summary>
        /// 基因名称
        /// </summary>
        [Required]
        [Description("基因名称")]
        public string GeneName { get; set; }
        /// <summary>
        /// 检测方法
        /// </summary>
        [Required]
        [Description("检测方法")]
        public string TestMethod { get; set; }
        /// <summary>
        /// 基因型野生
        /// </summary>
        [Required]
        [Description("基因型野生")]
        public string GeneTypeW { get; set; }
        /// <summary>
        /// 基因型杂合
        /// </summary>
        [Required]
        [Description("基因型杂合")]
        public string GeneTypeH { get; set; }
        /// <summary>
        /// 基因型突变
        /// </summary>
        [Required]
        [Description("基因型突变")]
        public string GeneTypeM { get; set; }
        /// <summary>
        /// 基因型未知
        /// </summary>
        [Required]
        [Description("基因型未知")]
        public string GeneTypeX { get; set; }
        /// <summary>
        /// 试剂ID
        /// </summary>
        [Required]
        [Description("试剂ID")]
        public Int64 ReagentID { get; set; }
    }
}

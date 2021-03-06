﻿using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManage.Application.UserInfos.Dto
{
    public class CreateGeneInfoDto: EntityDto<Int64>
    {
        /// <summary>
        /// 基因名称
        /// </summary>
        public string GeneName { get; set; }
        /// <summary>
        /// 检测方法
        /// </summary>
        public string TestMethod { get; set; }
        /// <summary>
        /// 基因型野生
        /// </summary>
        public string GeneTypeW { get; set; }
        /// <summary>
        /// 基因型杂合
        /// </summary>
        public string GeneTypeH { get; set; }
        /// <summary>
        /// 基因型突变
        /// </summary>
        public string GeneTypeM { get; set; }
        /// <summary>
        /// 基因型未知
        /// </summary>
        public string GeneTypeX { get; set; }
        /// <summary>
        /// 基因型名称简写(野生)
        /// </summary>
        public string GeneTypeWShort { get; set; }
        /// <summary>
        /// 基因型名称简写(杂合)
        /// </summary>
        public string GeneTypeHShort { get; set; }
        /// <summary>
        /// 基因型名称简写(突变)
        /// </summary>
        public string GeneTypeMShort { get; set; }
        /// <summary>
        /// 基因型名称简写(未知)
        /// </summary>
        public string GeneTypeXShort { get; set; }
        /// <summary>
        /// 试剂ID
        /// </summary>
        public Int64 ReagentID { get; set; }
    }
}

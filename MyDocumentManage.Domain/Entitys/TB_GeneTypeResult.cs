using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MyDocumentManage.Domain.Entitys
{
    /// <summary>
    /// 基因型结果表
    /// </summary>
    [Table("TB_GeneTypeResult")]
    public class TB_GeneTypeResult:Entity<Int64>
    {
        ///// <summary>
        ///// 主键ID
        ///// </summary>
        //public Int64 ID { get; set; }
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

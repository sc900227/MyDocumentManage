using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyDocumentManageNetCore.Domain.Entitys
{
    [Table("TB_GeneTestResult")]
    public class TB_GeneTestResult: Entity<Int64>
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public Int64 ID { get; set; }
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

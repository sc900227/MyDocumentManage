using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MyDocumentManageNetCore.Domain.Entitys
{
    /// <summary>
    /// 试剂信息表
    /// </summary>
    [Table("TB_ReagentInfo")]
    public class TB_ReagentInfo: Entity<Int64>
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public Int64 ID { get; set; }
        /// <summary>
        /// 试剂名称
        /// </summary>
        public string ReagentName { get; set; }
        /// <summary>
        /// 作用药物
        /// </summary>
        public string ForDrug { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MyDocumentManageNetCore.Application.Dtos
{
    public class FilterInputDto
    {
        /// <summary>
        /// 字段名
        /// </summary>
        public string ColumName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ColumValue { get; set; }
    }
}

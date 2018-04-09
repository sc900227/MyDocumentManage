﻿using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManageNetCoreTest.Application.ReagentInfos.Dto
{
    public class CreateReagentInfoDto
    {
        /// <summary>
        /// 试剂名称
        /// </summary>
        [Required]
        public string ReagentName { get; set; }
        /// <summary>
        /// 作用药物
        /// </summary>
        public string ForDrug { get; set; }
    }
}

using FluentNHibernate.Mapping;
using MyDocumentManage.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocumentManage.Domain.Mapper
{
    public class TB_GeneInfoMapper:ClassMap<TB_GeneInfo>
    {
        public TB_GeneInfoMapper() {
            // 禁用惰性加载
            Not.LazyLoad();
            // 映射到表tweet
            Table("TB_GeneInfo");
            // 主键映射
            Id(x => x.Id).Column("ID");
            // 字段映射
            Map(x => x.GeneName).Column("GeneName");
            Map(x => x.GeneTypeH).Column("GeneTypeH");
        }
    }
}

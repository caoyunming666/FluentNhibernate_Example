using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlunteNhibernate_Test0910.Models
{
    /// <summary>
    /// 实体映射
    /// </summary>
    public class PersionMapping : ClassMap<Persion>
    {
        public PersionMapping()
        {
            Table("local_persion");

            Id(x => x.Id).Column("Id");
            Map(x => x.Name).Column("Name");
            Map(x => x.Age).Column("Age");
        }
    }
}
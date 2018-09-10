using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlunteNhibernate_Test0910.Models
{
    public class Persion
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int Age { get; set; }
    }
}
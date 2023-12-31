﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Category:Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }
        public virtual ICollection<CategoryPost> Posts { get; set; }
    }
}

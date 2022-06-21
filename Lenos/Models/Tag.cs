﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lenos.Models
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }

        public IEnumerable<ProductTag> ProductTags { get; set; }
    }
}

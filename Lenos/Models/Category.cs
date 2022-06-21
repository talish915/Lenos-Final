﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lenos.Models
{
    public class Category : BaseEntity
    {
        [StringLength(255), Required]
        public string Name { get; set; }


        public IEnumerable<Product> Products { get; set; }
    }
}

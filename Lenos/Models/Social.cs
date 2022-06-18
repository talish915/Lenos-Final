using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lenos.Models
{
    public class Social : BaseEntity
    {
        [StringLength(255), Required]
        public string Icon { get; set; }
        [StringLength(255), Required]
        public string Name { get; set; }
        [StringLength(255), Required]
        public string Link { get; set; }
    }
}

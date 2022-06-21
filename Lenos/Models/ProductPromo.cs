using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lenos.Models
{
    public class ProductPromo : BaseEntity
    {
        [StringLength(255), Required]
        public string Title { get; set; }
        [StringLength(255), Required]
        public string Description { get; set; }
        [StringLength(1000)]
        public string Image { get; set; }

        [NotMapped]
        public IFormFile PromoImage { get; set; }
    }
}

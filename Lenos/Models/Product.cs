using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lenos.Models
{
    public class Product : BaseEntity
    {
        [StringLength(255), Required]
        public string Title { get; set; }
        [Column(TypeName = "money")]
        public double Price { get; set; }
        [Column(TypeName = "money")]
        public double DiscountPrice { get; set; }
        public bool Availability { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public string SKU { get; set; }
        public string Image { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public IEnumerable<ProductTag> ProductTags { get; set; }

        [NotMapped]
        public List<int> TagIds { get; set; } = new List<int>();
    }
}

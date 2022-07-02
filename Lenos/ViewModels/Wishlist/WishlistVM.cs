using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lenos.ViewModels.Wishlist
{
    public class WishlistVM
    {
        public string Title { get; set; }
        public int ProductId { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public string Image { get; set; }
        public bool Availability { get; set; }
        public DateTime AddDate { get; set; }
    }
}

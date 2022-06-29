using Lenos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lenos.ViewModels.Home
{
    public class HomeVM
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Banner> Banners { get; set; }
        public IEnumerable<CategoryBanner> CategoryBanners { get; set; }
        public IEnumerable<ProductPromo> ProductPromos { get; set; }
        public IEnumerable<Slider> Sliders { get; set; }
    }
}

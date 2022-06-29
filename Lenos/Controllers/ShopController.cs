using Lenos.DAL;
using Lenos.Models;
using Lenos.ViewModels.Shop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lenos.Controllers
{
    public class ShopController : Controller
    {
        private readonly LenosDbContext _context;
        public ShopController(LenosDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            ShopVM shopVM = new ShopVM
            {
                Products = await _context.Products.Include(p => p.ProductTags).Include(p => p.Category)
                .Where(c => !c.IsDeleted).ToListAsync(),
                Categories = await _context.Categories.Include(c => c.Products).Where(c => !c.IsDeleted).ToListAsync(),
                Tags = await _context.Tags.Include(p => p.ProductTags).Where(c => !c.IsDeleted).ToListAsync(),

            };
            return View(shopVM);
        }

        public async Task<IActionResult> SortByCategory(int? id)
        {
            IEnumerable<Product> product = await _context.Products.Include(p => p.Category).Where(p => id == p.Category.Id && !p.IsDeleted).ToListAsync();

            if (product == null) return NotFound();



            return PartialView("_ShopProductPartial",product);
        }

        public async Task<IActionResult> SortByTag(int? id)
        {
            IEnumerable<ProductTag> productTags = await _context.ProductTags.Include(p => p.Product).ToListAsync();

            List<Product> product = new List<Product>();

            foreach (ProductTag item in productTags)
            {
                if (item.TagId == id)
                {
                    product.Add(item.Product);
                }
            }

            if (product == null) return NotFound();



            return PartialView("_ShopProductPartial", product);
        }
    }
}

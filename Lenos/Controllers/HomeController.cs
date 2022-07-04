using Lenos.DAL;
using Lenos.Models;
using Lenos.ViewModels.Basket;
using Lenos.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lenos.Controllers
{
    public class HomeController : Controller
    {
        private readonly LenosDbContext _context;
        public HomeController(LenosDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Products = await _context.Products.Include(p => p.ProductTags).Include(p=> p.Category)
                .Where(c => !c.IsDeleted).ToListAsync(),
                Sliders = await _context.Sliders.Where(c => !c.IsDeleted).ToListAsync(),
                Banners = await _context.Banners.Where(b => !b.IsDeleted).ToListAsync(),
                ProductPromos = await _context.ProductPromos.Where(b => !b.IsDeleted).ToListAsync(),
                CategoryBanners = await _context.CategoryBanners.Where(c => !c.IsDeleted).ToListAsync(),

            };
            return View(homeVM);
        }

        public async Task<IActionResult> DetailModal(int? id)
        {

            if (id == null) return BadRequest();

            Product product = await _context.Products
                .Include(p => p.ProductTags)
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (product == null) return NotFound();

            return PartialView("_ProductModalPartial", product);
        }
    }
}

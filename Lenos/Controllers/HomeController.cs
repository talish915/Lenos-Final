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
        public async Task<IActionResult> AddToBasket(int? id, int count = 1)
        {
            if (id == null) return BadRequest();
            Product dBproduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
            if (dBproduct == null) return NotFound();

            //List<Product> products = null;
            List<BasketVM> basketVMs = null;

            string cookie = HttpContext.Request.Cookies["basket"];

            if (cookie != null)
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(cookie);
                if (basketVMs.Any(b => b.ProductId == id))
                {
                    basketVMs.Find(b => b.ProductId == id).Count += count;
                }
                else
                {
                    basketVMs.Add(new BasketVM
                    {
                        ProductId = (int)id,
                        Count = count,
                    });
                }
            }
            else
            {
                basketVMs = new List<BasketVM>();

                basketVMs.Add(new BasketVM()
                {
                    ProductId = (int)id,
                    Count = count,
                });
            }


            HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(basketVMs));

            foreach (BasketVM basketVM in basketVMs)
            {
                Product dbProduct = await _context.Products
                    .FirstOrDefaultAsync(p => p.Id == basketVM.ProductId);
                basketVM.Image = dbProduct.MainImage;
                basketVM.Price = dbProduct.DiscountPrice > 0 ? dbProduct.DiscountPrice : dbProduct.Price;
                basketVM.Title = dbProduct.Title;
            }

            return PartialView("_BasketPartial", basketVMs);
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

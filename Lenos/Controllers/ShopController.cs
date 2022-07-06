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
        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.PageIndex = page;
            ViewBag.Categories = await _context.Categories.Where(p => !p.IsDeleted).Include(p=>p.Products).ToListAsync();
            ViewBag.Tags = await _context.Tags.Where(p => !p.IsDeleted).ToListAsync();

            List<Product> products = await _context.Products
                    .Where(p => !p.IsDeleted
                    && !p.Category.IsDeleted)
                    .ToListAsync();
            ViewBag.PageCount = Math.Ceiling((double)products.Count() / 5);
            return View(products.Skip((page - 1) * 5).Take(5));
        }
        public async Task<IActionResult> Filter(string tags, string countby, int sortby, int category,int minprice,int maxprice)
        {
            IQueryable<Product> products = _context.Products
                .Include(p => p.Category)
                .Include(p => p.ProductTags).ThenInclude(p => p.Tag).Where(p => !p.IsDeleted);

            if (
                string.IsNullOrWhiteSpace(countby)
                && string.IsNullOrWhiteSpace(category.ToString())
                && string.IsNullOrWhiteSpace(tags)
                && string.IsNullOrWhiteSpace(sortby.ToString())
                && string.IsNullOrWhiteSpace(minprice.ToString())
                && string.IsNullOrWhiteSpace(maxprice.ToString())
                )
            {
                return PartialView("_ShopProductPartial", products.ToList());
            }
            
            if (!string.IsNullOrWhiteSpace(category.ToString()) && category != 0)
            {
                    products = products
                        .Where(p => p.CategoryId == category);
            }
            if (!string.IsNullOrWhiteSpace(tags))
            {
                string[] tag = tags.Split(",");
                foreach (var t in tag)
                {
                    products = products
                        .Where(p => p.ProductTags.Any(p=>p.Tag.Id.ToString() == t.ToString()));

                }
            }
            if (!string.IsNullOrWhiteSpace(countby))
            {
                switch (countby)
                {
                    case "1":
                        products = products.Take(12);
                        break;
                    case "2":
                        products = products.Take(24);
                        break;
                    default:
                        products = products;
                        break;
                }
            }
            if (!string.IsNullOrWhiteSpace(sortby.ToString()))
            {
                switch (sortby)
                {
                    case 1:
                        products = products;
                        break;
                    case 2:
                        products = products.OrderBy(p => p.Title);
                        break;
                    case 3:
                        products = products.OrderByDescending(p => p.Title);
                        break;
                    case 4:
                        products = products.OrderBy(p => p.CreatedAt);
                        break;
                    case 5:
                        products = products.OrderByDescending(p => p.CreatedAt);
                        break;
                    default:
                        break;
                }
            }
            if (!string.IsNullOrWhiteSpace(minprice.ToString()))
            {
                if (products.Any(p => p.DiscountPrice > 0))
                {
                    products = products.Where(p => p.DiscountPrice > minprice);
                }
                else
                {
                    products = products.Where(p => p.Price > minprice);
                }
            }
            if (!string.IsNullOrWhiteSpace(maxprice.ToString()))
            {
                if (products.Any(p => p.DiscountPrice > 0))
                {
                    products = products.Where(p => p.DiscountPrice < maxprice);
                }
                else
                {
                    products = products.Where(p => p.Price < maxprice);
                }
            }
            return PartialView("_ShopProductPartial", products.ToList());
        }
    }
}

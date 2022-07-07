using Lenos.DAL;
using Lenos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lenos.Controllers
{
    public class ProductController : Controller
    {
        private readonly LenosDbContext _context;

        public ProductController(LenosDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? id)
        {
            ViewBag.Products = await _context.Products.Include(p => p.Category).Include(p => p.ProductTags).ThenInclude(p => p.Tag).Where(p => !p.IsDeleted).Take(4).ToListAsync();
            ViewBag.Tags = await _context.Tags.Include(p => p.ProductTags).Where(p => !p.IsDeleted).ToListAsync();

            Product product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .Include(p => p.ProductTags).ThenInclude(p => p.Tag)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
            return View(product);
        }
    }
}

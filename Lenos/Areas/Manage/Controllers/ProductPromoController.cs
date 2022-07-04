using Lenos.DAL;
using Lenos.Extensions;
using Lenos.Helpers;
using Lenos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lenos.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class ProductPromoController : Controller
    {
        private readonly LenosDbContext _context;
        private readonly IWebHostEnvironment _env;


        public ProductPromoController(LenosDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index(bool? status, int page = 1)
        {
            ViewBag.Status = status;

            IEnumerable<ProductPromo> productPromos = await _context.ProductPromos
                .Where(s => status != null ? s.IsDeleted == status : true)
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)productPromos.Count() / 2);

            return View(productPromos.Skip((page - 1) * 2).Take(2));
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.ProductPromos = await _context.ProductPromos.Where(c => !c.IsDeleted).ToListAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductPromo productPromo, bool? status, int page = 1)
        {
            ViewBag.ProductPromos = await _context.ProductPromos.Where(s => !s.IsDeleted).ToListAsync();

            if (!ModelState.IsValid)
            {
                return View();
            }

            productPromo.Title = productPromo.Title.Trim();
            productPromo.Description = productPromo.Description.Trim();

            Regex regex = new Regex(@"\s{2,}");
            if (regex.IsMatch(productPromo.Title) && regex.IsMatch(productPromo.Description))
            {
                ModelState.AddModelError("Title", "Should not be Space");
                ModelState.AddModelError("Description", "Should not be Space");
                return View();
            }

            if (productPromo.PromoImage == null)
            {
                ModelState.AddModelError("PromoImage", "Image Must be chosen!");
                return View();
            }
            else
            {
                if (!productPromo.PromoImage.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("PromoImage", "Image type must be in jpeg adn jpg format!");
                    return View();
                }

                if (!productPromo.PromoImage.CheckFileSize(1000))
                {
                    ModelState.AddModelError("PromoImage", "Image size must be a maximum of 1000KB!");
                    return View();
                }
                productPromo.Image = productPromo.PromoImage.CreateFile(_env, "assets", "img", "product-promo");
            }

            productPromo.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.ProductPromos.AddAsync(productPromo);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status = status, page = page });
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();

            ProductPromo productPromo = await _context.ProductPromos.FirstOrDefaultAsync(s => s.Id == id);

            if (productPromo == null) return NotFound();

            ViewBag.ProductPromos = await _context.ProductPromos.Where(s => s.Id != id && !s.IsDeleted).ToListAsync();

            return View(productPromo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, ProductPromo productPromo, bool? status, int page = 1)
        {
            ViewBag.ProductPromos = await _context.ProductPromos.Where(s => s.Id != id && !s.IsDeleted).ToListAsync();

            ProductPromo dbProductPromo = await _context.ProductPromos.FirstOrDefaultAsync(s => s.Id == id);

            if (dbProductPromo == null) return NotFound();

            if (!ModelState.IsValid)
            {
                return View(dbProductPromo);
            }

            if (id != dbProductPromo.Id) return BadRequest();

            productPromo.Title = productPromo.Title.Trim();
            productPromo.Description = productPromo.Description.Trim();

            Regex regex = new Regex(@"\s{2,}");
            if (regex.IsMatch(productPromo.Title) && regex.IsMatch(productPromo.Description))
            {
                ModelState.AddModelError("Title", "Should not be Space");
                ModelState.AddModelError("Description", "Should not be Space");
                return View();
            }

            if (productPromo.PromoImage != null)
            {
                if (!productPromo.PromoImage.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("PromoImage", "Image type must be in jpeg and jpg format!");
                    return View();
                }

                if (!productPromo.PromoImage.CheckFileSize(1000))
                {
                    ModelState.AddModelError("SliderImage", "Image size must be a maximum of 1000KB!");
                    return View();
                }

                Helper.DeleteFile(_env, dbProductPromo.Image, "assets", "img", "product-promo");

                dbProductPromo.Image = dbProductPromo.PromoImage.CreateFile(_env, "assets", "img", "product-promo");
            }

            dbProductPromo.Title = dbProductPromo.Title;
            dbProductPromo.Description = dbProductPromo.Description;

            dbProductPromo.UpdatedAt = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status = status, page = page });
        }

        public async Task<IActionResult> Delete(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            ProductPromo dbProductPromo = await _context.ProductPromos.FirstOrDefaultAsync(s => s.Id == id);

            if (dbProductPromo == null) return NotFound();

            dbProductPromo.IsDeleted = true;
            dbProductPromo.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();


            IEnumerable<ProductPromo> productPromos = await _context.ProductPromos
                .Where(s => status != null ? s.IsDeleted == status : true)
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)productPromos.Count() / 2);

            return PartialView("_ProductPromoIndexPartial", productPromos.Skip((page - 1) * 2).Take(2));
        }

        public async Task<IActionResult> Restore(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            ProductPromo dbProductPromo = await _context.ProductPromos.FirstOrDefaultAsync(s => s.Id == id);

            if (dbProductPromo == null) return NotFound();

            dbProductPromo.IsDeleted = false;

            await _context.SaveChangesAsync();

            IEnumerable<ProductPromo> productPromos = await _context.ProductPromos
                .Where(s => status != null ? s.IsDeleted == status : true)
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)productPromos.Count() / 2);

            return PartialView("_ProductPromoIndexPartial", productPromos.Skip((page - 1) * 2).Take(2));
        }
    }
}

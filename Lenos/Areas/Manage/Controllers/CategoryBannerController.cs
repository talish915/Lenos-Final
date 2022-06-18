using Lenos.DAL;
using Lenos.Extensions;
using Lenos.Helpers;
using Lenos.Models;
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
    public class CategoryBannerController : Controller
    {
        private readonly LenosDbContext _context;
        private readonly IWebHostEnvironment _env;


        public CategoryBannerController(LenosDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index(bool? status, int page = 1)
        {
            ViewBag.Status = status;

            IEnumerable<CategoryBanner> categoryBanners = await _context.CategoryBanners
                .Where(s => status != null ? s.IsDeleted == status : true)
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)categoryBanners.Count() / 3);

            return View(categoryBanners.Skip((page - 1) * 3).Take(3));
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryBanners = await _context.CategoryBanners.Where(c => !c.IsDeleted).ToListAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryBanner categoryBanner, bool? status, int page = 1)
        {
            ViewBag.CategoryBanners = await _context.CategoryBanners.Where(s => !s.IsDeleted).ToListAsync();

            if (!ModelState.IsValid)
            {
                return View();
            }

            categoryBanner.Title = categoryBanner.Title.Trim();

            Regex regex = new Regex(@"\s{2,}");
            if (regex.IsMatch(categoryBanner.Title))
            {
                ModelState.AddModelError("Title", "Should not be Space");
                return View();
            }

            if (categoryBanner.BannerImage == null)
            {
                ModelState.AddModelError("BannerImage", "Image Must be chosen!");
                return View();
            }
            else
            {
                if (!categoryBanner.BannerImage.CheckFileContentType("image/png"))
                {
                    ModelState.AddModelError("BannerImage", "Image type must be in png format!");
                    return View();
                }

                if (!categoryBanner.BannerImage.CheckFileSize(500))
                {
                    ModelState.AddModelError("BannerImage", "Image size must be a maximum of 500KB!");
                    return View();
                }
                categoryBanner.Image = categoryBanner.BannerImage.CreateFile(_env, "assets", "img", "category-banner");
            }

            categoryBanner.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.CategoryBanners.AddAsync(categoryBanner);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status = status, page = page });
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();

            CategoryBanner categoryBanner = await _context.CategoryBanners.FirstOrDefaultAsync(s => s.Id == id);

            if (categoryBanner == null) return NotFound();

            ViewBag.CategoryBanners = await _context.CategoryBanners.Where(s => s.Id != id && !s.IsDeleted).ToListAsync();

            return View(categoryBanner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, CategoryBanner categoryBanner, bool? status, int page = 1)
        {
            ViewBag.CategoryBanners = await _context.CategoryBanners.Where(s => s.Id != id && !s.IsDeleted).ToListAsync();

            CategoryBanner dbCategoryBanner = await _context.CategoryBanners.FirstOrDefaultAsync(s => s.Id == id);

            if (dbCategoryBanner == null) return NotFound();

            if (!ModelState.IsValid)
            {
                return View(dbCategoryBanner);
            }

            if (id != dbCategoryBanner.Id) return BadRequest();

            categoryBanner.Title = categoryBanner.Title.Trim();

            Regex regex = new Regex(@"\s{2,}");
            if (regex.IsMatch(categoryBanner.Title))
            {
                ModelState.AddModelError("Title", "Should not be Space");
                return View();
            }

            if (categoryBanner.BannerImage != null)
            {
                if (!categoryBanner.BannerImage.CheckFileContentType("image/png"))
                {
                    ModelState.AddModelError("BannerImage", "Image type must be in png format!");
                    return View();
                }

                if (!categoryBanner.BannerImage.CheckFileSize(500))
                {
                    ModelState.AddModelError("BannerImage", "Image size must be a maximum of 500KB!");
                    return View();
                }

                Helper.DeleteFile(_env, dbCategoryBanner.Image, "assets", "img", "category-banner");

                dbCategoryBanner.Image = dbCategoryBanner.BannerImage.CreateFile(_env, "assets", "img", "category-banner");
            }

            dbCategoryBanner.Title = categoryBanner.Title;

            dbCategoryBanner.UpdatedAt = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status = status, page = page });
        }

        public async Task<IActionResult> Delete(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            CategoryBanner dbCategoryBanner = await _context.CategoryBanners.FirstOrDefaultAsync(s => s.Id == id);

            if (dbCategoryBanner == null) return NotFound();

            dbCategoryBanner.IsDeleted = true;
            dbCategoryBanner.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();


            IEnumerable<CategoryBanner> categoryBanners = await _context.CategoryBanners
                .Where(s => status != null ? s.IsDeleted == status : true)
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)categoryBanners.Count() / 3);

            return PartialView("_CategoryBannerIndexPartial", categoryBanners.Skip((page - 1) * 3).Take(3));
        }

        public async Task<IActionResult> Restore(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            CategoryBanner dbCategoryBanner = await _context.CategoryBanners.FirstOrDefaultAsync(s => s.Id == id);

            if (dbCategoryBanner == null) return NotFound();

            dbCategoryBanner.IsDeleted = false;

            await _context.SaveChangesAsync();

            IEnumerable<CategoryBanner> categoryBanners = await _context.CategoryBanners
                .Where(s => status != null ? s.IsDeleted == status : true)
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)categoryBanners.Count() / 3);

            return PartialView("_CategoryBannerIndexPartial", categoryBanners.Skip((page - 1) * 3).Take(3));
        }
    }
}

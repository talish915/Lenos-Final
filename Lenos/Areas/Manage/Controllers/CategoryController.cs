using Lenos.DAL;
using Lenos.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class CategoryController : Controller
    {
        private readonly LenosDbContext _context;


        public CategoryController(LenosDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(bool? status, int page = 1)
        {
            ViewBag.Status = status;

            IEnumerable<Category> categories = await _context.Categories
                .Include(c => c.Products)
                .Where(c => status != null ? c.IsDeleted == status : true)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)categories.Count() / 5);

            return View(categories.Skip((page - 1) * 5).Take(5));
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.MainCategory = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category, bool? status, int page = 1)
        {
            ViewBag.MainCategory = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();

            if (!ModelState.IsValid)
            {
                return View();
            }

            category.Name = category.Name.Trim();

            Regex regex = new Regex(@"\s{2,}");
            if (regex.IsMatch(category.Name))
            {
                ModelState.AddModelError("Name", "Should not be Space");
                return View();
            }

            if (await _context.Categories.AnyAsync(c => c.Name.ToLower() == category.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View();
            }

            category.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status = status, page = page });
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();

            Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (category == null) return NotFound();

            ViewBag.MainCategory = await _context.Categories.Where(c => c.Id != id && !c.IsDeleted).ToListAsync();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Category category, bool? status, int page = 1)
        {
            ViewBag.MainCategory = await _context.Categories.Where(c => c.Id != id && !c.IsDeleted).ToListAsync();

            Category dbCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (dbCategory == null) return NotFound();

            if (!ModelState.IsValid)
            {
                return View(dbCategory);
            }

            if (id != category.Id) return BadRequest();

            category.Name = category.Name.Trim();

            Regex regex = new Regex(@"\s{2,}");
            if (regex.IsMatch(category.Name))
            {
                ModelState.AddModelError("Name", "Should not be Space");
                return View();
            }

            if (await _context.Categories.AnyAsync(c => c.Id != id && c.Name.ToLower() == category.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View(dbCategory);
            }

            dbCategory.Name = category.Name;
            dbCategory.UpdatedAt = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status = status, page = page });
        }
        public async Task<IActionResult> Delete(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Category dbCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (dbCategory == null) return NotFound();

            dbCategory.IsDeleted = true;
            dbCategory.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            IEnumerable<Category> categories = await _context.Categories
                .Include(c => c.Products)
                .Where(c => status != null ? c.IsDeleted == status : true)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)categories.Count() / 5);

            return PartialView("_CategoryIndexPartial", categories.Skip((page - 1) * 5).Take(5));
        }

        public async Task<IActionResult> Restore(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Category dbCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (dbCategory == null) return NotFound();

            dbCategory.IsDeleted = false;

            await _context.SaveChangesAsync();

            IEnumerable<Category> categories = await _context.Categories
                .Include(c => c.Products)
                .Where(c => status != null ? c.IsDeleted == status : true)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)categories.Count() / 5);

            return PartialView("_CategoryIndexPartial", categories.Skip((page - 1) * 5).Take(5));
        }
    }
}

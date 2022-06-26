using Lenos.DAL;
using Lenos.Extensions;
using Lenos.Models;
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
    public class TagController : Controller
    {
        private readonly LenosDbContext _context;


        public TagController(LenosDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(bool? status, int page = 1)
        {
            ViewBag.Status = status;

            IEnumerable<Tag> tags = await _context.Tags
                .Include(c => c.ProductTags)
                .Where(c => status != null ? c.IsDeleted == status : true)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)tags.Count() / 5);

            return View(tags.Skip((page - 1) * 5).Take(5));
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Tags = await _context.Tags.Where(c => !c.IsDeleted).ToListAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tag tag, bool? status, int page = 1)
        {
            ViewBag.Tags = await _context.Tags.Where(c => !c.IsDeleted).ToListAsync();

            if (!ModelState.IsValid)
            {
                return View();
            }

            tag.Name = tag.Name.Trim();

            Regex regex = new Regex(@"\s{2,}");
            if (regex.IsMatch(tag.Name))
            {
                ModelState.AddModelError("Name", "Should not be Space");
                return View();
            }

            if (await _context.Tags.AnyAsync(c => c.Name.ToLower() == tag.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View();
            }

            tag.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status = status, page = page });
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();

            Tag tag = await _context.Tags.FirstOrDefaultAsync(c => c.Id == id);

            if (tag == null) return NotFound();

            ViewBag.Tags = await _context.Tags.Where(c => c.Id != id && !c.IsDeleted).ToListAsync();

            return View(tag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Tag tag, bool? status, int page = 1)
        {
            ViewBag.Tags = await _context.Tags.Where(c => c.Id != id && !c.IsDeleted).ToListAsync();

            Tag dbTag = await _context.Tags.FirstOrDefaultAsync(c => c.Id == id);

            if (dbTag == null) return NotFound();

            if (!ModelState.IsValid)
            {
                return View(dbTag);
            }

            if (id != tag.Id) return BadRequest();

            tag.Name = tag.Name.Trim();

            Regex regex = new Regex(@"\s{2,}");
            if (regex.IsMatch(tag.Name))
            {
                ModelState.AddModelError("Name", "Should not be Space");
                return View();
            }

            if (await _context.Tags.AnyAsync(c => c.Id != id && c.Name.ToLower() == tag.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View(dbTag);
            }

            dbTag.Name = tag.Name;
            dbTag.UpdatedAt = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status = status, page = page });
        }
        public async Task<IActionResult> Delete(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Tag dbTag = await _context.Tags.FirstOrDefaultAsync(c => c.Id == id);

            if (dbTag == null) return NotFound();

            dbTag.IsDeleted = true;
            dbTag.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            IEnumerable<Tag> tags = await _context.Tags
                .Include(c => c.ProductTags)
                .Where(c => status != null ? c.IsDeleted == status : true)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)tags.Count() / 5);

            return PartialView("_TagIndexPartial", tags.Skip((page - 1) * 5).Take(5));
        }

        public async Task<IActionResult> Restore(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Tag dbTag = await _context.Tags.FirstOrDefaultAsync(c => c.Id == id);

            if (dbTag == null) return NotFound();

            dbTag.IsDeleted = false;

            await _context.SaveChangesAsync();

            IEnumerable<Tag> tags = await _context.Tags
                .Include(c => c.ProductTags)
                .Where(c => status != null ? c.IsDeleted == status : true)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)tags.Count() / 5);

            return PartialView("_TagIndexPartial", tags.Skip((page - 1) * 5).Take(5));
        }
    }
}

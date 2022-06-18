using Lenos.DAL;
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
    public class SocialController : Controller
    {
        private readonly LenosDbContext _context;

        public SocialController(LenosDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(bool? status, int page = 1)
        {
            ViewBag.Status = status;

            IEnumerable<Social> socials = await _context.Socials
                .Where(s => status != null ? s.IsDeleted == status : true)
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)socials.Count() / 5);

            return View(socials.Skip((page - 1) * 5).Take(5));
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Social = await _context.Socials.Where(s => !s.IsDeleted).ToListAsync();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Social social, bool? status, int page = 1)
        {
            ViewBag.Social = await _context.Socials.Where(s => !s.IsDeleted).ToListAsync();

            if (!ModelState.IsValid)
            {
                return View();
            }

            social.Icon = social.Icon.Trim();
            social.Name = social.Name.Trim();

            Regex regex = new Regex(@"\s{2,}");
            if (regex.IsMatch(social.Icon) && regex.IsMatch(social.Name))
            {
                ModelState.AddModelError("Icon", "Should not be Space");
                ModelState.AddModelError("Name", "Should not be Space");
                return View();
            }

            for (int i = 0; i < social.Link.Length; i++)
            {
                if (social.Link[i] == ' ')
                {
                    ModelState.AddModelError("Link", "Should not be Space");
                    return View();
                }
            }

            if (await _context.Socials.AnyAsync(s => s.Name.ToLower() == social.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View();
            }

            social.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.Socials.AddAsync(social);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status = status, page = page });
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();

            Social social = await _context.Socials.FirstOrDefaultAsync(s => s.Id == id);

            if (social == null) return NotFound();

            ViewBag.Social = await _context.Socials.Where(s => s.Id != id && !s.IsDeleted).ToListAsync();

            return View(social);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Social social, bool? status, int page = 1)
        {
            ViewBag.Social = await _context.Socials.Where(s => s.Id != id && !s.IsDeleted).ToListAsync();

            Social dbSocial = await _context.Socials.FirstOrDefaultAsync(s => s.Id == id);

            if (dbSocial == null) return NotFound();

            if (!ModelState.IsValid)
            {
                return View(dbSocial);
            }

            if (id != social.Id) return BadRequest();

            social.Icon = social.Icon.Trim();
            social.Name = social.Name.Trim();

            Regex regex = new Regex(@"\s{2,}");
            if (regex.IsMatch(social.Icon) && regex.IsMatch(social.Name))
            {
                ModelState.AddModelError("Icon", "Should not be Space");
                ModelState.AddModelError("Name", "Should not be Space");
                return View();
            }

            for (int i = 0; i < social.Link.Length; i++)
            {
                if (social.Link[i] == ' ')
                {
                    ModelState.AddModelError("Link", "Should not be Space");
                    return View();
                }
            }

            if (await _context.Socials.AnyAsync(s => s.Id != id && s.Name.ToLower() == social.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View(dbSocial);
            }
            dbSocial.Link = social.Link;
            dbSocial.Name = social.Name;
            dbSocial.Icon = social.Icon;
            dbSocial.UpdatedAt = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status = status, page = page });
        }
        public async Task<IActionResult> Delete(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Social dbSocial = await _context.Socials.FirstOrDefaultAsync(s => s.Id == id);

            if (dbSocial == null) return NotFound();

            dbSocial.IsDeleted = true;
            dbSocial.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();


            IEnumerable<Social> socials = await _context.Socials
                .Where(s => status != null ? s.IsDeleted == status : true)
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)socials.Count() / 5);

            return PartialView("_SocialIndexPartial", socials.Skip((page - 1) * 5).Take(5));
        }

        public async Task<IActionResult> Restore(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Social dbSocial = await _context.Socials.FirstOrDefaultAsync(s => s.Id == id);

            if (dbSocial == null) return NotFound();

            dbSocial.IsDeleted = false;

            await _context.SaveChangesAsync();

            IEnumerable<Social> socials = await _context.Socials
                .Where(s => status != null ? s.IsDeleted == status : true)
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)socials.Count() / 5);

            return PartialView("_SocialIndexPartial", socials.Skip((page - 1) * 5).Take(5));
        }
    }
}

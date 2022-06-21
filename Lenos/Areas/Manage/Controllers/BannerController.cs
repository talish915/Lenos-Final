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
    public class BannerController : Controller
    {
        private readonly LenosDbContext _context;
        private readonly IWebHostEnvironment _env;


        public BannerController(LenosDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index(bool? status, int page = 1)
        {
            ViewBag.Status = status;

            IEnumerable<Banner> banners = await _context.Banners
                .Where(s => status != null ? s.IsDeleted == status : true)
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)banners.Count() / 2);

            return View(banners.Skip((page - 1) * 2).Take(2));
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Banners = await _context.Banners.Where(c => !c.IsDeleted).ToListAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Banner banner, bool? status, int page = 1)
        {
            ViewBag.Banners = await _context.Banners.Where(s => !s.IsDeleted).ToListAsync();

            if (!ModelState.IsValid)
            {
                return View();
            }

            banner.Title = banner.Title.Trim();
            banner.SubTitle = banner.SubTitle.Trim();

            Regex regex = new Regex(@"\s{2,}");
            if (regex.IsMatch(banner.Title) && regex.IsMatch(banner.SubTitle))
            {
                ModelState.AddModelError("Title", "Should not be Space");
                ModelState.AddModelError("SubTitle", "Should not be Space");
                return View();
            }

            if (banner.BannerImage == null)
            {
                ModelState.AddModelError("BannerImage", "Image Must be chosen!");
                return View();
            }
            else
            {
                if (!banner.BannerImage.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("BannerImage", "Image type must be in jpeg adn jpg format!");
                    return View();
                }

                if (!banner.BannerImage.CheckFileSize(1000))
                {
                    ModelState.AddModelError("SliderImage", "Image size must be a maximum of 1000KB!");
                    return View();
                }
                banner.Image = banner.BannerImage.CreateFile(_env, "assets", "img", "banner");
            }

            banner.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.Banners.AddAsync(banner);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status = status, page = page });
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();

            Banner banner = await _context.Banners.FirstOrDefaultAsync(s => s.Id == id);

            if (banner == null) return NotFound();

            ViewBag.Banners = await _context.Banners.Where(s => s.Id != id && !s.IsDeleted).ToListAsync();

            return View(banner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Banner banner, bool? status, int page = 1)
        {
            ViewBag.Banners = await _context.Banners.Where(s => s.Id != id && !s.IsDeleted).ToListAsync();

            Banner dbBanner = await _context.Banners.FirstOrDefaultAsync(s => s.Id == id);

            if (dbBanner == null) return NotFound();

            if (!ModelState.IsValid)
            {
                return View(dbBanner);
            }

            if (id != dbBanner.Id) return BadRequest();

            banner.Title = banner.Title.Trim();
            banner.SubTitle = banner.SubTitle.Trim();

            Regex regex = new Regex(@"\s{2,}");
            if (regex.IsMatch(banner.Title) && regex.IsMatch(banner.SubTitle))
            {
                ModelState.AddModelError("Title", "Should not be Space");
                ModelState.AddModelError("SubTitle", "Should not be Space");
                return View();
            }

            if (banner.BannerImage != null)
            {
                if (!banner.BannerImage.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("BannerImage", "Image type must be in jpeg and jpg format!");
                    return View();
                }

                if (!banner.BannerImage.CheckFileSize(1000))
                {
                    ModelState.AddModelError("BanerImage", "Image size must be a maximum of 1000KB!");
                    return View();
                }

                Helper.DeleteFile(_env, dbBanner.Image, "assets", "img", "slider");

                dbBanner.Image = dbBanner.BannerImage.CreateFile(_env, "assets", "img", "slider");
            }

            dbBanner.Title = dbBanner.Title;
            dbBanner.SubTitle = dbBanner.SubTitle;

            dbBanner.UpdatedAt = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status = status, page = page });
        }

        public async Task<IActionResult> Delete(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Banner dbBanner = await _context.Banners.FirstOrDefaultAsync(s => s.Id == id);

            if (dbBanner == null) return NotFound();

            dbBanner.IsDeleted = true;
            dbBanner.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();


            IEnumerable<Banner> banners = await _context.Banners
                .Where(s => status != null ? s.IsDeleted == status : true)
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)banners.Count() / 2);

            return PartialView("_BannerIndexPartial", banners.Skip((page - 1) * 2).Take(2));
        }

        public async Task<IActionResult> Restore(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Banner dbBanner = await _context.Banners.FirstOrDefaultAsync(s => s.Id == id);

            if (dbBanner == null) return NotFound();

            dbBanner.IsDeleted = false;

            await _context.SaveChangesAsync();

            IEnumerable<Banner> banners = await _context.Banners
                .Where(s => status != null ? s.IsDeleted == status : true)
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)banners.Count() / 2);

            return PartialView("_BannerIndexPartial", banners.Skip((page - 1) * 2).Take(2));
        }
    }
}

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
    public class SliderController : Controller
    {
        private readonly LenosDbContext _context;
        private readonly IWebHostEnvironment _env;


        public SliderController(LenosDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index(bool? status, int page = 1)
        {
            ViewBag.Status = status;

            IEnumerable<Slider> serviceOffers = await _context.Sliders
                .Where(s => status != null ? s.IsDeleted == status : true)
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)serviceOffers.Count() / 5);

            return View(serviceOffers.Skip((page - 1) * 5).Take(5));
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();

            Slider slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);

            if (slider == null) return NotFound();

            return View(slider);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Slider = await _context.Sliders.Where(c => !c.IsDeleted).ToListAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider, bool? status, int page = 1)
        {
            ViewBag.Slider = await _context.Sliders.Where(s => !s.IsDeleted).ToListAsync();

            if (!ModelState.IsValid)
            {
                return View();
            }

            slider.Title = slider.Title.Trim();
            slider.Description = slider.Description.Trim();

            Regex regex = new Regex(@"\s{2,}");
            if (regex.IsMatch(slider.Title) && regex.IsMatch(slider.Description))
            {
                ModelState.AddModelError("Title", "Should not be Space");
                ModelState.AddModelError("Description", "Should not be Space");
                return View();
            }

            if (slider.SliderImage == null)
            {
                ModelState.AddModelError("SliderImage", "Image Must be chosen!");
                return View();
            }
            else
            {
                if (!slider.SliderImage.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("SliderImage", "Image type must be in jpeg adn jpg format!");
                    return View();
                }

                if (!slider.SliderImage.CheckFileSize(1000))
                {
                    ModelState.AddModelError("SliderImage", "Image size must be a maximum of 1000KB!");
                    return View();
                }
                slider.Image = slider.SliderImage.CreateFile(_env, "assets", "img", "slider");
            }

            slider.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status = status, page = page });
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();

            Slider slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);

            if (slider == null) return NotFound();

            ViewBag.Slider = await _context.Sliders.Where(s => s.Id != id && !s.IsDeleted).ToListAsync();

            return View(slider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Slider slider, bool? status, int page = 1)
        {
            ViewBag.Slider = await _context.Sliders.Where(s => s.Id != id && !s.IsDeleted).ToListAsync();

            Slider dbSlider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);

            if (dbSlider == null) return NotFound();

            if (!ModelState.IsValid)
            {
                return View(dbSlider);
            }

            if (id != dbSlider.Id) return BadRequest();

            slider.Title = slider.Title.Trim();
            slider.Description = slider.Description.Trim();

            Regex regex = new Regex(@"\s{2,}");
            if (regex.IsMatch(slider.Title) && regex.IsMatch(slider.Description))
            {
                ModelState.AddModelError("Title", "Should not be Space");
                ModelState.AddModelError("Description", "Should not be Space");
                return View();
            }

            if (slider.SliderImage != null)
            {
                if (!slider.SliderImage.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("SliderImage", "Image type must be in jpeg and jpg format!");
                    return View();
                }

                if (!slider.SliderImage.CheckFileSize(1000))
                {
                    ModelState.AddModelError("SliderImage", "Image size must be a maximum of 1000KB!");
                    return View();
                }

                Helper.DeleteFile(_env, dbSlider.Image, "assets", "img", "slider");

                dbSlider.Image = dbSlider.SliderImage.CreateFile(_env, "assets", "img", "slider");
            }

            dbSlider.Title = slider.Title;
            dbSlider.Description = slider.Description;

            dbSlider.UpdatedAt = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status = status, page = page });
        }

        public async Task<IActionResult> Delete(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Slider dbSlider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);

            if (dbSlider == null) return NotFound();

            dbSlider.IsDeleted = true;
            dbSlider.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();


            IEnumerable<Slider> sliders = await _context.Sliders
                .Where(s => status != null ? s.IsDeleted == status : true)
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)sliders.Count() / 5);

            return PartialView("_SliderIndexPartial", sliders.Skip((page - 1) * 5).Take(5));
        }

        public async Task<IActionResult> Restore(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Slider dbSlider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);

            if (dbSlider == null) return NotFound();

            dbSlider.IsDeleted = false;

            await _context.SaveChangesAsync();

            IEnumerable<Slider> sliders = await _context.Sliders
                .Where(s => status != null ? s.IsDeleted == status : true)
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)sliders.Count() / 5);

            return PartialView("_SliderIndexPartial", sliders.Skip((page - 1) * 5).Take(5));
        }
    }
}

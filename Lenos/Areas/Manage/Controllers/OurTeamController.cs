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
    public class OurTeamController : Controller
    {
        private readonly LenosDbContext _context;
        private readonly IWebHostEnvironment _env;


        public OurTeamController(LenosDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index(bool? status, int page = 1)
        {
            ViewBag.Status = status;

            IEnumerable<OurTeam> ourTeams = await _context.OurTeams
                .Where(s => status != null ? s.IsDeleted == status : true)
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)ourTeams.Count() / 3);

            return View(ourTeams.Skip((page - 1) * 3).Take(3));
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.OurTeam = await _context.OurTeams.Where(c => !c.IsDeleted).ToListAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OurTeam ourTeam, bool? status, int page = 1)
        {
            ViewBag.OurTeam = await _context.OurTeams.Where(s => !s.IsDeleted).ToListAsync();

            if (!ModelState.IsValid)
            {
                return View();
            }

            ourTeam.FullName = ourTeam.FullName.Trim();
            ourTeam.Position = ourTeam.Position.Trim();

            Regex regex = new Regex(@"\s{2,}");
            if (regex.IsMatch(ourTeam.FullName) && regex.IsMatch(ourTeam.Position))
            {
                ModelState.AddModelError("FullName", "Should not be Space");
                ModelState.AddModelError("Position", "Should not be Space");
                return View();
            }

            if (ourTeam.OurTeamImage == null)
            {
                ModelState.AddModelError("OurTeamImage", "Image Must be chosen!");
                return View();
            }
            else
            {
                if (!ourTeam.OurTeamImage.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("OurTeamImage", "Image type must be in jpeg adn jpg format!");
                    return View();
                }

                if (!ourTeam.OurTeamImage.CheckFileSize(1000))
                {
                    ModelState.AddModelError("OurTeamImage", "Image size must be a maximum of 1000KB!");
                    return View();
                }
                ourTeam.Image = ourTeam.OurTeamImage.CreateFile(_env, "assets", "img", "about");
            }

            ourTeam.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.OurTeams.AddAsync(ourTeam);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status = status, page = page });
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();

            OurTeam ourTeam = await _context.OurTeams.FirstOrDefaultAsync(s => s.Id == id);

            if (ourTeam == null) return NotFound();

            ViewBag.OurTeam = await _context.OurTeams.Where(s => s.Id != id && !s.IsDeleted).ToListAsync();

            return View(ourTeam);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, OurTeam ourTeam, bool? status, int page = 1)
        {
            ViewBag.OurTeam = await _context.OurTeams.Where(s => s.Id != id && !s.IsDeleted).ToListAsync();

            OurTeam dbOurTeam = await _context.OurTeams.FirstOrDefaultAsync(s => s.Id == id);

            if (dbOurTeam == null) return NotFound();

            if (!ModelState.IsValid)
            {
                return View(dbOurTeam);
            }

            if (id != dbOurTeam.Id) return BadRequest();

            ourTeam.FullName = ourTeam.FullName.Trim();
            ourTeam.Position = ourTeam.Position.Trim();

            Regex regex = new Regex(@"\s{2,}");
            if (regex.IsMatch(ourTeam.FullName) && regex.IsMatch(ourTeam.Position))
            {
                ModelState.AddModelError("FullName", "Should not be Space");
                ModelState.AddModelError("Position", "Should not be Space");
                return View();
            }

            if (ourTeam.OurTeamImage != null)
            {
                if (!ourTeam.OurTeamImage.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("OurTeamImage", "Image type must be in jpeg and jpg format!");
                    return View();
                }

                if (!ourTeam.OurTeamImage.CheckFileSize(1000))
                {
                    ModelState.AddModelError("OurTeamImage", "Image size must be a maximum of 1000KB!");
                    return View();
                }

                Helper.DeleteFile(_env, dbOurTeam.Image, "assets", "img", "about");

                dbOurTeam.Image = dbOurTeam.OurTeamImage.CreateFile(_env, "assets", "img", "about");
            }

            dbOurTeam.FullName = ourTeam.FullName;
            dbOurTeam.Position = ourTeam.Position;

            dbOurTeam.UpdatedAt = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status = status, page = page });
        }

        public async Task<IActionResult> Delete(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            OurTeam dbOurTeam = await _context.OurTeams.FirstOrDefaultAsync(s => s.Id == id);

            if (dbOurTeam == null) return NotFound();

            dbOurTeam.IsDeleted = true;
            dbOurTeam.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();


            IEnumerable<OurTeam> ourTeams = await _context.OurTeams
                .Where(s => status != null ? s.IsDeleted == status : true)
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)ourTeams.Count() / 3);

            return PartialView("_OurTeamIndexPartial", ourTeams.Skip((page - 1) * 3).Take(3));
        }

        public async Task<IActionResult> Restore(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            OurTeam dbOurTeam = await _context.OurTeams.FirstOrDefaultAsync(s => s.Id == id);

            if (dbOurTeam == null) return NotFound();

            dbOurTeam.IsDeleted = false;

            await _context.SaveChangesAsync();

            IEnumerable<OurTeam> ourTeams = await _context.OurTeams
                .Where(s => status != null ? s.IsDeleted == status : true)
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)ourTeams.Count() / 3);

            return PartialView("_OurTeamIndexPartial", ourTeams.Skip((page - 1) * 3).Take(3));
        }
    }
}

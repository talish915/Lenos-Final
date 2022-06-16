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
    public class SettingController : Controller
    {
        private readonly LenosDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SettingController(LenosDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Settings.FirstOrDefaultAsync());
        }
        public async Task<IActionResult> Update()
        {
            return View(await _context.Settings.FirstOrDefaultAsync());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Setting setting)
        {
            Setting dbSetting = await _context.Settings.FirstOrDefaultAsync();

            setting.Logo = dbSetting.Logo;

            setting.Address = setting.Address.Trim();
            setting.Offer = setting.Offer.Trim();

            Regex regex = new Regex(@"\s{2,}");
            if (regex.IsMatch(setting.Address) && regex.IsMatch(setting.Offer))
            {
                ModelState.AddModelError("Name", "Should not be Space");
                ModelState.AddModelError("Description", "Should not be Space");
                return View();
            }

            for (int i = 0; i < setting.Email.Length; i++)
            {
                if (setting.Email[i] == ' ')
                {
                    ModelState.AddModelError("Link", "Should not be Space");
                    return View(dbSetting);
                }
            }

            if (!ModelState.IsValid)
            {
                return View(setting);
            }

            if (setting.LogoImage != null)
            {
                if (!setting.LogoImage.CheckFileContentType("image/png"))
                {
                    ModelState.AddModelError("LogoImage", "Secilen Seklin Novu Uygun");
                    return View();
                }

                if (!setting.LogoImage.CheckFileSize(30))
                {
                    ModelState.AddModelError("LogoImage", "Secilen Seklin Olcusu Maksimum 30 Kb Ola Biler");
                    return View();
                }

                Helper.DeleteFile(_env, dbSetting.Logo, "assets", "img", "logo");

                dbSetting.Logo = setting.LogoImage.CreateFile(_env, "assets", "img", "logo");
            }

            dbSetting.Offer = setting.Offer;
            dbSetting.Phone = setting.Phone;
            dbSetting.Email = setting.Email;
            dbSetting.Address = setting.Address;
            dbSetting.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }
    }
}

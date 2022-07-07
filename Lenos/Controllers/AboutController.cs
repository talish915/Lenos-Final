using Lenos.DAL;
using Lenos.ViewModels.About;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lenos.Controllers
{
    public class AboutController : Controller
    {
        private readonly LenosDbContext _context;
        public AboutController(LenosDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            AboutVM aboutVM = new AboutVM
            {
                ProductPromos = await _context.ProductPromos.Where(c => !c.IsDeleted).ToListAsync(),
                OurTeams = await _context.OurTeams.Where(c => !c.IsDeleted).ToListAsync()

            };
            return View(aboutVM);
        }
    }
}

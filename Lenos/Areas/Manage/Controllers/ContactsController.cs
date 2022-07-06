using Lenos.DAL;
using Lenos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lenos.Areas.Manage.Controllers
{
    [Area("manage")]
    public class ContactsController : Controller
    {
        private readonly LenosDbContext _context;


        public ContactsController(LenosDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int page = 1)
        {

            IEnumerable<Contact> contacts = await _context.Contacts
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)contacts.Count() / 2);

            return View(contacts.Skip((page - 1) * 2).Take(2));
        }
    }
}

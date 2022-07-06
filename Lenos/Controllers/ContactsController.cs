using Lenos.DAL;
using Lenos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lenos.Controllers
{
    public class ContactsController : Controller
    {
        private readonly LenosDbContext _context;


        public ContactsController(LenosDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            contact.FullName = contact.FullName.Trim();
            contact.Phone = contact.Phone.Trim();
            contact.Message = contact.Message.Trim();

            Regex regex = new Regex(@"\s{2,}");
            if (regex.IsMatch(contact.FullName) && regex.IsMatch(contact.Phone) && regex.IsMatch(contact.Message))
            {
                ModelState.AddModelError("FullName", "Should not be Space");
                ModelState.AddModelError("Phone", "Should not be Space");
                ModelState.AddModelError("Message", "Should not be Space");
                return View();
            }
            contact.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }
    }
}

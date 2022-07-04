using Lenos.DAL;
using Lenos.Enums;
using Lenos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lenos.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class OrderController : Controller
    {
        private readonly LenosDbContext _context;

        public OrderController(LenosDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int page = 1)
        {

            IEnumerable<Order> orders = await _context.Orders
                .Include(o => o.AppUser)
                .Include(o => o.OrderItems)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)orders.Count() / 5);

            return View(orders.Skip((page - 1) * 5).Take(5));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();

            Order order = await _context.Orders
                .Include(o => o.AppUser)
                .Include(o => o.OrderItems).ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == id && !o.IsDeleted);

            if (order == null) return NotFound();

            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, int orderStatus)
        {
            if (id == null) return BadRequest();

            Order order = await _context.Orders
                .Include(o => o.AppUser)
                .Include(o => o.OrderItems).ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == id && !o.IsDeleted);

            if (order == null) return NotFound();

            if (order.Status != OrderStatus.Accepted && orderStatus == 1)
            {
                foreach (var item in order.OrderItems)
                {
                    item.Product.Count -= item.Count;
                }
            }

            order.Status = (OrderStatus)orderStatus;
            order.UpdatedAt = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }
    }
}

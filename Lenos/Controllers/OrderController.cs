﻿using Lenos.DAL;
using Lenos.Models;
using Lenos.ViewModels.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lenos.Controllers
{
    [Authorize(Roles = "Member")]
    public class OrderController : Controller
    {
        private readonly LenosDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public OrderController(LenosDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Create()
        {
            AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name && !u.IsAdmin);

            if (appUser == null)
            {
                return RedirectToAction("login", "Account");
            }

            double total = 0;
            List<Basket> baskets = await _context.Baskets.Include(b => b.Product).Where(b => b.AppUserId == appUser.Id).ToListAsync();

            foreach (Basket item in baskets)
            {
                total = total + (item.Count * (item.Product.DiscountPrice > 0 ? item.Product.DiscountPrice : item.Product.Price));
            }

            ViewBag.Total = total;

            OrderVM orderVM = new OrderVM
            {
                FullName = appUser.FullName,
                Email = appUser.Email,
                Address = appUser.Address,
                City = appUser.City,
                Country = appUser.Country,
                State = appUser.State,
                ZipCode = appUser.ZipCode
            };

            return View(orderVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderVM orderVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name && !u.IsAdmin);

            if (appUser == null)
            {
                return RedirectToAction("login", "Account");
            }

            List<Basket> baskets = await _context.Baskets.Include(b => b.Product).Where(b => b.AppUserId == appUser.Id).ToListAsync();

            if (baskets.Count == 0) return RedirectToAction("index", "shop");

            List<OrderItem> orderItems = new List<OrderItem>();
            double total = 0;

            foreach (Basket item in baskets)
            {
                total = total + (item.Count * (item.Product.DiscountPrice > 0 ? item.Product.DiscountPrice : item.Product.Price));

                OrderItem orderItem = new OrderItem
                {
                    Count = item.Count,
                    Price = (item.Product.DiscountPrice > 0 ? item.Product.DiscountPrice : item.Product.Price),
                    ProductId = item.ProductId,
                    TotalPrice = (item.Count * (item.Product.DiscountPrice > 0 ? item.Product.DiscountPrice : item.Product.Price)),
                    CreatedAt = DateTime.UtcNow.AddHours(4)
                };
                orderItems.Add(orderItem);
            }

            Order order = new Order
            {
                Address = orderVM.Address,
                AppUserId = appUser.Id,
                City = orderVM.City,
                Country = orderVM.Country,
                State = orderVM.State,
                TotalPrice = total,
                CreatedAt = DateTime.UtcNow.AddHours(4),
                ZipCode = orderVM.ZipCode,
                OrderItems = orderItems
            };

            _context.Baskets.RemoveRange(baskets);
            HttpContext.Response.Cookies.Delete("basket");
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return RedirectToAction("index", "home");
        }
    }
}

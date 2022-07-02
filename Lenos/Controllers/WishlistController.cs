using Lenos.DAL;
using Lenos.Models;
using Lenos.ViewModels.Wishlist;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lenos.Controllers
{
    public class WishlistController : Controller
    {
        private readonly LenosDbContext _context;

        public WishlistController(LenosDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            string cookie = HttpContext.Request.Cookies["wishlist"];

            List<WishlistVM> wishlistVMs = null;

            if (cookie != null)
            {
                wishlistVMs = JsonConvert.DeserializeObject<List<WishlistVM>>(cookie);
            }
            else
            {
                wishlistVMs = new List<WishlistVM>();
            }
            foreach (WishlistVM wishlistVM in wishlistVMs)
            {
                Product dbProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == wishlistVM.ProductId);
                wishlistVM.Image = dbProduct.MainImage;
                wishlistVM.Price = dbProduct.Price;
                wishlistVM.DiscountPrice = dbProduct.DiscountPrice;
                wishlistVM.Title = dbProduct.Title;
                wishlistVM.Availability = dbProduct.Availability;
            }
            return View(wishlistVMs);
        }
        public async Task<IActionResult> AddOrDeleteWishlist(int? id)
        {
            if (id == null) return BadRequest();
            Product dBproduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
            if (dBproduct == null) return NotFound();

            //List<Product> products = null;
            List<WishlistVM> wishlistVMs = null;

            string cookie = HttpContext.Request.Cookies["wishlist"];

            if (cookie != null)
            {
                wishlistVMs = JsonConvert.DeserializeObject<List<WishlistVM>>(cookie);

                WishlistVM wishlistVM = wishlistVMs.FirstOrDefault(b => b.ProductId == id);

                if (wishlistVMs.Any(b => b.ProductId == id))
                {
                    wishlistVMs.Remove(wishlistVM);
                }
                else
                {
                    wishlistVMs.Add(new WishlistVM
                    {
                        ProductId = (int)id,
                        AddDate = DateTime.UtcNow.AddHours(4)
                    });
                }
            }
            else
            {
                wishlistVMs = new List<WishlistVM>();

                wishlistVMs.Add(new WishlistVM()
                {
                    ProductId = (int)id,
                    AddDate = DateTime.UtcNow.AddHours(4)
                });;
            }


            HttpContext.Response.Cookies.Append("wishlist", JsonConvert.SerializeObject(wishlistVMs));

            foreach (WishlistVM basketVM in wishlistVMs)
            {
                Product dbProduct = await _context.Products
                    .FirstOrDefaultAsync(p => p.Id == basketVM.ProductId);
                basketVM.Image = dbProduct.MainImage;
                basketVM.Price = dbProduct.Price;
                basketVM.DiscountPrice = dbProduct.DiscountPrice;
                basketVM.Title = dbProduct.Title;
                basketVM.Availability = dbProduct.Availability;
            }
            return PartialView("_WishlistIndexPartial",wishlistVMs);
        }
        public object GetWishlistCount()
        {
            string cookieWishlist = HttpContext.Request.Cookies["wishlist"];

            List<WishlistVM> wishlistVMs = null;

            if (cookieWishlist != null)
            {
                wishlistVMs = JsonConvert.DeserializeObject<List<WishlistVM>>(cookieWishlist);
            }
            else
            {
                wishlistVMs = new List<WishlistVM>();
            }
            return new
            {
                wishlistcount = wishlistVMs.Count()
            };
        }

    }
}

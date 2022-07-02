using Lenos.DAL;
using Lenos.Models;
using Lenos.ViewModels.Basket;
using Lenos.ViewModels.Wishlist;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lenos.Services
{
    public class LayoutService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly LenosDbContext _context;

        public LayoutService(IHttpContextAccessor httpContextAccessor, LenosDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public async Task<List<BasketVM>> GetBasket()
        {
            string cookieBasket = _httpContextAccessor.HttpContext.Request.Cookies["basket"];
            List<BasketVM> basketVMs = null;

            if (!string.IsNullOrWhiteSpace(cookieBasket))
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(cookieBasket);
            }
            else
            {
                basketVMs = new List<BasketVM>();
            }
            foreach (BasketVM basketVM in basketVMs)
            {
                Product dbProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == basketVM.ProductId);
                basketVM.Image = dbProduct.MainImage;
                basketVM.Price = dbProduct.DiscountPrice > 0 ? dbProduct.DiscountPrice : dbProduct.Price;
                basketVM.Title = dbProduct.Title;
            }
            return basketVMs;
        }

        public async Task<Setting> GetSetting()
        {
            return await _context.Settings.FirstOrDefaultAsync();
        }

        public async Task<List<Social>> GetSocial()
        {
            return await _context.Socials.Where(s => !s.IsDeleted).ToListAsync();
        }
        public async Task<List<WishlistVM>> GetWishlist()
        {
            string cookieBasket = _httpContextAccessor.HttpContext.Request.Cookies["wishlist"];
            List<WishlistVM> wishlistVMs = null;

            if (!string.IsNullOrWhiteSpace(cookieBasket))
            {
                wishlistVMs = JsonConvert.DeserializeObject<List<WishlistVM>>(cookieBasket);
            }
            else
            {
                wishlistVMs = new List<WishlistVM>();
            }
            foreach (WishlistVM wishlistVM in wishlistVMs)
            {
                Product dbProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == wishlistVM.ProductId);
                wishlistVM.Image = dbProduct.MainImage;
                wishlistVM.Price = dbProduct.DiscountPrice > 0 ? dbProduct.DiscountPrice : dbProduct.Price;
                wishlistVM.Title = dbProduct.Title;
            }
            return wishlistVMs;
        }

    }
}

﻿using Lenos.DAL;
using Lenos.Extensions;
using Lenos.Helpers;
using Lenos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
    public class ProductController : Controller
    {
        private readonly LenosDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(LenosDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index(bool? status, int page = 1)
        {
            ViewBag.Status = status;

            IEnumerable<Product> products = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.ProductTags)
                .Where(p => status != null ? p.IsDeleted == status : true)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)products.Count() / 5);

            return View(products.Skip((page - 1) * 5).Take(5));
        }

        public async Task<IActionResult> Create(bool? status, int page = 1)
        {
            ViewBag.Categories = await _context.Categories.Where(b => !b.IsDeleted).ToListAsync();
            ViewBag.Tags = await _context.Tags.Where(t => !t.IsDeleted).ToListAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, bool? status, int page = 1)
        {
            ViewBag.Categories = await _context.Categories.Where(b => !b.IsDeleted).ToListAsync();
            ViewBag.Tags = await _context.Tags.Where(t => !t.IsDeleted).ToListAsync();

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (product.ProductImagesFile.Count() > 6)
            {
                ModelState.AddModelError("ProductImagesFile", $"maksimum yukleyebileceyin say 6");
                return View();
            }

            if (!await _context.Categories.AnyAsync(b => b.Id == product.CategoryId && !b.IsDeleted))
            {
                ModelState.AddModelError("CategoryId", "Duzgun Category Secin ");
                return View();
            }

            if (product.TagIds.Count > 0)
            {
                List<ProductTag> productTags = new List<ProductTag>();

                foreach (int item in product.TagIds)
                {
                    if (!await _context.Tags.AnyAsync(t => t.Id != item && !t.IsDeleted))
                    {
                        ModelState.AddModelError("TagIds", $"Secilen Id {item} - li Tag Yanlisdir");
                        return View();
                    }

                    ProductTag productTag = new ProductTag
                    {
                        TagId = item
                    };

                    productTags.Add(productTag);
                }

                product.ProductTags = productTags;
            }

            if (product.MainImageFile != null)
            {
                if (!product.MainImageFile.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("MainImageFile", "Secilen Seklin Novu Uygun");
                    return View();
                }

                if (!product.MainImageFile.CheckFileSize(300))
                {
                    ModelState.AddModelError("MainImageFile", "Secilen Seklin Olcusu Maksimum 30 Kb Ola Biler");
                    return View();
                }

                product.MainImage = product.MainImageFile.CreateFile(_env, "assets", "img", "product");
            }
            else
            {
                ModelState.AddModelError("MainImageFile", "Main Sekil Mutleq Secilmelidir");
                return View();
            }

            if (product.HoverImageFile != null)
            {
                if (!product.HoverImageFile.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("HoverImageFile", "Secilen Seklin Novu Uygun");
                    return View();
                }

                if (!product.HoverImageFile.CheckFileSize(300))
                {
                    ModelState.AddModelError("HoverImageFile", "Secilen Seklin Olcusu Maksimum 30 Kb Ola Biler");
                    return View();
                }

                product.HoverImage = product.HoverImageFile.CreateFile(_env, "assets", "img", "product");
            }
            else
            {
                ModelState.AddModelError("HoverImageFile", "Hover Sekil Mutleq Secilmelidir");
                return View();
            }

            if (product.ProductImagesFile.Count() > 0)
            {
                List<ProductImage> productImages = new List<ProductImage>();

                foreach (IFormFile file in product.ProductImagesFile)
                {
                    if (!file.CheckFileContentType("image/jpeg"))
                    {
                        ModelState.AddModelError("ProductImagesFile", "Secilen Seklin Novu Uygun");
                        return View();
                    }

                    if (!file.CheckFileSize(300))
                    {
                        ModelState.AddModelError("ProductImagesFile", "Secilen Seklin Olcusu Maksimum 30 Kb Ola Biler");
                        return View();
                    }

                    ProductImage productImage = new ProductImage
                    {
                        Image = file.CreateFile(_env, "assets", "img", "product"),
                        CreatedAt = DateTime.UtcNow.AddHours(4)
                    };

                    productImages.Add(productImage);
                }

                product.ProductImages = productImages;
            }
            else
            {
                ModelState.AddModelError("ProductImagesFile", "Product Images File Sekil Mutleq Secilmelidir");
                return View();
            }
            
            product.Availability = product.Count > 0 ? true : false;
            product.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status, page });
        }

        public async Task<IActionResult> Update(int? id, bool? status, int page = 1)
        {
            ViewBag.Categories = await _context.Categories.Where(b => !b.IsDeleted).ToListAsync();
            ViewBag.Tags = await _context.Tags.Where(t => !t.IsDeleted).ToListAsync();

            if (id == null) return BadRequest();

            Product product = await _context.Products.Include(p => p.ProductTags).ThenInclude(pt => pt.Tag).Include(p => p.ProductImages).FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (product == null) return NotFound();

            product.TagIds = product.ProductTags.Select(pt => pt.Tag.Id).ToList();

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Product product, bool? status, int page = 1)
        {
            ViewBag.Categories = await _context.Categories.Where(b => !b.IsDeleted).ToListAsync();
            ViewBag.Tags = await _context.Tags.Where(t => !t.IsDeleted).ToListAsync();

            if (id == null) return BadRequest();

            if (id != product.Id) return BadRequest();

            Product dbProduct = await _context.Products
                .Include(p => p.ProductTags)
                .ThenInclude(pt => pt.Tag)
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (dbProduct == null) return NotFound();

            if (!ModelState.IsValid) return View(dbProduct);

            int canuploadimage = 6 - (int)(dbProduct.ProductImages?.Where(p => !p.IsDeleted).Count());

            if (product.ProductImagesFile != null && product.ProductImagesFile.Length > canuploadimage)
            {
                ModelState.AddModelError("ProductImagesFile", $"maksimum yukleyebileceyin say {canuploadimage}");
                return View(dbProduct);
            }

            if (!await _context.Categories.AnyAsync(b => b.Id == product.CategoryId && !b.IsDeleted))
            {
                ModelState.AddModelError("CategoryId", "Duzgun Category Secin ");
                return View(product);
            }

            if (product.TagIds.Count > 0)
            {
                _context.ProductTags.RemoveRange(dbProduct.ProductTags);

                List<ProductTag> productTags = new List<ProductTag>();

                foreach (int item in product.TagIds)
                {
                    if (!await _context.Tags.AnyAsync(t => t.Id != item && !t.IsDeleted))
                    {
                        ModelState.AddModelError("TagIds", $"Secilen Id {item} - li Tag Yanlisdir");
                        return View(product);
                    }

                    ProductTag productTag = new ProductTag
                    {
                        TagId = item
                    };

                    productTags.Add(productTag);
                }

                dbProduct.ProductTags = productTags;
            }
            else
            {
                _context.ProductTags.RemoveRange(dbProduct.ProductTags);
            }

            if (product.MainImageFile != null)
            {
                if (!product.MainImageFile.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("MainImageFile", "Secilen Seklin Novu Uygun");
                    return View();
                }

                if (!product.MainImageFile.CheckFileSize(300))
                {
                    ModelState.AddModelError("MainImageFile", "Secilen Seklin Olcusu Maksimum 300 Kb Ola Biler");
                    return View();
                }
                Helper.DeleteFile(_env, dbProduct.MainImage, "assets", "img", "product");

                dbProduct.MainImage = product.MainImageFile.CreateFile(_env, "assets", "img", "product");
            }

            if (product.HoverImageFile != null)
            {
                if (!product.HoverImageFile.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("HoverImageFile", "Secilen Seklin Novu Uygun");
                    return View();
                }

                if (!product.HoverImageFile.CheckFileSize(300))
                {
                    ModelState.AddModelError("HoverImageFile", "Secilen Seklin Olcusu Maksimum 300 Kb Ola Biler");
                    return View();
                }
                Helper.DeleteFile(_env, dbProduct.HoverImage, "assets", "img", "product");

                dbProduct.HoverImage = product.HoverImageFile.CreateFile(_env, "assets", "img", "product");
            }

            if (product.ProductImagesFile != null && product.ProductImagesFile.Count() > 0)
            {
                List<ProductImage> productImages = new List<ProductImage>();

                foreach (IFormFile file in product.ProductImagesFile)
                {
                    if (!file.CheckFileContentType("image/jpeg"))
                    {
                        ModelState.AddModelError("ProductImagesFile", "Secilen Seklin Novu Uygun");
                        return View();
                    }

                    if (!file.CheckFileSize(300))
                    {
                        ModelState.AddModelError("ProductImagesFile", "Secilen Seklin Olcusu Maksimum 30 Kb Ola Biler");
                        return View();
                    }

                    ProductImage productImage = new ProductImage
                    {
                        Image = file.CreateFile(_env, "assets", "img", "product"),
                        CreatedAt = DateTime.UtcNow.AddHours(4)
                    };

                    dbProduct.ProductImages.Add(productImage);
                }
            }
            dbProduct.CategoryId = product.CategoryId;
            dbProduct.Title = product.Title;
            dbProduct.Price = product.Price;
            dbProduct.DiscountPrice = product.DiscountPrice;
            dbProduct.IsFeatured = product.IsFeatured;
            dbProduct.Description = product.Description;
            dbProduct.Count = product.Count;
            dbProduct.Availability = product.Count > 0 ? true : false;
            dbProduct.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status, page });
        }

        public async Task<IActionResult> DeleteImage(int? id)
        {
            ViewBag.Categories = await _context.Categories.Where(b => !b.IsDeleted).ToListAsync();
            ViewBag.Tags = await _context.Tags.Where(t => !t.IsDeleted).ToListAsync();

            if (id == null) return BadRequest();

            Product product = await _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.ProductTags).ThenInclude(pt => pt.Tag)
                .FirstOrDefaultAsync(p => p.ProductImages.Any(pi => pi.Id == id && !pi.IsDeleted));

            if (product == null) return NotFound();

            product.ProductImages.FirstOrDefault(p => p.Id == id).IsDeleted = true;
            product.ProductImages.FirstOrDefault(p => p.Id == id).DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            product.TagIds = product.ProductTags.Select(pt => pt.Tag.Id).ToList();

            return PartialView("_ProductUpdateImagePartial", product);
        }

        public async Task<IActionResult> DeleteAndDetail(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Product product = await _context.Products
                .Include(p => p.ProductTags).ThenInclude(pt => pt.Tag)
                .Include(p => p.ProductImages)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (product == null) return NotFound();

            return View(product);
        }
        public async Task<IActionResult> DeleteProduct(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Product product = await _context.Products
                .Include(p => p.ProductTags).ThenInclude(pt => pt.Tag)
                .Include(p => p.ProductImages)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (product == null) return NotFound();

            product.IsDeleted = true;
            product.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status, page });
        }
    }
}

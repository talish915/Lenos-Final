using Lenos.DAL;
using Lenos.Models;
using Lenos.ViewModels.Account;
using Lenos.ViewModels.Basket;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Lenos.Controllers
{
    public class AccountController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly LenosDbContext _context;

        public AccountController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, LenosDbContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View();

            AppUser appUser = await _userManager.FindByNameAsync(registerVM.UserName);
            if (appUser == null)
            {
                appUser = new AppUser
                {
                    FullName = registerVM.FullName,
                    Email = registerVM.Email,
                    UserName = registerVM.UserName,
                    IsAdmin = false
                };
                if (registerVM.UserName == null)
                {
                    ModelState.AddModelError("Username", "Please fill this field");
                    return View();

                }
                IdentityResult result = await _userManager.CreateAsync(appUser, registerVM.Password);
                if (!result.Succeeded)
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View();
                }

            }
            else
            {
                ModelState.AddModelError("", "This username already taken");
                return View();
            }
            await _userManager.AddToRoleAsync(appUser, "Member");

            string token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
            string link = Url.Action(nameof(VerifyEmail), "Account", new { email = appUser.Email, token }, Request.Scheme, Request.Host.ToString());
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("lenosfinal042@gmail.com", "Lenos");
            mail.To.Add(new MailAddress(appUser.Email));
            mail.Subject = "Email Verification";
            string body = string.Empty;
            using (StreamReader reader = new StreamReader("wwwroot/assets/template/VerifyEmail.html"))
            {
                body = reader.ReadToEnd();
            }

            mail.Body = body.Replace("{link}", link);
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            smtp.Credentials = new NetworkCredential("lenosfinal042@gmail.com", "sforrdqjpqqvlufv");
            smtp.Send(mail);
            TempData["Verify"] = true;
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> VerifyEmail(string email, string token)
        {
            AppUser user = await _userManager.FindByEmailAsync(email);

            if (user == null) return BadRequest();
            _context.SaveChanges();

            await _userManager.ConfirmEmailAsync(user, token);
            await _signInManager.SignInAsync(user, true);
            TempData["Verified"] = true;

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View();

            AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedEmail == loginVM.Email.ToUpperInvariant() && !u.IsAdmin);

            if (appUser == null)
            {
                ModelState.AddModelError("", "Email Or Password Is InCorrect");
                return View();
            }
            Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(appUser, loginVM.Password, loginVM.RememberMe, true);

            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Email Or Password Is InCorrect");
                return View();
            }

            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelError("", "Hesabiniz Blocklanib");
                return View();
            }

            string coockieBasket = HttpContext.Request.Cookies["basket"];

            if (!string.IsNullOrWhiteSpace(coockieBasket))
            {
                List<BasketVM> basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(coockieBasket);

                List<Basket> baskets = new List<Basket>();
                List<Basket> existedBasket = await _context.Baskets.Where(b => b.AppUserId == appUser.Id).ToListAsync();
                foreach (BasketVM basketVM in basketVMs)
                {
                    if (existedBasket.Any(b => b.ProductId == basketVM.ProductId))
                    {
                        existedBasket.Find(b => b.ProductId == basketVM.ProductId).Count = basketVM.Count;
                    }
                    else
                    {
                        Basket basket = new Basket
                        {
                            AppUserId = appUser.Id,
                            ProductId = basketVM.ProductId,
                            Count = basketVM.Count,
                            CreatedAt = DateTime.UtcNow.AddHours(4)
                        };

                        baskets.Add(basket);
                    }


                }

                if (baskets.Count > 0)
                {
                    await _context.Baskets.AddRangeAsync(baskets);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToAction("index", "home");
        }
  
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("login","account");
        }

        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Profile()
        {
            AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name && !u.IsAdmin);

            if (appUser == null) return RedirectToAction("index", "home");

            MemberProfileVM memberProfileVM = new MemberProfileVM
            {
                Member = new MemberUpdateVM
                {
                    Address = appUser.Address,
                    City = appUser.City,
                    Country = appUser.Country,
                    FullName = appUser.FullName,
                    PhoneNumber = appUser.PhoneNumber,
                    State = appUser.State,
                    UserName = appUser.UserName,
                    ZipCode = appUser.ZipCode,
                    Email = appUser.Email
                },
                Orders = await _context.Orders
                .Include(o => o.OrderItems).ThenInclude(oi => oi.Product)
                .Include(o => o.AppUser)
                .Where(o => !o.IsDeleted && o.AppUserId == appUser.Id).ToListAsync()

            };

            return View(memberProfileVM);
        }

        [Authorize(Roles = "Member")]
        [HttpPost]
        public async Task<IActionResult> Edit(MemberUpdateVM member)
        {
            AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name && !u.IsAdmin);

            if (appUser == null) return RedirectToAction("index", "home");
            MemberProfileVM memberProfileVM = new MemberProfileVM
            {
                Member = member
            };
            TempData["ProfileTab"] = "Account";

            if (!ModelState.IsValid)
            {
                return View("Profile", memberProfileVM);
            }

            if (appUser.NormalizedUserName != member.UserName.ToUpper() && await _userManager.Users.AnyAsync(u => u.NormalizedUserName == member.UserName.ToUpper()))
            {
                ModelState.AddModelError("UserName", "UserName Alreade Exist");

                return View("Profile", memberProfileVM);
            }

            if (appUser.NormalizedEmail != member.Email.ToUpper() && await _userManager.Users.AnyAsync(u => u.NormalizedEmail == member.Email.ToUpper()))
            {
                ModelState.AddModelError("Email", "Email Alreade Exist");
                return View("Profile", memberProfileVM);
            }

            appUser.FullName = member.FullName;
            appUser.UserName = member.UserName;
            appUser.Email = member.Email;
            appUser.Address = member.Address;
            appUser.Country = member.Country;
            appUser.City = member.City;
            appUser.State = member.State;
            appUser.ZipCode = member.ZipCode;
            appUser.PhoneNumber = member.PhoneNumber;

            IdentityResult identityResult = await _userManager.UpdateAsync(appUser);

            if (!identityResult.Succeeded)
            {
                foreach (var item in identityResult.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View("Profile", memberProfileVM);
            }

            if (member.Password != null)
            {
                if (string.IsNullOrWhiteSpace(member.CurrentPassword))
                {
                    ModelState.AddModelError("CurrentPassword", "CurrentPassword Is Requered");
                    return View("Profile", memberProfileVM);
                }

                if (!await _userManager.CheckPasswordAsync(appUser, member.CurrentPassword))
                {
                    ModelState.AddModelError("CurrentPassword", "CurrentPassword Is InCorrect");
                    return View("Profile", memberProfileVM);
                }

                string token = await _userManager.GeneratePasswordResetTokenAsync(appUser);
                identityResult = await _userManager.ResetPasswordAsync(appUser, token, member.Password);
                if (!identityResult.Succeeded)
                {
                    foreach (var item in identityResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View("Profile", memberProfileVM);
                }
            }

            return RedirectToAction("Profile");
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(AccountVM account)
        {
            AppUser user = await _userManager.FindByEmailAsync(account.AppUser.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "No account exists with this email!");
                return View();
            }

            string token = await _userManager.GeneratePasswordResetTokenAsync(user);
            string link = Url.Action(nameof(ResetPassword), "Account", new { email = user.Email, token }, Request.Scheme, Request.Host.ToString());


            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("lenosfinal042@gmail.com", "Lenos");
            mail.To.Add(new MailAddress(user.Email));

            mail.Subject = "Reset Password";
            mail.Body = $"<a href='{link}'>Reset password</a>";
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            smtp.Credentials = new NetworkCredential("lenosfinal042@gmail.com", "sforrdqjpqqvlufv");
            smtp.Send(mail);
            TempData["Verify"] = true;
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> ResetPassword(string email, string token)
        {


            AppUser user = await _userManager.FindByEmailAsync(email);
            if (user == null) return BadRequest();
            AccountVM model = new AccountVM
            {
                AppUser = user,
                Token = token
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(AccountVM account)
        {

            AppUser user = await _userManager.FindByEmailAsync(account.AppUser.Email);
            AccountVM model = new AccountVM
            {
                AppUser = user,
                Token = account.Token
            };
            if (!ModelState.IsValid) return View(model);
            IdentityResult result = await _userManager.ResetPasswordAsync(user, account.Token, account.Password);
            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
            TempData["Reseted"] = true;

            return RedirectToAction("Index", "Home");
        }

        #region Create Role
        //public async Task<IActionResult> CreateRole()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "SuperAdmin" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Member" });

        //    return Ok();
        //}
        #endregion
    }
}

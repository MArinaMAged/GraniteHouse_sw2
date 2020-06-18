using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using GraniteHouse_sw2.Models;
using GraniteHouse_sw2.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GraniteHouse_sw2.Areas.Identity.Pages.Account
{
    // [Authorize(Roles =SD.SuperAdminEndUser)]
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;




        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            public string Name { get; set; }

            [Required]
            [Display(Name = "Phone Number")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Super Admin")]
            public bool IsSuperAdmin { get; set; }
            [Display(Name = "Admin End User")]
            public bool IsAdminEndUser { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }



        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            await CreateAdmin();
            //returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email, Name = Input.Name, PhoneNumber = Input.PhoneNumber };
                //  var user = new IdentityUser { UserName = Input.Email, Email = Input.Email };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    if (!await _roleManager.RoleExistsAsync(SD.AdminEndUser))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.AdminEndUser));
                    }
                    if (!await _roleManager.RoleExistsAsync(SD.SuperAdminEndUser))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.SuperAdminEndUser));
                    }
                    //--->user Register 
                    if (!await _roleManager.RoleExistsAsync(SD.User))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.User));
                    }


                    if (Input.IsSuperAdmin)
                    {
                        await _userManager.AddToRoleAsync(user, SD.SuperAdminEndUser);
                    }

                    //checkbox lw admin  
                    //if(Input.IsAdminEndUser == null)
                    // {
                    //     await _userManager.AddToRoleAsync(user, SD.User);
                    // }
                    else if (Input.IsAdminEndUser)
                    {
                        await _userManager.AddToRoleAsync(user, SD.AdminEndUser);
                    }
                    //--->user Register
                    else
                    {
                        await _userManager.AddToRoleAsync(user, SD.User);
                    }


                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);



                    //elreturn ya 7gga hena lazm ytzbbt lsa elmfrod lw admin heml di tb a check ezaaaaaaaaaaaaaaaay
                    //if(_logger.)
                    if (User.IsInRole(SD.AdminEndUser))
                    {
                        return RedirectToAction("Index", "AdminUsers", new { area = "Admin" });
                    }
                    else if (User.IsInRole(SD.SuperAdminEndUser))
                    {
                        return RedirectToAction("Index", "AdminUsers", new { area = "Admin" });

                    }
                    else
                    {
                        return RedirectToAction("Index", "Home", new { area = "Customer" });
                    }
                    //  return RedirectToAction(login.ReturnUrl ?? "/");

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }


        private async Task CreateAdmin()
        {
            var admin = await _userManager.FindByNameAsync("Admin");
            if (admin == null)
            {
                var user = new ApplicationUser
                {
                    Email = "Admin@Gmail.com",
                    UserName = "Admin",
                    EmailConfirmed = true
                };

                var x = await _userManager.CreateAsync(user, "12345678aA!");

                if (x.Succeeded)
                {
                    if (await _roleManager.RoleExistsAsync(SD.SuperAdminEndUser))
                    {
                        await _userManager.AddToRoleAsync(user, SD.SuperAdminEndUser);
                    }

                }
            }
            //return Ok("done");
        }
    }
}

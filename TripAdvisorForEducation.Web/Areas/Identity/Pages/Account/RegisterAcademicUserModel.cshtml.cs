using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TripAdvisorForEducation.Data.Models;
using TripAdvisorForEducation.Data.ViewModels;

namespace TripAdvisorForEducation.Web.Areas.Identity.Pages.Account
{
    public class RegisterAcademicUserModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public RegisterAcademicUserModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [BindProperty]
        public AcademicUserViewModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null, string token = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var user = new AcademicsUser
                {
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    UserName = Input.Email,
                    Email = Input.Email,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    var userRole = (UserRoles)Enum.Parse(typeof(UserRoles), Input.Role);

                    await _userManager.AddToRoleAsync(user, userRole.ToString());
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return LocalRedirect(returnUrl);
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}


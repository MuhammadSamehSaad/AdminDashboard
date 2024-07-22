using Demo.DAL.Entites;
using Demo.PL.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Demo.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        #region Sign Up

        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                //add some code to avoid tow accounts with the same name
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user is null)
                {
                    user = new ApplicationUser()
                    {
                        FName = model.FirstName,
                        LName = model.LastName,
                        UserName = model.UserName,
                        Email = model.Email,
                        IsAgree = model.IsAgree

                    };

                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(SignIn));
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            // Log the error description for debugging
                            //System.Diagnostics.Debug.WriteLine($"Error: {error.Description}");
                            ModelState.AddModelError(string.Empty, error.Description);
                        };
                    }
                }
                ModelState.AddModelError(string.Empty, "This User Name Is Already In Use For Anothre Account!");
            }
            return View(model);
        }
        #endregion

        #region SignIn
        public IActionResult SignIn()
        {
            return View();
        }


        //public async Task<IActionResult> SignIn()
        //{
        //    return RedirectToAction(nameof(SignUp));
        //}
        #endregion
    }
}

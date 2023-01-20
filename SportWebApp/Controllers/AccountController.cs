using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportWebApp.Data;
using SportWebApp.Models;
using SportWebApp.ViewModels;

namespace SportWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManger;
        private readonly SignInManager<AppUser> _signInManger;
        private readonly ApplictionDbContext _context;
        public AccountController(UserManager<AppUser> userManger, SignInManager<AppUser> signInManger, ApplictionDbContext context)
        {
            _userManger = userManger;
            _signInManger = signInManger;
            _context = context;
        }

        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var user = await _userManger.FindByEmailAsync(loginVM.EmailAddress);

            if(user != null)
            {
                //User Is Found , Check password
                var passwordCheck = await _userManger.CheckPasswordAsync(user , loginVM.Password);
                if(passwordCheck)
                {
                    //password correct
                    var result = await _signInManger.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if(result.Succeeded)
                    {
                        return RedirectToAction("Index", "Race");
                    }
                }
                //Password is Incorrect
                TempData["Error"] = " Wrong Password  , please , try again";
                return View(loginVM);
            }
            // User Not Found
            TempData["Error"] = "Can't Find User , plase try again";
            return View(loginVM);
        }
    }
}

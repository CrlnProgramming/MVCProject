using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCProjectWeb.Models;
using System.Security.Claims;

namespace MVCProjectWeb.Controllers
{
    [Authorize]
    public class AuthAndAun : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync(Login login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            var claims = new List<Claim>()
            {
                new Claim("Demo","Value")
            };
            var cliemIdentity = new ClaimsIdentity(claims, "Cookie");
            var claimPrincipal = new ClaimsPrincipal(cliemIdentity  );
            await HttpContext.SignInAsync("Cookie", claimPrincipal);
            return Redirect(login.ReturnUrl);
        }


        //Тут на фронте нужно сделать логоф

        public async Task<IActionResult> LogOffAsync()
        {
            await HttpContext.SignOutAsync("Cookie");
            return Redirect("/Home/Index");
        }

        public IActionResult Registration()
        {
            return View();
        }

    }

    
}

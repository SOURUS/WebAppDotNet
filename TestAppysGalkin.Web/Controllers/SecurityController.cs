using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Host.SystemWeb;
using System.Web.Mvc;
using TestAppsysGalkin.Data.Model;
using TestAppsysGalkin.Repository.Interfaces;
using TestAppysGalkin.Web.Models.Authorize;
using TestAppysGalkin.Web.Models.Shared;
using TestAppysGalkin.Web.ViewModels.Security;
using System.Net;
using System.Web;

namespace TestAppysGalkin.Web.Controllers
{
    public class SecurityController : BaseController
    {
        private readonly IUserRepository _user;

        public SecurityController(IUserRepository userRepository)
        {
            _user = userRepository;
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            if (ModelState.IsValid)
            {
                ClaimsIdentity claim = await ValidateUser(model.Name, model.Password);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Связка пароля и логина не верна!");
                    return View();
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "User");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult AccessDenied()
        {
            return View();
        }

        private async Task<ClaimsIdentity> ValidateUser(string login, string password)
        {
            ClaimsIdentity claim = null;
            var passwordHash = new PasswordHasher();
            var pas = passwordHash.HashPassword(password);
            // находим пользователя
            // TO DO: вынести в отдельный сервис
            ApplicationUser user = await _user.UserManager.FindAsync(login, password);

            if (user != null)
                claim = await _user.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

            return claim;
        }
    }
}
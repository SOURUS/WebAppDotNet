using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAppsysGalkin.Repository.Interfaces;
using TestAppysGalkin.Web.Models.Authorize;
using TestAppysGalkin.Web.Models.Shared;
using TestAppysGalkin.Web.ViewModels.Security;

namespace TestAppysGalkin.Web.Controllers
{
    public class SecurityController : BaseController
    {
        private readonly IUserRepository _user;

        public SecurityController(IUserRepository userRepository)
        {
            _user = userRepository;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [Meine_Authentifizierung]
        public ActionResult Logout()
        {
            this.Session["UserProfile"] = null;
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            if (ModelState.IsValid)
            {
                UserProfileSessionData User = ValidateUser(model.Name, model.Password);
                if (User == null)
                {
                    ModelState.AddModelError("", "Связка пароля и логина не верна!");
                    return View();
                }
                // записываем сессию в памяти сервера... bad practice 
                this.Session["UserProfile"] = User;

                //отправляем авторизованного куда он хотел
                if (returnUrl!=null)
                    return Redirect(returnUrl);

                return RedirectToAction("Index", "User");
            }

            ModelState.AddModelError("", "Введите данные!");
            return View();
        }

        [AllowAnonymous]
        public ActionResult AccessDenied()
        {
            return View();
        }

        private UserProfileSessionData ValidateUser(string login, string password)
        {
            //чекаем пользователя, передаем пароль как есть по http
            var user = _user.AuthorizeUser(login, password);
            if (user!=null)
                return new UserProfileSessionData { UserId = user.UserId, Login = user.Login};

            return null;
        }
    }
}
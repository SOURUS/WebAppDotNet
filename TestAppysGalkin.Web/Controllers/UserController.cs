using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestAppsysGalkin.Data.Model;
using TestAppsysGalkin.Repository.Interfaces;
using TestAppysGalkin.Web.Models.Authorize;
using TestAppysGalkin.Web.Models.Results;
using TestAppysGalkin.Web.Models.Shared;
using TestAppysGalkin.Web.ViewModels.User;

namespace TestAppysGalkin.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserRepository _user;
        private readonly IMessageRepository _message;

        public UserController(IUserRepository user, IMessageRepository message)
        {
            _user = user;
            _message = message;
        }

        [Meine_Authentifizierung]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Meine_Authentifizierung]
        public async Task<JsonResult> ReceivedMessages()
        {
            try
            {
                var user = await _user.UserManager.FindByIdAsync(User.Identity.GetUserId());
                var Res = Mapper.Map<IEnumerable<Message>, List<RecievedMessageViewModel>>(_message.ReceivedMessages(user.Id));
                return Json(new SuccessResponceWithData(Res));
            }
            catch (Exception Ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new ErrorResponce(Ex.ToString()));
            }
        }


        [HttpPost]
        [Meine_Authentifizierung]
        public async Task<JsonResult> SentMessage()
        {
            try
            {
                var user = await _user.UserManager.FindByIdAsync(User.Identity.GetUserId());
                var Res = Mapper.Map<IEnumerable<Message>, List<SentMessageViewModel>>(_message.SentMessages(user.Id));
                return Json(new SuccessResponceWithData(Res));
            }
            catch (Exception Ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new ErrorResponce(Ex.ToString()));
            }
        }

        [HttpPost]
        [Meine_Authentifizierung]
        public async Task<JsonResult> SendMessage(string ToUserName, string msg)
        {
            try
            {
                var user = await _user.UserManager.FindByIdAsync(User.Identity.GetUserId());
                _message.CreateMessage(user.Id, ToUserName, msg);
                return Json(new SuccessResponce("Сообщение успешно отправлено!"));
            }
            catch (Exception Ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new ErrorResponce(Ex.ToString()));
            }
        }
    }
}
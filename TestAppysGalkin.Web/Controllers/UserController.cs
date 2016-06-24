using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public JsonResult ReceivedMessages()
        {
            try
            {
                var User = Session["UserProfile"] as UserProfileSessionData;
                var Res = Mapper.Map<IEnumerable<Message>, List<RecievedMessageViewModel>>(_message.ReceivedMessages(User.UserId));
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
        public JsonResult SentMessage()
        {
            try
            {
                var User = Session["UserProfile"] as UserProfileSessionData;
                var Res = Mapper.Map<IEnumerable<Message>, List<SentMessageViewModel>>(_message.SentMessages(User.UserId));
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
        public JsonResult SendMessage(string ToUserName, string msg)
        {
            try
            {
                var User = Session["UserProfile"] as UserProfileSessionData;
                _message.CreateMessage(User.UserId, ToUserName, msg);
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
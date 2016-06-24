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
using TestAppysGalkin.Web.Models.Pages.Home;
using TestAppysGalkin.Web.Models.Results;
using TestAppysGalkin.Web.ViewModels.Home;

namespace TestAppysGalkin.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IProductRepository _product;
        private readonly IProducerRepository _producer;

        public HomeController(IProductRepository ProductRep, IProducerRepository ProducerRep)
        {
            _product = ProductRep;
            _producer = ProducerRep;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var Res = Mapper.Map<IEnumerable<Producer>, List<ProducerViewModel>>(_producer.GetAll());

            return View(new SuccessResponceWithData(Res));
        }

        [HttpPost]
        public JsonResult GetProducts()
        {
            var products = Mapper.Map<IEnumerable<Product>, List<ProductViewModel>>(_product.GetAll());

            return Json(new SuccessResponceWithData(products));
        }

        [HttpPost]
        public JsonResult MakeOrder(ProductViewModel Product)
        {
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new ErrorResponce(String.Format("К сожелению наушники {0} - {1} закончились :(", Product.Producer.Name, Product.Name)));
        }
    }
}
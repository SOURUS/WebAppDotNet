using System;
using System.Collections.Generic;
using TestAppsysGalkin.Data.Model;

namespace TestAppysGalkin.Web.ViewModels.Home
{
    public class ProductViewModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public ProducerViewModel Producer { get; set; }

        public HeadPhoneViewModel HeadPhone { get; set; }
    }
}
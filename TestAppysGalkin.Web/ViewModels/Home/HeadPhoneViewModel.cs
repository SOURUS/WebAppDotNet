using System;
using System.Collections.Generic;
using TestAppsysGalkin.Data.Model;

namespace TestAppysGalkin.Web.ViewModels.Home
{
    public class HeadPhoneViewModel
    {
        public int? DynamicQuantity { get; set; }

        public bool? IsDetachableCable { get; set; }

        public bool? IsPortable { get; set; }
    }
}
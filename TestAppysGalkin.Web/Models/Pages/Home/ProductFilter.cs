using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAppysGalkin.Web.Models.Pages.Home
{
    // этот класс я делал, что бы фильтровать поиск продуктов на стороне сервера, но потому посмотрел на скрин,
    // кнопки "поиск" не увидел, поэтому фильтр весь на стороне клиента.
    public class ProductFilter
    {
        public Price Price { get; set; }
        public int? DynamicQuantity { get; set; }
        public bool? IsDetachableCable { get; set; }
        public bool? IsPortable { get; set; }
    }
}
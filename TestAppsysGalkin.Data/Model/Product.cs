using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppsysGalkin.Data.Model
{
    public class Product
    {
        public int ProductId { get; set; }

        [MaxLength(256)]
        [Required]
        public string Name { get; set; }
       
        [Required]
        public decimal Price { get; set; }

        public string Image { get; set; }

        public virtual HeadPhone HeadPhone{ get; set; }

        public virtual Producer Producer { get; set; }
    }
}

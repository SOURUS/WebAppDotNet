using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TestAppsysGalkin.Data.Model
{
    public class Producer
    {
        public int ProducerId { get; set; }

        [MaxLength(256)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

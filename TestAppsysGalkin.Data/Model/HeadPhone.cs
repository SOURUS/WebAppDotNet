using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppsysGalkin.Data.Model
{
    public class HeadPhone
    {
        [Key()]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public int? DynamicQuantity { get; set; }

        public bool? IsDetachableCable { get; set; }

        public bool? IsPortable { get; set; }

        public virtual Product Product { get; set; }
    }
}

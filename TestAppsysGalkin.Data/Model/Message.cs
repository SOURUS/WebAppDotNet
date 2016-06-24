using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppsysGalkin.Data.Model
{
    public class Message
    {
        public int MessageId { get; set; }

        [MaxLength(1000)]
        public string Text { get; set; }

        public int FromUserId { get; set; }

        public int ToUserId { get; set; }

        public virtual User FromUser { get; set; }

        public virtual User ToUser { get; set; }
    }
}

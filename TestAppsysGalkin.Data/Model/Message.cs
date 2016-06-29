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

        public string FromUserId { get; set; }

        public string ToUserId { get; set; }

        public virtual UserProfile FromUser { get; set; }

        public virtual UserProfile ToUser { get; set; }
    }
}

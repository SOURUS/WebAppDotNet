using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppsysGalkin.Data.Model
{
    public class User
    {
        public int UserId { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Message> ReceivedMessages { get; set; }

        public virtual ICollection<Message> SentMessages { get; set; }
    }
}

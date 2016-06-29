using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TestAppsysGalkin.Data.Model
{
    public class ApplicationUser : IdentityUser
    {
        public virtual UserProfile ClientProfile { get; set; }
    }
}

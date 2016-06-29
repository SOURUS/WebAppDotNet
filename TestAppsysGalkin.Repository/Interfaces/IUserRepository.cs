using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestAppsysGalkin.Data.Model;
using TestAppsysGalkin.Data.Model.Identity;

namespace TestAppsysGalkin.Repository.Interfaces
{
    public interface IUserRepository : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }

        Task SaveAsync();
    }
}

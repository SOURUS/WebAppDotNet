using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestAppsysGalkin.Data.Context;
using TestAppsysGalkin.Data.Model;
using TestAppsysGalkin.Data.Model.Identity;
using TestAppsysGalkin.Repository.Interfaces;

namespace TestAppsysGalkin.Repository
{
    public class UserRepository : IUserRepository
    {
        private MainContext db;

        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
        private IClientManager clientManager;

        public UserRepository()
        {
            db = new MainContext();
            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
            clientManager = new ClientManager(db);
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return userManager;
            }
        }

        public IClientManager ClientManager
        {
            get
            {
                return clientManager;
            }
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return roleManager;
            }
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    userManager.Dispose();
                    roleManager.Dispose();
                    clientManager.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestAppsysGalkin.Data.Context;
using TestAppsysGalkin.Data.Model;
using TestAppsysGalkin.Repository.Interfaces;

namespace TestAppsysGalkin.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MainContext _context;
        private bool disposed = false;

        public UserRepository()
        {
            _context = new MainContext();
        }

        public User GetUser(int Id)
        {
            return _context.Users.Single(u => u.UserId == Id);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User AuthorizeUser(string login, string password)
        {
            User user = _context.Users.SingleOrDefault(u => u.Login == login && u.Password == password);
            return user;
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed){
                if (disposing){
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestAppsysGalkin.Data.Model;

namespace TestAppsysGalkin.Repository.Interfaces
{
    public interface IUserRepository : IDisposable
    {
        /// <summary>
        /// Получить коллекцию всех пользователей
        /// </summary>
        IEnumerable<User> GetAll();

        /// <summary>
        /// Получить пользователя по UserId
        /// </summary>
        User GetUser(int Id);

        /// <summary>
        /// Получить пользователя по паролю и логину
        /// </summary>
        User AuthorizeUser(string login, string password);
        //void Remove(K Id);
    }
}

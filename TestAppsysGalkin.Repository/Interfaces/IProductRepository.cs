using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestAppsysGalkin.Data.Model;

namespace TestAppsysGalkin.Repository.Interfaces
{
    public interface IProductRepository : IDisposable
    {
        /// <summary>
        /// Получить коллекцию всех товаров
        /// </summary>
        IEnumerable<Product> GetAll();
    }
}

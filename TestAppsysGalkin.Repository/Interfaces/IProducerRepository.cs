using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAppsysGalkin.Data.Model;

namespace TestAppsysGalkin.Repository.Interfaces
{
    public interface IProducerRepository : IDisposable
    {
        /// <summary>
        /// Получить коллекцию всех производителей
        /// </summary>
        IEnumerable<Producer> GetAll();
    }
}

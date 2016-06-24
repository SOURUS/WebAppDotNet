using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAppsysGalkin.Data.Context;
using TestAppsysGalkin.Data.Model;
using TestAppsysGalkin.Repository.Interfaces;

namespace TestAppsysGalkin.Repository
{
    public class ProducerRepository : IProducerRepository
    {
        private readonly MainContext _context;
        private bool disposed = false;

        public ProducerRepository()
        {
            _context = new MainContext();
        }

        public IEnumerable<Producer> GetAll()
        {
            return _context.Producers.ToList();
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

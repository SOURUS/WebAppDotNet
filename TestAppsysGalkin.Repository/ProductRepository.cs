using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestAppsysGalkin.Data;
using TestAppsysGalkin.Data.Context;
using TestAppsysGalkin.Data.Model;
using TestAppsysGalkin.Repository.Interfaces;

namespace TestAppsysGalkin.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MainContext _context;
        private bool disposed = false;

        public ProductRepository()
        {
            _context = new MainContext();
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAppsysGalkin.Data.Context;
using TestAppsysGalkin.Repository.Interfaces;

namespace TestAppsysGalkin.Repository
{
    public class ClientManager : IClientManager
    {
        public MainContext Database { get; set; }
        public ClientManager(MainContext db)
        {
            Database = db;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAppsysGalkin.Data.Context;

namespace TestAppsysGalkin.Data
{
    class Program
    {

        static void Main(string[] args)
        {
            using (var db = new MainContext())
            {
                Database.SetInitializer(new DropCreateInit());

                if (db.Database.Exists())
                {
                    SqlConnection.ClearAllPools();
                }

                db.Database.Initialize(true);
            }

            Console.WriteLine("Деплой базы успешно выполнен, для продолжения нажмите Enter");
            Console.ReadLine();
        }
    }
}

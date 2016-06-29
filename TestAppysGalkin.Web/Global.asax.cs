using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TestAppsysGalkin.Data.Model;
using TestAppsysGalkin.Repository;
using TestAppsysGalkin.Repository.Interfaces;
using TestAppysGalkin.Web.App_Start;
using TestAppysGalkin.Web.ViewModels.Home;
using Unity.Mvc4;

namespace TestAppysGalkin.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static IUnityContainer Container { get; set; }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);

            //создаем и регистрируем зависимости
            Container = new UnityContainer();
            RegisterDependencies();
            DependencyResolver.SetResolver(new UnityDependencyResolver(Container));

            //регисртрируем маппнги
            MappingConfig.RegisterMaps();
        }

        private static void RegisterDependencies()
        {
            Container.RegisterType<IProductRepository, ProductRepository>();
            Container.RegisterType<IUserRepository, UserRepository>();
            Container.RegisterType<IProducerRepository, ProducerRepository>();
            Container.RegisterType<IMessageRepository, MessageRepository>();
        }
    }
}

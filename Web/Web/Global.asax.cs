using BL;
using Castle.Windsor;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            InitData();

            BootstrapContainer();
        }

        private static void BootstrapContainer()
        {
            container = new WindsorContainer();
            container.Install(new Installer());
            container.Install(new DataInstaller());

            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }

        private void InitData()
        {
            using (var context = new AppDbContext())
            {
                if (!context.Categories.Any())
                {


                    List<Category> categories = new List<Category>
                {
                    new Category { Name= "Category 1" },
                    new Category { Name= "Category 2" },
                };

                    List<Product> products = new List<Product>
                {
                    new Product { Name= "Product 1", Description ="Description of product 1", Price = 12.0, Categories = categories },
                    new Product { Name= "Product 2", Description ="Description of product 2", Price = 30.0 }

                };
                    //context.Categories.AddRange(categories);
                    context.Products.AddRange(products);
                    context.SaveChanges();
                }
            }
        }
    }
}

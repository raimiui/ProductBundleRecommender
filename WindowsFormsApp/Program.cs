using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bll.Interfaces;
using ProductBundleRecommender.BLL;
using Repositories.Interfaces;
using Unity;
using Unity.Lifetime;

namespace WindowsFormsApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = new UnityContainer();
            RegisterTypes(container);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new QuestionsForm(container.Resolve<IProductBundleService>(), container.Resolve<IProductService>()));
        }

        private static void RegisterTypes(UnityContainer container)
        {
            // Repositories
            container.RegisterType<IProductBundleRepository, ProductBundleRepository>(new ContainerControlledLifetimeManager()); 
            container.RegisterType<IProductBundleService, ProductBundleService>(new ContainerControlledLifetimeManager());
            
            // Services
            container.RegisterType<IProductService, ProductService>(new ContainerControlledLifetimeManager()); 
        }
    }
}

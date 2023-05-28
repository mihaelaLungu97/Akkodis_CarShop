using CarShop_RoxanaLungu.Data;
using CarShop_RoxanaLungu.Models.Interfaces;
using CarShop_RoxanaLungu.Models.Services;
using CarShop_RoxanaLungu.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CarShop_RoxanaLungu
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);


            var services = new ServiceCollection();

            // Register your services
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<CarShopDbContext>();

            // Build the ServiceProvider
            var serviceProvider = services.BuildServiceProvider();

            // Resolve the required services
            var carRepository = serviceProvider.GetService<ICarRepository>();
            var clientRepository = serviceProvider.GetService<IClientRepository>();
            // Pass the resolved services to your main window or other components
            var mainWindow = new HomeView(carRepository, clientRepository );
            mainWindow.Show();
        }
    }
}

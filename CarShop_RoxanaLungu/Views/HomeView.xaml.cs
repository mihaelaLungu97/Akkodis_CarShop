using CarShop_RoxanaLungu.Data;
using CarShop_RoxanaLungu.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarShop_RoxanaLungu.Views
{
    public partial class HomeView : Window
    {
        private IClientRepository clientsRepository;
        private ICarRepository carRepository;
        private CarShopDbContext dbContext;

        public int CarCount { get; set; }

        /* public HomeView()
         {
             InitializeComponent();

         }*/

        public HomeView(ICarRepository carRepository, IClientRepository clientsRepository)
        {
            InitializeComponent();
            this.carRepository = carRepository;
            this.clientsRepository = clientsRepository;
            DataContext = this;

            CarCount = carRepository.GetCarCount();
            
        }
       /* public HomeView(CarShopDbContext dbContext)
        {
            InitializeComponent();

            this.dbContext = dbContext;
        }*/

        private void GetClients_Click(object sender, RoutedEventArgs e)
        {
            ClientsView clientsView = new ClientsView(clientsRepository, carRepository);
            clientsView.Show();
            Close();
        }

        private void GetCars_Click(object sender, RoutedEventArgs e)
        {
            CarsView carsView = new CarsView(carRepository, clientsRepository);
            carsView.Show();
            Close();
        }
    }
}

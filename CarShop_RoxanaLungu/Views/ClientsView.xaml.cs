using CarShop_RoxanaLungu.Controllers;
using CarShop_RoxanaLungu.Models;
using CarShop_RoxanaLungu.Models.Interfaces;
using CarShop_RoxanaLungu.Models.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace CarShop_RoxanaLungu.Views
{
    public partial class ClientsView : Window
    {
        private IClientRepository clientsRepository;
        private ICarRepository carRepository;
        public ObservableCollection<Client> Clients { get; set; }
        public ClientsView(IClientRepository clientsRepository, ICarRepository carRepository)
        {
            InitializeComponent();
            this.clientsRepository = clientsRepository;
            this.carRepository = carRepository;
            Clients = new ObservableCollection<Client>(clientsRepository.GetAllClients().ToList());
            
            DataContext = this;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            HomeView homeView = new HomeView(carRepository, clientsRepository);
            homeView.Show();
            Close();
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            var homeView = new AddClientView(clientsRepository, carRepository );
            homeView.Show();
            Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            ClientController clientController = new ClientController(clientsRepository);
            Button button = (Button)sender;
            if (button.CommandParameter is int clientId)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this client?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    clientController.DeleteClient(clientId);

                    RefreshDataGrid();
                }
            }
        }

        private void RefreshDataGrid()
        {
            ClientController clientController = new ClientController(clientsRepository);
            Clients.Clear();  

            var updatedClients = clientController.GetClients();
            foreach (var client in updatedClients)
            {
                Clients.Add(client);
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
                Button button = (Button)sender;
            if (button.CommandParameter is int clientId)
            { 
                UpdateClientView updateClientWindow = new UpdateClientView(clientId, carRepository, clientsRepository);
                updateClientWindow.ShowDialog();
               
                RefreshDataGrid();
            }
            }
    }
}

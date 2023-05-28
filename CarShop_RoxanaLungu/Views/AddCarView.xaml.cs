using CarShop_RoxanaLungu.Controllers;
using CarShop_RoxanaLungu.Models;
using CarShop_RoxanaLungu.Models.Interfaces;
using CarShop_RoxanaLungu.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// <summary>
    /// Interaction logic for AddCarView.xaml
    /// </summary>
    public partial class AddCarView : Window
    {
        private IClientRepository clientsRepository;
        private ICarRepository carsRepository;
        public AddCarView(ICarRepository carsRepository, IClientRepository clientsRepository)
        {
            InitializeComponent();
            this.carsRepository = carsRepository;
            this.clientsRepository = clientsRepository;
            clientComboBox.ItemsSource = GetAvailableClients();
        }
        private List<Client> GetAvailableClients()
        {
            ClientController clientController = new ClientController(clientsRepository);
            List<Client> availableClients = clientController.GetClients();

            return availableClients;
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            CarsController carsController = new CarsController(carsRepository);

            Client selectedClient = (Client)clientComboBox.SelectedItem;
            string vin = VINTextBox.Text;
            string registrationNumber = RegistrationNumberTextBox.Text;
            string brand = BrandTextBox.Text;
            carsController.AddCarToClient(selectedClient, vin, registrationNumber, brand);

            Close();
        }
       
       
    }
   
}

using CarShop_RoxanaLungu.Controllers;
using CarShop_RoxanaLungu.Models;
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
using System.Windows.Shapes;

namespace CarShop_RoxanaLungu.Views
{
    public partial class UpdateClientView : Window
    {
        private int clientId;
        private ICarRepository carsRepository;
        private IClientRepository clientsRepository;
        public UpdateClientView(int clientId, ICarRepository carsRepository, IClientRepository clientsRepository)
        {
            InitializeComponent();
            this.clientId = clientId;
            this.carsRepository = carsRepository;
            this.clientsRepository = clientsRepository;

            ClientController clientController = new ClientController(clientsRepository);
            Client client = clientController.GetClient(clientId);
            nameTextBox.Text = client.Name;
            cnpTextBox.Text = client.CNP;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTextBox.Text;
            string cnp = cnpTextBox.Text;

            var clientController = new ClientController(clientsRepository);
            Client client = clientController.GetClient(clientId);
            client.Name = name;
            client.CNP = cnp;

            clientController.UpdateClient(client);

            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

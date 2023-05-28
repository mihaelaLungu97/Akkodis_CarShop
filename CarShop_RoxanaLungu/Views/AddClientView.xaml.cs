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
    public partial class AddClientView : Window
    {
        private IClientRepository clientsRepository;
        private ICarRepository carRepository;
        public AddClientView(IClientRepository clientsRepository, ICarRepository carRepository)
        {
            InitializeComponent();
            this.clientsRepository = clientsRepository;
            this.carRepository = carRepository;
        }

        //valid cnp: 1760217418171  2970217020291 5001110087094  6051124266037  5030924380115 2990217013191
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            ClientController clientController = new ClientController(clientsRepository);
            string name = NameTextBox.Text;
            string cnp = CnpTextBox.Text;

            clientController.AddClientWithCar(name, cnp);

            NameTextBox.Text = string.Empty;
            CnpTextBox.Text = string.Empty;
            if(clientController.IsClientSave)
            {
               AddCarView addCarWindow = new AddCarView(carRepository, clientsRepository);
               addCarWindow.ShowDialog(); 
            }
                       
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ClientsView homeView = new ClientsView(clientsRepository, carRepository);
            homeView.Show();
            Close();
        }
    }
}

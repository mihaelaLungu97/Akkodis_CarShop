using CarShop_RoxanaLungu.Controllers;
using CarShop_RoxanaLungu.Models;
using CarShop_RoxanaLungu.Models.Interfaces;
using CarShop_RoxanaLungu.Models.Services;
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
    public partial class UpdateCarView : Window
    {
        private int carId;
        private ICarRepository carsRepository;
        private IClientRepository clientsRepository;

        public UpdateCarView(int carId, ICarRepository carsRepository, IClientRepository clientsRepository)
        {
            InitializeComponent();
            this.carId = carId;
            this.carsRepository = carsRepository;
             this.clientsRepository = clientsRepository;
            
            CarsController carController = new CarsController(carsRepository);
            Car car = carController.GetCarById(carId);
            vinTextBox.Text = car.VIN;
            registrationTextBox.Text = car.RegistrationNumber;
            brandTextBox.Text = car.Brand;
            
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string vin = vinTextBox.Text;
            string registrationNumber = registrationTextBox.Text;
            string brand = brandTextBox.Text;

            
            var carController = new CarsController(carsRepository);
            Car car = carController.GetCarById(carId);
            car.VIN = vin;
            car.RegistrationNumber = registrationNumber;
            car.Brand = brand;

            carController.UpdateCar(car);

            this.Close();
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        }
}

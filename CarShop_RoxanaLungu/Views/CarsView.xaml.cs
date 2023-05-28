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
    public partial class CarsView : Window
    {
        #region Fields
        private ICarRepository carsRepository;
        private IClientRepository clientsRepository;
        public ObservableCollection<Car> Cars { get; set; }
        #endregion

        #region Constructor
        public CarsView(ICarRepository carsRepository, IClientRepository clientsRepository)
        {
            InitializeComponent();
            this.carsRepository = carsRepository;
            this.clientsRepository = clientsRepository;
            Cars = new ObservableCollection<Car>(carsRepository.GetAllCars().ToList());
            foreach (var car in Cars)
            {
                car.Client = clientsRepository.GetClient(car.ClientId);
            }
            DataContext = this;
        }
        #endregion

        #region Event Handlers

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            HomeView homeView = new HomeView(carsRepository,clientsRepository);
            homeView.Show();
            Close();
        }
        
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

            Button button = (Button)sender;
            int carId = (int)button.CommandParameter;
            var carsController = new CarsController(carsRepository);
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this car?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                carsController.DeleteCar(carId);

                RefreshDataGrid();
            }
        }
        private void RefreshDataGrid()
        {
            Cars.Clear();  
            var carsController = new CarsController(carsRepository);
            var updatedCars = carsController.GetCars();
            foreach (var car in updatedCars)
            {
                Cars.Add(car);
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int carId = (int)button.CommandParameter;
            UpdateCarView updateCarWindow = new UpdateCarView(carId, carsRepository, clientsRepository);
            updateCarWindow.ShowDialog();

            RefreshDataGrid();
        }

        private void AddCarToClientButton_Click(object sender, RoutedEventArgs e)
        {
            AddCarView addCarWindow = new AddCarView(carsRepository,clientsRepository);
            addCarWindow.ShowDialog();
            RefreshDataGrid();
        }
        #endregion
    }
}

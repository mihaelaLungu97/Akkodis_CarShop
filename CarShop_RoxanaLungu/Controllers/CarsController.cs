using CarShop_RoxanaLungu.Models;
using CarShop_RoxanaLungu.Models.Interfaces;
using CarShop_RoxanaLungu.Models.Services;
using CarShop_RoxanaLungu.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace CarShop_RoxanaLungu.Controllers
{
    public class CarsController
    {
        #region Fields
        private ICarRepository carRepository;
        private List<Client> availableClients;

        #endregion

        #region Constructor
        public CarsController(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }
        #endregion

        #region Methods
        public IEnumerable<Car> GetCars()
        {
            return carRepository.GetAllCars();
        }

        public void AddCar(Car car)
        {
            carRepository.AddCar(car);
        }

        public void DeleteCar(int id)
        {
            carRepository.DeleteCar(id);
        }

        public Car GetCarById(int id)
        {
            return carRepository.GetCar(id);
        }

        public void UpdateCar(Car car)
        {
            carRepository.UpdateCar(car);
        }

        public void AddCarToClient(Client selectedClient, string vin, string registrationNumber, string brand)
        {
            if (selectedClient == null)
            {
                MessageBox.Show("Please select a client.");
                return;
            }

            if (!ValidateCarRegistrationNumber(registrationNumber))
            {
                MessageBox.Show("Registration number is invalid.");
                return;
            }
            if(CarExists(registrationNumber)) {
                MessageBox.Show("Car already exists.");
                return;
            }

            Car car = new Car
            {
                VIN = vin,
                RegistrationNumber = registrationNumber,
                Brand = brand
            };

            selectedClient.Cars.Add(car);
            car.ClientId = (int)selectedClient.ClientId;
            car.Client = selectedClient;

            AddCar(car);
        }

        public bool ValidateCarRegistrationNumber(string registrationNumber)
        {
            string pattern = @"^[A-Z]{1,2}\d{2,3}[A-Z]{3}$";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(registrationNumber);

            return match.Success;
        }

        public bool CarExists(string registrationNumber)
        {
            return carRepository.CarExists(registrationNumber);
        }
        
        #endregion
    }
}

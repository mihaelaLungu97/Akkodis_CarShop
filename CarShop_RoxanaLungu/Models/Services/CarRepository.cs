using CarShop_RoxanaLungu.Data;
using CarShop_RoxanaLungu.Models.Interfaces;
using CarShop_RoxanaLungu.Views;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CarShop_RoxanaLungu.Models.Services
{
    public class CarRepository : ICarRepository
    {
        #region Fields
        private CarShopDbContext dbContext;
        #endregion

        #region Constructor
        public CarRepository(CarShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        #endregion

        #region Methods
        public void AddCar(Car car)
        {
            var existingCar = dbContext.Cars.FirstOrDefault(c => c.Id == car.Id);
            if (existingCar == null)
            { 
                dbContext.Add(car);
                dbContext.SaveChanges();
            }
        }

        public void DeleteCar(int id)
        {
            var car = GetCar(id);
            if (car != null)
            {
                if (car.Client.Cars.Count == 1)
                {
                    var client = car.Client;
                    dbContext.Cars.Remove(car);
                    dbContext.Clients.Remove(client);
                }
                else
                {
                    dbContext.Cars.Remove(car);
                }
            }
            dbContext.SaveChanges();
        }

        public IEnumerable<Car> GetAllCars()
        {
            return dbContext.Cars;
        }

        public Car? GetCar(int id)
        {
            return dbContext.Cars.FirstOrDefault(p => p.Id == id);
        }

        public void UpdateCar(Car car)
        {
            dbContext.Cars.Update(car);
            dbContext.SaveChanges();
        }
        public bool CarExists(string registrationnumber)
        {
            return dbContext.Cars.Any(c => c.RegistrationNumber == registrationnumber);
        }

        public int GetCarCount()
        {
           string ConnectionString= "Server=(localdb)\\MSSQLLocalDB;Database=CarShopDB;Trusted_Connection=True;MultipleActiveResultSets=True";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Cars", connection))
                {
                    return (int)command.ExecuteScalar();
                }
              //  the connection will be automatically closed and disposed of when it goes out of scope. 
            }
        }
        #endregion
    }
}

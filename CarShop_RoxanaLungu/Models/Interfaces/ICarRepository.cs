using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop_RoxanaLungu.Models.Interfaces
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetAllCars();
        Car? GetCar(int id);
        void AddCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(int id);
        bool CarExists(string registrationNumber);
        int GetCarCount();
    }
}

using CarShop_RoxanaLungu.Models;
using CarShop_RoxanaLungu.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop_RoxanaLungu.Controllers
{
    public class HomeController
    {
        #region Fields
        private IClientRepository clientsRepository;
        private ICarRepository carRepository;
        #endregion

        #region Constructor
        public HomeController(IClientRepository clientsRepository, ICarRepository carRepository)
        {
            this.clientsRepository = clientsRepository;
            this.carRepository = carRepository;
        }
        #endregion

        #region Methods
        public List<Client> GetClients()
        {
            return clientsRepository.GetAllClients();
        }
        public IEnumerable<Car> GetCars()
        {
            return carRepository.GetAllCars();
        }
        #endregion
    }
}

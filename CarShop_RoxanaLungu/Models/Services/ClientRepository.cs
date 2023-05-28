using CarShop_RoxanaLungu.Data;
using CarShop_RoxanaLungu.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop_RoxanaLungu.Models.Services
{
    public class ClientRepository : IClientRepository
    {
        #region Fields
        private CarShopDbContext dbContext;
        #endregion

        #region Constructor
        public ClientRepository(CarShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        #endregion

        #region Methods
        public void AddClient(Client client)
        {
            dbContext.Clients.Add(client);
            dbContext.SaveChanges();
        }

        public List<Client> GetAllClients()
        {
            return dbContext.Clients.Include(c => c.Cars).ToList();
        }

        public Client? GetClient(int id)
        {
            return dbContext.Clients.Include(c => c.Cars).FirstOrDefault(c => c.ClientId == id);
        }

        public void UpdateClient(Client client)
        {
            dbContext.Clients.Update(client);
            dbContext.SaveChanges();
        }

        public void DeleteClient(int id)
        {
            var client = GetClient(id);
            if (client != null)
            {
                foreach(var car in client.Cars)
                {
                    dbContext.Cars.Remove(car);
                }
                dbContext.Clients.Remove(client);
                dbContext.SaveChanges();
            }
        }

        public bool ClientExists(string cnp)
        {
            return dbContext.Clients.Any(c => c.CNP == cnp);
        }
        #endregion
    }
}

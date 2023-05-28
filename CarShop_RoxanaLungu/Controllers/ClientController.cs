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
    public class ClientController
    {
        #region Fields
        private IClientRepository clientsRepository;
        #endregion

        #region Constructor

        public ClientController(IClientRepository clientsRepository)
        {
            this.clientsRepository = clientsRepository;
        }
        #endregion

        #region Methods
        public List<Client> GetClients()
        {
            return clientsRepository.GetAllClients();
        }
        public void AddClient(Client client)
        {
            clientsRepository.AddClient(client);
        }
        public void DeleteClient(int id) { 
            clientsRepository.DeleteClient(id);
        }
        public bool ClientExists(string cnp)
        {
            return clientsRepository.ClientExists(cnp);
        }
        public void UpdateClient(Client client)
        {
            clientsRepository.UpdateClient(client);
        }
        public Client GetClient(int id)
        {
            return clientsRepository.GetClient(id);
        }
        public  bool IsClientSave = false;
        public void AddClientWithCar(string name, string cnp)
        {
            if (!ValidateCNP(cnp))
            {
                MessageBox.Show("CNP is not valid");
                IsClientSave=false;
                return;
            }

            if (ClientExists(cnp))
            {
                MessageBox.Show("A client with the same CNP already exists");
                IsClientSave = false;
                return;
            }

            Client client = new Client
            {
                Name = name,
                CNP = cnp,
                Cars = new List<Car>()
            };
            IsClientSave=true;
            AddClient(client);
        }
       
        public bool ValidateCNP(string cnp)
        {
            if (string.IsNullOrEmpty(cnp) || cnp.Length != 13)
            {
                return false;
            }

            int[] weights = { 2, 7, 9, 1, 4, 6, 3, 5, 8, 2, 7, 9 };
            int sum = 0;

            for (int i = 0; i < 12; i++)
            {
                if (!char.IsDigit(cnp[i]))
                {
                    return false;
                }

                sum += (cnp[i] - '0') * weights[i];
            }

            int controlDigit = cnp[12] - '0';
            int remainder = sum % 11;
            int expectedControlDigit = (remainder < 10) ? remainder : 1;

            return controlDigit == expectedControlDigit;
        }
        
        #endregion 
    }

   
}

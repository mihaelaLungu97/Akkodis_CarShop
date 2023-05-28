using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop_RoxanaLungu.Models.Interfaces
{
    public interface IClientRepository
    {
        void AddClient(Client client);
        Client? GetClient(int id);
        List<Client> GetAllClients();
        void UpdateClient(Client client);
        void DeleteClient(int id);
        bool ClientExists(string cnp);
    }
}

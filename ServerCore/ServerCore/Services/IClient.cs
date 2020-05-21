using ServerCore.Models;
using System.Collections.Generic;

namespace ServerCore.Services
{
    public interface IClient
    {
        int Create(Client client); // registration
        int GetId(Client client); // autorization
        List<Client> GetClients(); /*для проверки контроллера */
    }
}

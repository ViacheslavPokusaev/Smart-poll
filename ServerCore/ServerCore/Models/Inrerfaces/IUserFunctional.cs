using System.Collections.Generic;
using ServerCore.Models.Classes;

namespace ServerCore.Models.Inrerfaces
{
    public interface IUserFunctional
    {
        void Create(User user);       
        User Get(int UserID);
        List<User> GetUsers(); /*для проверки, можно и просто при авторизации использавать просто Get */       
    }
}

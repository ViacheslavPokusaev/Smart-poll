using System.Collections.Generic;
using ServerCore.Models.Classes;

namespace ServerCore.Models.Inrerfaces
{
    public interface IUserFunctional
    {
        void Create(User user);
        User Get(int IdUser);
        List<User> GetUsers();
    }
}

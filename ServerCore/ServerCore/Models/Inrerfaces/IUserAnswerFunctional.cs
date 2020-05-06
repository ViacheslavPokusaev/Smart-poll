using ServerCore.Models.Classes;
using System.Collections.Generic;

namespace ServerCore.Models.Inrerfaces
{
    public interface IUserAnswerFunctional
    {
        void Create(UserAnswer userAnswer);
        UserAnswer Get(int IDAnswer);
        List<UserAnswer> GetUsersAnswers();
    }
}

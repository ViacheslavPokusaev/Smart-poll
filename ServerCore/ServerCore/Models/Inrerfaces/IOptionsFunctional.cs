using ServerCore.Models.Classes;
using System.Collections.Generic;

namespace ServerCore.Models.Inrerfaces
{
    public interface IOptionsFunctional
    {
        void Create(Option option);
        List<Option> GetOptions();
        List<Option> GetOptionsByOneVoting(int VotingID);
    }
}

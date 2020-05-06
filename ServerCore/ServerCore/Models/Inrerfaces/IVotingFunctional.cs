using ServerCore.Models.Classes;
using System.Collections.Generic;

namespace ServerCore.Models.Inrerfaces
{
    public interface IVotingFunctional
    {
        void Create(Voting voting);
        Voting Get(int VotingID);
        List<Voting> GetVotings();
    }
}

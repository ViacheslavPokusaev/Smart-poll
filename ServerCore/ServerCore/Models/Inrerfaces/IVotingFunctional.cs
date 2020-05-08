using ServerCore.Models.Classes;
using System.Collections.Generic;

namespace ServerCore.Models.Inrerfaces
{
    public interface IVotingFunctional
    {
        void Create(Voting voting);
        List<Voting> GetAllVotings();
        Voting Get(int VotingID);
        List<Voting> GetUserVotings(int UserID);
        void DeleteVoting(int VotingID);
    }
}

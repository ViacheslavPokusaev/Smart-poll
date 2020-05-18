using ServerCore.Models.Classes;
using System.Collections.Generic;

namespace ServerCore.Models.Inrerfaces
{
    public interface IVotingFunctional
    {
        void Create(Voting voting);
        List<Voting> GetAllVotings();
        void Update(Voting voting);
        List<Voting> GetVotings(int TypeVoting, int UserID = -1);
        void DeleteVoting(int VotingID);
    }
}

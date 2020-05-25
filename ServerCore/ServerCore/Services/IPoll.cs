using ServerCore.Models;
using System.Collections.Generic;

namespace ServerCore.Services
{
    public interface IPoll
    {
        Poll Create(Poll poll);
        void Update(Poll poll);
        List<Poll> GetListPoll(int TypePoll, int ClientId = -1); // TypePull: 0 - public, 1 - private, 2 - dead, any - allClientVotings(public + dead)
        void DeletePoll(int Id);
        void DeleteOption(int Id);
        void DeleteAllFromPoll(int Id);
        OptionPoll AddOption(OptionPoll option);
    }
}

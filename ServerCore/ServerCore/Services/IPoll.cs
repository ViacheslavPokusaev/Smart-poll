using ServerCore.Models;
using System.Collections.Generic;

namespace ServerCore.Services
{
    public interface IPoll
    {
        void Create(Poll poll);
        void Update(Poll poll);
        List<Poll> GetListPoll(int TypePoll, int ClientId = -1); // TypePull: 0 - public, 1 - private, 2 - dead, any - allClientVotings(public + dead)
        int GetIdOption(int PollId, string TextOption);
        void DeletePoll(int Id);
        void AddOptions(OptionPoll[] options);
        void AddOption(OptionPoll option);
    }
}

using System;
using System.Collections.Generic;

namespace ServerCore.Models
{
    public class Poll
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string NameAuthorPoll { get; set; }
        public bool IsPossibleToAddOption { get; set; }
        public int MaxOptionsInPoll { get; set; }
        public int MaxVotesByOneClient { get; set; }
        public string QuestionText{ get; set; }
        public DateTime DeadLine { get; set; }
        public bool IsPrivate { get; set; }
        public OptionPoll[] OptionsPoll { get; set; }
        public List<ClientAnswer[]> ClientsAnswers { get; set; }
        public int CountAllAnswer { get; set; }
    }
}
